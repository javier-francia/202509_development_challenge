using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Models;
using NUnit.Framework;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [Test]
        public void TestResumenListaVacia()
        {
            // Arrange
            var listaVacia = new List<FormaGeometrica>();

            // Act
            var resultado = Process.Imprimir(listaVacia, Idiomas.Castellano);
            
            // Assert
            Assert.AreEqual("<h1>Lista vacía de formas!</h1>", resultado);
        }

        [Test]
        public void TestResumenListaVaciaFormasEnIngles()
        {
            // Arrange
            var listaVacia = new List<FormaGeometrica>();

            // Act
            var resultado = Process.Imprimir(listaVacia, Idiomas.Ingles);

            // Assert
            Assert.AreEqual("<h1>Empty list of shapes!</h1>", resultado);
        }

        [Test]
        public void TestResumenListaConUnCuadrado()
        {
            // Arrange
            var formas = new List<FormaGeometrica> {new Cuadrado(5)};
            var resultadoEsperado = "<h1>Reporte de Formas</h1>1 Cuadrado | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 forma Perimetro 20 Area 25";
            // Act
            var resultado = Process.Imprimir(formas, Idiomas.Castellano);

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [Test]
        public void TestResumenListaConMasCuadrados()
        {
            // Arrange
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3),
            };

            var resultadoEsperado = "<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35";

            // Act
            var resultado = Process.Imprimir(formas, Idiomas.Ingles);

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [Test]
        public void TestResumenListaConMasTipos()
        {
            // Arrange
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
            };

            var resultadoEsperado = "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65";

            // Act
            var resultado = Process.Imprimir(formas, Idiomas.Ingles);

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }

        [Test]
        public void TestResumenListaConMasTiposEnCastellano()
        {
            // Arrange
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Circulo(3),
                new TrianguloEquilatero(4),
                new Cuadrado(2),
                new TrianguloEquilatero(9),
                new Circulo(2.75m),
                new TrianguloEquilatero(4.2m),
            };
            
            var resultadoEsperado = "<h1>Reporte de Formas</h1>2 Cuadrados | Area 29 | Perimetro 28 <br/>2 Círculos | Area 13,01 | Perimetro 18,06 <br/>3 Triángulos | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 formas Perimetro 97,66 Area 91,65";

            // Act
            var resultado = Process.Imprimir(formas, Idiomas.Castellano);

            // Assert
            Assert.AreEqual(resultadoEsperado, resultado);
        }
    }
}
