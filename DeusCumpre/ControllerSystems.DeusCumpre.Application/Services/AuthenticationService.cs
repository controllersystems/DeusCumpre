using ControllerSystems.DeusCumpre.Application.DataTransferObjects;
using ControllerSystems.DeusCumpre.Application.Interfaces.Repositories;
using ControllerSystems.DeusCumpre.Application.Interfaces.Services;
using ControllerSystems.DeusCumpre.Domain.Entities;
using System;

namespace ControllerSystems.DeusCumpre.Application.Services
{
    public class AuthenticationService: IAuthenticationService
    {
        private readonly IUserRepository iUserRepository;

        public AuthenticationService(IUserRepository iUserRepository)
        {
            this.iUserRepository = iUserRepository;
        }

        public bool LogIn(string login, string password)
        {
            User user = new User()
            {
                Login = login,
                Password = password
            };

            if (user.IsValid)
            {
                var userDto = iUserRepository.Get(user.Login);
                if (userDto == null)
                    return false;
                return (userDto.Password == user.Password);
            }
            else
            {
                return false;
            }
        }

        public void LogOut()
        {
            throw new System.NotImplementedException();
        }

        public bool Create(UserDto userDto)
        {
            User user = new User()
            {
                Login = userDto.Login,
                Password = userDto.Password,
                IsAdmin = userDto.IsAdmin
            };

            if (user.IsValid)
            {
                var exists = iUserRepository.Exists(user.Login);
                if (exists)
                {
                    throw new ArgumentException("Já existe um usuário com esse login!", "Login");
                }
                else
                {
                    iUserRepository.Add(userDto);
                    return true;
                }
            }
            return false;
        }

        public bool Exists(string login)
        {
            return iUserRepository.Exists(login);
        }
    }
}