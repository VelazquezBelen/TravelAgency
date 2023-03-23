using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FinalExercise.Domain.AbstractFactory;
using FinalExercise.Domain.Interfaces;
using FinalExercise.Domain.Models;
using FinalExercise.DTOs;

namespace FinalExercise.Services
{
    public class CommissionService : ICommissionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ClientTypeFactory clientTypeFactory;

        public CommissionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            clientTypeFactory = new ClientTypeFactory();
        }

        public async Task<ServiceResponse> AddCommission(CommissionRequestDTO commissionRequest)
        {
            ServiceResponse response = new ServiceResponse();

            if ((commissionRequest.PassengersAmmount < 0 || commissionRequest.PassengersAmmount > 10) || (commissionRequest.TripDuration < 0 || commissionRequest.TripDuration > 60))
            {
                response.Data = 0;
                response.Message = "BadRequest";
                response.Success = false;
                return response;
            }            

            var client = await _unitOfWork.Client.Get(commissionRequest.ClientTypeId);
            if (client == null)
            {
                response.Data = 0;
                response.Message = "NotFound";
                response.Success = false;
                return response;
            }

            List<TravelPackage> travelPackages = (List<TravelPackage>)await _unitOfWork.TravelPackage.GetAllPackagesById(commissionRequest.TravelPackages);

            var clientStrategy = clientTypeFactory.GenerateClientType(client);

            var commission = clientStrategy.CommissionStrategy(travelPackages, commissionRequest);

            await _unitOfWork.Commission.Add(new Commission
            {
                ClientTypeId = commissionRequest.ClientTypeId,
                PassengersAmmount = commissionRequest.PassengersAmmount,
                TripDuration = commissionRequest.TripDuration,
                TravelPackages = travelPackages,
                CommissionResult = commission
            });
            _unitOfWork.Complete();

            response.Data = (float)commission;
            response.Message = "Ok";
            response.Success = true;

            return response;
        }

        public async Task<ServiceResponse> DeleteCommission(int id)
        {
            ServiceResponse response = new ServiceResponse();
            var commission = await _unitOfWork.Commission.Get(id);
            if (commission == null)
            {
                response.Data = 0;
                response.Message = "NotFound";
                response.Success = true;
                return response;
            }
            _unitOfWork.Commission.Delete(commission);
            _unitOfWork.Complete();
            response.Data = 0;
            response.Message = "Ok";
            response.Success = true;
            return response;
        }

        public async Task<IEnumerable<CommissionDTO>> GetCommissions()
        {
            var commissions = await _unitOfWork.Commission.GetAll();
            return _mapper.Map<IEnumerable<CommissionDTO>>(commissions);
        }
    }
}
