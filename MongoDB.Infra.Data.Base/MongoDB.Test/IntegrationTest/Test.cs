using Xunit;

namespace MongoDB.Test.IntegrationTest
{
    public class Test
    {       
        [Fact]
        public async void test()
        {
            Usuario usuario = new Usuario("Vinicius", "Escorcio", "ViniciusE", "1234@AAA", "viniciusefelix@gmail.com");
            DataContext dataContext = new DataContext("Cadastro");
            UsuarioRepository usuarioRepository = new UsuarioRepository("Usuario", dataContext);

            await usuarioRepository.Create(usuario);
        }
    }
}
