using MinimalApi.Dominio.Entidades;

namespace Test.Domain.Entidades
{
    [TestClass]
    public class AdministradorTest
    {
        [TestMethod]
        public void TestarGetSetPropriedades()
        {
            //Arrange & Act
            var adm = new Administrador()
            {
                Id = 1,
                Email = "teste@teste.com",
                Senha = "teste",
                Perfil = "Adm"
            };

            //Assert
            Assert.AreEqual(expected: 1, actual: adm.Id);
            Assert.AreEqual(expected: "teste@teste.com", actual: adm.Email);
            Assert.AreEqual(expected: "teste", actual: adm.Senha);
            Assert.AreEqual(expected: "Adm", actual: adm.Perfil);
        }
    }
}
