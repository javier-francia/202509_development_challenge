using System.Collections.Generic;
using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Models;
using NUnit.Framework;
using System;
using DevelopmentChallenge.Data.Helpers;

namespace DevelopmentChallenge.Data.Tests
{
    [TestFixture]
    public class DataTests
    {
        [TestCase(Idiomas.Castellano, "<h1>Lista vacía de formas!</h1>")]
        [TestCase(Idiomas.Ingles, "<h1>Empty list of shapes!</h1>")]
        [TestCase(Idiomas.Italiano, "<h1>Lista vuota di forme!</h1>")]
        public void Dada_ListaVacia_Cuando_Imprimir_Entonces_MuestraEncabezadoCorrecto(Idiomas idioma, string esperado)
        {
            // Arrange
            var listaVacia = new List<FormaGeometrica>();

            // Act
            var resultado = Process.Imprimir(listaVacia, idioma);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestCase(Idiomas.Castellano, "<h1>Lista vacía de formas!</h1>")]
        [TestCase(Idiomas.Ingles, "<h1>Empty list of shapes!</h1>")]
        [TestCase(Idiomas.Italiano, "<h1>Lista vuota di forme!</h1>")]
        public void Dada_ListaNull_Cuando_Imprimir_Entonces_MuestraEncabezadoDeListaVacia(Idiomas idioma, string esperado)
        {
            // Arrange
            List<FormaGeometrica> formas = null;

            // Act
            var resultado = Process.Imprimir(formas, idioma);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestCase(
            Idiomas.Castellano,
            "<h1>Reporte de Formas</h1>1 Cuadrado | Área 25 | Perímetro 20 <br/>TOTAL:<br/>1 forma Perímetro 20 Área 25")]
        [TestCase(
            Idiomas.Ingles,
            "<h1>Shapes report</h1>1 Square | Area 25 | Perimeter 20 <br/>TOTAL:<br/>1 shape Perimeter 20 Area 25")]
        [TestCase(
            Idiomas.Italiano,
            "<h1>Report delle Forme</h1>1 Quadrato | Area 25 | Perimetro 20 <br/>TOTAL:<br/>1 forma Perimetro 20 Area 25")]
        public void Dado_UnCuadrado_Cuando_Imprimir_Entonces_ReporteCorrecto(Idiomas idioma, string esperadoCompleto)
        {
            // Arrange
            var formas = new List<FormaGeometrica> { new Cuadrado(5) };

            // Act
            var resultado = Process.Imprimir(formas, idioma);

            // Assert
            Assert.AreEqual(esperadoCompleto, resultado);
        }

        [TestCase(
            Idiomas.Castellano,
            "<h1>Reporte de Formas</h1>3 Cuadrados | Área 35 | Perímetro 36 <br/>TOTAL:<br/>3 formas Perímetro 36 Área 35")]
        [TestCase(
            Idiomas.Ingles,
            "<h1>Shapes report</h1>3 Squares | Area 35 | Perimeter 36 <br/>TOTAL:<br/>3 shapes Perimeter 36 Area 35")]
        [TestCase(
            Idiomas.Italiano,
            "<h1>Report delle Forme</h1>3 Quadrati | Area 35 | Perimetro 36 <br/>TOTAL:<br/>3 forme Perimetro 36 Area 35")]
        public void Dados_VariosCuadrados_Cuando_Imprimir_Entonces_ReporteCorrecto(Idiomas idioma, string esperadoCompleto)
        {
            // Arrange
            var formas = new List<FormaGeometrica>
            {
                new Cuadrado(5),
                new Cuadrado(1),
                new Cuadrado(3),
            };

            // Act
            var resultado = Process.Imprimir(formas, idioma);

            // Assert
            Assert.AreEqual(esperadoCompleto, resultado);
        }

        [TestCase(
            Idiomas.Castellano,
            "<h1>Reporte de Formas</h1>2 Cuadrados | Área 29 | Perímetro 28 <br/>2 Círculos | Área 13,01 | Perímetro 18,06 <br/>3 Triángulos | Área 49,64 | Perímetro 51,6 <br/>TOTAL:<br/>7 formas Perímetro 97,66 Área 91,65")]
        [TestCase(
            Idiomas.Ingles,
            "<h1>Shapes report</h1>2 Squares | Area 29 | Perimeter 28 <br/>2 Circles | Area 13,01 | Perimeter 18,06 <br/>3 Triangles | Area 49,64 | Perimeter 51,6 <br/>TOTAL:<br/>7 shapes Perimeter 97,66 Area 91,65")]
        [TestCase(
            Idiomas.Italiano,
            "<h1>Report delle Forme</h1>2 Quadrati | Area 29 | Perimetro 28 <br/>2 Cerchi | Area 13,01 | Perimetro 18,06 <br/>3 Triangoli | Area 49,64 | Perimetro 51,6 <br/>TOTAL:<br/>7 forme Perimetro 97,66 Area 91,65")]
        public void Dada_MezclaDeFormas_Cuando_Imprimir_Entonces_ReporteCorrecto(Idiomas idioma, string esperadoCompleto)
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

            // Act
            var resultado = Process.Imprimir(formas, idioma);

            // Assert
            Assert.AreEqual(esperadoCompleto, resultado);
        }

        [TestCase(Idiomas.Castellano, "<h1>Reporte de Formas</h1>1 Cuadrado | Área 1 | Perímetro 4 <br/>TOTAL:<br/>1 forma Perímetro 4 Área 1")]
        [TestCase(Idiomas.Ingles, "<h1>Shapes report</h1>1 Square | Area 1 | Perimeter 4 <br/>TOTAL:<br/>1 shape Perimeter 4 Area 1")]
        [TestCase(Idiomas.Italiano, "<h1>Report delle Forme</h1>1 Quadrato | Area 1 | Perimetro 4 <br/>TOTAL:<br/>1 forma Perimetro 4 Area 1")]
        public void Dada_UnaSolaForma_Cuando_Imprimir_Entonces_ReporteCorrecto(Idiomas idioma, string esperado)
        {
            // Arrange
            var formas = new List<FormaGeometrica> { new Cuadrado(1) };

            // Act
            var resultado = Process.Imprimir(formas, idioma);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestCase(Idiomas.Castellano, "<h1>Reporte de Formas</h1>2 Cuadrados | Área 2 | Perímetro 8 <br/>TOTAL:<br/>2 formas Perímetro 8 Área 2")]
        [TestCase(Idiomas.Ingles, "<h1>Shapes report</h1>2 Squares | Area 2 | Perimeter 8 <br/>TOTAL:<br/>2 shapes Perimeter 8 Area 2")]
        [TestCase(Idiomas.Italiano, "<h1>Report delle Forme</h1>2 Quadrati | Area 2 | Perimetro 8 <br/>TOTAL:<br/>2 forme Perimetro 8 Area 2")]
        public void Dadas_MultiplesFormas_Cuando_Imprimir_Entonces_ReporteCorrecto(Idiomas idioma, string esperado)
        {
            // Arrange
            var formas = new List<FormaGeometrica> { new Cuadrado(1), new Cuadrado(1) };

            // Act
            var resultado = Process.Imprimir(formas, idioma);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        private class FormaDesconocida : FormaGeometrica
        {
            public override decimal ObtenerArea()
            {
                return 0m;
            }

            public override decimal ObtenerPerimetro()
            {
                return 0m;
            }
        }

        [TestCase(Idiomas.Castellano)]
        [TestCase(Idiomas.Ingles)]
        [TestCase(Idiomas.Italiano)]
        public void Dada_FormaDesconocida_Cuando_Imprimir_Entonces_LanzaArgumentOutOfRange(Idiomas idioma)
        {
            // Arrange
            var formas = new List<FormaGeometrica> { new FormaDesconocida() };

            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Process.Imprimir(formas, idioma);
            });
        }

        [TestCase(Idiomas.Castellano)]
        [TestCase(Idiomas.Ingles)]
        [TestCase(Idiomas.Italiano)]
        public void Dada_ClaveDeRecursoVacia_Cuando_Traducir_Entonces_LanzaArgumentException(Idiomas idioma)
        {
            // Arrange
            var helper = new TraduccionHelper(idioma);

            // Act + Assert
            Assert.Throws<ArgumentException>(() =>
            {
                helper.Traducir(string.Empty);
            });
        }

        [TestCase(Idiomas.Castellano)]
        [TestCase(Idiomas.Ingles)]
        [TestCase(Idiomas.Italiano)]
        public void Dada_ClaveDeRecursoInexistente_Cuando_Traducir_Entonces_LanzaKeyNotFoundException(Idiomas idioma)
        {
            // Arrange
            var t = new TraduccionHelper(idioma);

            // Act + Assert
            Assert.Throws<KeyNotFoundException>(() =>
            {
                t.Traducir("CLAVE_QUE_NO_EXISTE");
            });
        }

        [TestCase(
            Idiomas.Castellano,
            "<h1>Reporte de Formas</h1>2 Rectángulos | Área 15,75 | Perímetro 22 <br/>TOTAL:<br/>2 formas Perímetro 22 Área 15,75")]
        [TestCase(
            Idiomas.Ingles,
            "<h1>Shapes report</h1>2 Rectangles | Area 15,75 | Perimeter 22 <br/>TOTAL:<br/>2 shapes Perimeter 22 Area 15,75")]
        [TestCase(
            Idiomas.Italiano,
            "<h1>Report delle Forme</h1>2 Rettangoli | Area 15,75 | Perimetro 22 <br/>TOTAL:<br/>2 forme Perimetro 22 Area 15,75")]
        public void Dado_Rectangulos_Cuando_Imprimir_Entonces_LineaYTotalesCorrectos(Idiomas idioma, string esperado)
        {
            // Arrange
            var formas = new List<FormaGeometrica>
            {
                new Rectangulo(3m, 4m),
                new Rectangulo(2.5m, 1.5m)
            };

            // Act
            var resultado = Process.Imprimir(formas, idioma);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

        [TestCase(
            Idiomas.Castellano,
            "<h1>Reporte de Formas</h1>1 Trapecio | Área 32 | Perímetro 26 <br/>TOTAL:<br/>1 forma Perímetro 26 Área 32")]
        [TestCase(
            Idiomas.Ingles,
            "<h1>Shapes report</h1>1 Trapezoid | Area 32 | Perimeter 26 <br/>TOTAL:<br/>1 shape Perimeter 26 Area 32")]
        [TestCase(
            Idiomas.Italiano,
            "<h1>Report delle Forme</h1>1 Trapezio | Area 32 | Perimetro 26 <br/>TOTAL:<br/>1 forma Perimetro 26 Area 32")]
        public void Dado_Trapecio_Cuando_Imprimir_Entonces_LineaYTotalesCorrectos(Idiomas idioma, string esperado)
        {
            // Arrange
            var formas = new List<FormaGeometrica>
            {
                new Trapecio(10, 6, 4, 5, 5)
            };

            // Act
            var resultado = Process.Imprimir(formas, idioma);

            // Assert
            Assert.AreEqual(esperado, resultado);
        }

    }
}
