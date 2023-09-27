using Azure;
using InfucareRx.PatientHealthApp.Database.Entity;
using InfucareRx.PatientHealthApp.DTO;
using InfucareRx.PatientHealthApp.Repository.Interfaces;
using InfucareRx.PatientHealthApp.Serivces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfucareRx.PatientHealthApp.Serivces.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            this._userRepository = userRepository;
        }

        public ResponseModel<UserDTO> AddUser(UserDTO user)
        {
            var response = new ResponseModel<UserDTO>();
            User entity = new User();
            entity.FirstName = user.FirstName;
            entity.LastName = user.LastName;
            entity.Email = user.Email;
            entity.Address = user.Address;
            _userRepository.Add(entity);
            if (entity.Id != Guid.Empty)
            {
                response.Success = true;
                response.Message = "User added successfully";
            }
            else
            {
                response.Message = "Something wrong when create new user.";
            }
            return (response);
        }

        public async Task<ResponseModel<List<UserDTO>>> GetAllAsync()
        {
            var response = new ResponseModel<List<UserDTO>>();

            var users = await _userRepository.GetAllAsync();
            if (users != null)
            {
                response.Date = users.ToList().Select(x => new UserDTO
                {
                    Address = x.Address,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Email = x.Email,
                    City = x.City,
                }).ToList();
            }
            response.Success = true;
            return (response);
        }

        public async Task<ResponseModel<UserDTO>> GetByIdAsync(Guid id)
        {
            var response = new ResponseModel<UserDTO>();
            var user = await _userRepository.GetByIdAsync(id);
            if (user != null)
            {
                response.Success = true;
                response.Date = new UserDTO { Id = user.Id, Address = user.Address, City = user.City, LastName = user.LastName, Email = user.Email, FirstName = user.FirstName };
            }
            return (response);
        }
    }
}
