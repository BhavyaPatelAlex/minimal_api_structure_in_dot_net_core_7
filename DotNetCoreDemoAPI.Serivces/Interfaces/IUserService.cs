using Azure;
using InfucareRx.PatientHealthApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfucareRx.PatientHealthApp.Serivces.Interfaces
{
    public interface IUserService
    {
        Task<ResponseModel<List<UserDTO>>> GetAllAsync();
        Task<ResponseModel<UserDTO>> GetByIdAsync(Guid id);
        ResponseModel<UserDTO> AddUser(UserDTO user);
    }
}
