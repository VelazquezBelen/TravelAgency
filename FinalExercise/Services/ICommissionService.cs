using System.Collections.Generic;
using System.Threading.Tasks;
using FinalExercise.DTOs;

namespace FinalExercise.Services
{
    public interface ICommissionService
    {
        public Task<ServiceResponse> AddCommission(CommissionRequestDTO commissionRequest);

        public Task<IEnumerable<CommissionDTO>> GetCommissions();

        public Task<ServiceResponse> DeleteCommission(int id);
    }
}
