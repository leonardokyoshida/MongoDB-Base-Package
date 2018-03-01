using System;
using System.Collections.Generic;
using System.Text;

namespace MongoDB.Test.IntegrationTest
{
    public class Usuario
    {
        public Usuario(string nome, string sobrenome, string login, string senha, string email)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            Login = login;
            Senha = senha;
            Email = email;
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }
    }

}
