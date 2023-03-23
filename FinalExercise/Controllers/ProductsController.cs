using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FinalExercise.Domain.Models;
using FinalExercise.Domain.Interfaces;
using AutoMapper;
using FinalExercise.DTOs;

namespace FinalExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> GetProduct() => Ok(await _unitOfWork.Product.GetAll());

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductGetByIdDTO>> GetProduct(int id)
        {
            var product = await _unitOfWork.Product.Get(id);

            if (product == null)
            {
                return NotFound();
            }

            var response = _mapper.Map<ProductGetByIdDTO>(product);

            return response;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public IActionResult PutProduct(int id, ProductDTO product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }
            if (!_unitOfWork.Product.Any(id))
            {
                return NotFound();
            }
            _unitOfWork.Product.Update(_mapper.Map<Product>(product));
            _unitOfWork.Complete();
            return Ok("Product Updated");
        }

        // POST: api/Products
        [HttpPost]
        public IActionResult PostProduct(ProductPostDTO product)
        {
            var result = _unitOfWork.Product.Add(_mapper.Map<Product>(product));
            _unitOfWork.Complete();

            if (result is not null)
                return Ok("Product Created");
            else
                return BadRequest("Error in Creating the Product");
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _unitOfWork.Product.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Delete(product);
            _unitOfWork.Complete();
            return Ok("Product Deleted");
        }
    }
}
