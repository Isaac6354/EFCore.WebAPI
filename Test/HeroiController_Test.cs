using EFCore.WebAPI.Controllers;
using System;
using System.Threading.Tasks;
using Xunit;

namespace EFCore.WebAPI.xUnitTest
{
    public class UsuariosController_Test
    {
        [Fact]
        public async void GerarListaHerois_Falha()
        {
            //Padrão AAA:
            //Arrange
            //Act
            var heroiController = new HeroiController();
            Func<Task> act = () => heroiController.GerarListaAsync();

            //Assert
            await Assert.ThrowsAsync<NullReferenceException>(act);

        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public void GerarListaHerois_Sucesso()
        {
            //Padrão AAA:
            //Arrange

            //Act
            var heroiController = new HeroiController();
            var lista = heroiController.GerarListaAsync().IsCompleted;

            //Assert
            Assert.True(lista);
        }

        //[Theory]
        //public void Test()
        //{
        //    //Padrão AAA:

        //    //Arrange

        //    //Act

        //    //Assert

        //}
    }
}