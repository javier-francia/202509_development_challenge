using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Helpers;
using DevelopmentChallenge.Data.Localizacion;
using DevelopmentChallenge.Data.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace DevelopmentChallenge.Data
{
    /******************************************************************************************************************/
    /******* ¿Qué pasa si debemos soportar un nuevo idioma para los reportes, o agregar más formas geométricas? *******/
    /******************************************************************************************************************/

    /*
     * TODO: 
     * Refactorizar la clase para respetar principios de la programación orientada a objetos.
     * Implementar la forma Trapecio/Rectangulo. 
     * Agregar el idioma Italiano (o el deseado) al reporte.
     * Se agradece la inclusión de nuevos tests unitarios para validar el comportamiento de la nueva funcionalidad agregada (los tests deben pasar correctamente al entregar la solución, incluso los actuales.)
     * Una vez finalizado, hay que subir el código a un repo GIT y ofrecernos la URL para que podamos utilizar la nueva versión :).
     */

    public static class Process
    {
        public static TraduccionHelper traduccionHelper;

        public static string Imprimir(
            List<FormaGeometrica> formas,
            Idiomas idioma)
        {
            traduccionHelper = new TraduccionHelper(idioma);

            // No hay formas, devuelvo solo HEADER
            if (formas.Count == 0)
            {
                return ObtenerRespuestaSinFormas();
            }

            var sb = new StringBuilder();

            // HEADER

            sb.Append(ObtenerHeader());

            var countCuadrados = 0;
            var countCirculos = 0;
            var countTriangulos = 0;

            var areaCuadrados = 0m;
            var areaCirculos = 0m;
            var areaTriangulos = 0m;

            var perimetroCuadrados = 0m;
            var perimetroCirculos = 0m;
            var perimetroTriangulos = 0m;

            foreach (var forma in formas)
            {
                if (forma is Cuadrado)
                {
                    countCuadrados++;
                    areaCuadrados += forma.ObtenerArea();
                    perimetroCuadrados += forma.ObtenerPerimetro();
                }
                else if (forma is Circulo)
                {
                    countCirculos++;
                    areaCirculos += forma.ObtenerArea();
                    perimetroCirculos += forma.ObtenerPerimetro();
                }
                else if (forma is TrianguloEquilatero)
                {
                    countTriangulos++;
                    areaTriangulos += forma.ObtenerArea();
                    perimetroTriangulos += forma.ObtenerPerimetro();
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Forma desconocida");
                }    
            }

            var lineaCuadrados = ObtenerLineaAreaPerimetro(countCuadrados, areaCuadrados, perimetroCuadrados, TipoFormas.Cuadrado);
            var lineaCirculos = ObtenerLineaAreaPerimetro(countCirculos, areaCirculos, perimetroCirculos, TipoFormas.Circulo);
            var lineaTriangulos = ObtenerLineaAreaPerimetro(countTriangulos, areaTriangulos, perimetroTriangulos, TipoFormas.TrianguloEquilatero);

            sb.Append(lineaCuadrados);
            sb.Append(lineaCirculos);
            sb.Append(lineaTriangulos);

            // FOOTER
            var claveListaFormas = ClavesRecursos.Formas.FORMA;

            if (formas.Count == 1)
            {
                claveListaFormas += ClavesRecursos.SUFIJO_SINGULAR;
            }
            else
            {
                claveListaFormas += ClavesRecursos.SUFIJO_PLURAL;
            }

            var lineaTotalesFormas = traduccionHelper.Traducir(claveListaFormas, formas.Count.ToString());
            
            var sumaPerimetros = perimetroCuadrados + perimetroTriangulos + perimetroCirculos;
            var sumaAreas = areaCuadrados + areaCirculos + areaTriangulos;

            sb.Append($"{traduccionHelper.Traducir(ClavesRecursos.Terminos.TOTAL)}:<br/>");
            sb.Append($"{lineaTotalesFormas} {ObtenerTextoPerimetro(sumaPerimetros)} {ObtenerTextoArea(sumaAreas)}");

            return sb.ToString();
        }

        private static string ObtenerHeader()
        {
            return $"<h1>{traduccionHelper.Traducir(ClavesRecursos.Textos.LISTA_CABECERA)}</h1>";
        }

        private static string ObtenerRespuestaSinFormas()
        {
            return $"<h1>{traduccionHelper.Traducir(ClavesRecursos.Textos.LISTA_VACIA)}</h1>";
        }

        private static string ObtenerLineaAreaPerimetro(
            int cantidad,
            decimal area,
            decimal perimetro,
            TipoFormas tipoForma)
        {
            if (cantidad == 0)
            {
                return string.Empty;
            }

            var formaKey = string.Empty;

            switch (tipoForma)
            {
                case TipoFormas.Circulo:
                    formaKey = ClavesRecursos.Formas.CIRCULO;
                    break;
                case TipoFormas.Cuadrado:
                    formaKey = ClavesRecursos.Formas.CUADRADO;
                    break;
                case TipoFormas.TrianguloEquilatero:
                    formaKey = ClavesRecursos.Formas.TRIANGULO;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Forma desconocida");
            }

            if (cantidad == 1)
            {
                formaKey += ClavesRecursos.SUFIJO_SINGULAR;
            }
            else
            {
                formaKey += ClavesRecursos.SUFIJO_PLURAL;
            }

            var textoForma = traduccionHelper.Traducir(formaKey, cantidad.ToString());
            var textoArea = ObtenerTextoArea(area);
            var textoPerimetro = ObtenerTextoPerimetro(perimetro);

            return $"{textoForma} | {textoArea} | {textoPerimetro} <br/>";
        }

        private static string ObtenerTextoArea(decimal area)
        {
            return traduccionHelper.Traducir(ClavesRecursos.Textos.AREA, area.ToString("#.##", CultureInfo.CurrentCulture));
        }

        private static string ObtenerTextoPerimetro(decimal perimetro)
        {
            return traduccionHelper.Traducir(ClavesRecursos.Textos.PERIMETRO, perimetro.ToString("#.##", CultureInfo.CurrentCulture));
        }
    }
}
