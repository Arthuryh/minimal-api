using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MinimalApi.Dominio.Entidades;
using MinimalApi.Dominio.Servicos;
using MinimalApi.Infraestrutura.Db;

namespace Test.Domain.Servicos
{
    [TestClass]
    public class AdministradorServicoTest
    {
        private DbContexto CriarContextoDeTeste()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();

            var configuration = builder.Build();

            return new DbContexto(configuration);
        }



        [TestMethod]
        public void SalvarAdministradorTest()
        {
            //Arrange
            var context = CriarContextoDeTeste();
            context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

            var adm = new Administrador()
            {
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            var administradorServico = new AdministradorServico(context);

            // Act
            administradorServico.Incluir(adm);

            //Assert
            Assert.AreEqual(expected: 1, actual: administradorServico.Todos(1).Count);
        }
    }
}
