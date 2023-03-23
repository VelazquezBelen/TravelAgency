using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalExercise.Domain.Models;
using FinalExercise.Domain.Interfaces;
using FinalExercise.DTOs;
using AutoMapper;

namespace FinalExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelPackagesController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TravelPackagesController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/TravelPackages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TravelPackageDTO>>> GetTravelPackage()
        {
            var travelPackages = await _unitOfWork.TravelPackage.GetAll();
            var response = _mapper.Map<IEnumerable<TravelPackageDTO>>(travelPackages);
            return Ok(response);
        }          
              
        // GET: api/TravelPackages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TravelPackageGetByIdDTO>> GetTravelPackage(int id)
        {
            var travelPackage = await _unitOfWork.TravelPackage.Get(id);

            if (travelPackage == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<TravelPackageGetByIdDTO>(travelPackage);

            return response;
        }

        // PUT: api/TravelPackages/5
        [HttpPut("{id}")]
        public IActionResult PutTravelPackage(int id, TravelPackageDTO travelPackage)
        {
            if (id != travelPackage.TravelPackageId)
            {
                return BadRequest();
            }
            if (!_unitOfWork.TravelPackage.Any(id))
            {
                return NotFound();
            }
            _unitOfWork.TravelPackage.Update(_mapper.Map<TravelPackage>(travelPackage));
            _unitOfWork.Complete();
            return Ok("Travel Package Updated");
        }

        // POST: api/TravelPackages
        [HttpPost]
        public async Task<IActionResult> PostTravelPackage(TravelPackagePostDTO newTravelPackage)
        {
            var travelPackage = _mapper.Map<TravelPackage>(newTravelPackage);

            var products = travelPackage.Products.ToList();
            var trackedProducts = new List<Product>();

            for (int i = 0; i < products.Count(); i++)
            {
                var trackedProduct = await _unitOfWork.Product.Get(products[i].ProductId);
                if (trackedProduct != null)
                {
                    trackedProducts.Add(trackedProduct);
                    trackedProduct.TravelPackages.Add(travelPackage);
                    products[i] = trackedProduct;
                }
            }

            products.RemoveAll(x => trackedProducts.Contains(x));
            travelPackage.Products = products;

            var result = _unitOfWork.TravelPackage.Add(travelPackage);
            foreach (var product in trackedProducts)
                _unitOfWork.Product.Update(product);

            _unitOfWork.Complete();

            if (result is not null)
                return Ok("Travel Package Created");
            else
                return BadRequest("Error in Creating the Travel Package"); 
        }

        // DELETE: api/TravelPackages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTravelPackage(int id)
        {
            var travelPackage = await _unitOfWork.TravelPackage.Get(id);
            if (travelPackage == null)
            {
                return NotFound();
            }

            _unitOfWork.TravelPackage.Delete(travelPackage);
            _unitOfWork.Complete();
            return Ok("Travel Package Deleted");
        }

        // GET: api/TravelPackages/GetTravelPackageByDescription
        [HttpGet (nameof(GetTravelPackageByDescription))]
        public async Task<ActionResult<IEnumerable<TravelPackageDTO>>> GetTravelPackageByDescription(String description)
        {
            var travelPackages = Enumerable.Empty<TravelPackage>(); 
            
            if (description == null)
                travelPackages = await _unitOfWork.TravelPackage.GetAll();
            else
                travelPackages = await _unitOfWork.TravelPackage.GetTravelPackagesByDescription(description);            
           
            var response = _mapper.Map<IEnumerable<TravelPackageDTO>>(travelPackages);
            return Ok(response);
        }        
    }
}
