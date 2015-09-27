using System;

namespace ControllerSystems.DeusCumpre.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        public bool IsAdmin { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public bool IsValid
        {
            get
            {
                if (string.IsNullOrEmpty(Login))
                    throw new ArgumentNullException("Login", "Favor informar o login!");
                if (string.IsNullOrEmpty(Password))
                    throw new ArgumentNullException("Password", "Favor informar a senha!");
                return true;
            }
        }
    }
}