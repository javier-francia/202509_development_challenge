using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Helpers;
using DevelopmentChallenge.Data.Localizacion;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DevelopmentChallenge.Data
{
    public static class Process
    {
        public static string Imprimir(
            List<FormaGeometrica> formas,
            Idiomas idioma)
        {
            // Debería ir por inyección de dependencias
            var traduccionHelper = new TraduccionHelper(idioma);

            // No hay formas, devuelvo solo HEADER
            if (formas == null || formas.Count == 0)
            {
                return GeneracionContenidoHelper.ObtenerRespuestaListaVacia(traduccionHelper);
            }

            var sb = new StringBuilder();

            // HEADER
            sb.Append(GeneracionContenidoHelper.ObtenerHeader(traduccionHelper));

            // Agrupo por tipo de forma
            var agrupadoPorTipo = formas
                .GroupBy(FormasHelper.ObtenerTipoDeForma)
                .ToDictionary(
                    g => g.Key,
                    g => new
                    {
                        Cantidad = g.Count(),
                        Area = g.Sum(x => x.ObtenerArea()),
                        Perimetro = g.Sum(x => x.ObtenerPerimetro())
                    });

            // Por cada grupo, genero la linea con información
            foreach (var agg in agrupadoPorTipo)
            {
                sb.Append(GeneracionContenidoHelper.ObtenerInformacionDeForma(
                    traduccionHelper,
                    cantidad: agg.Value.Cantidad,
                    area: agg.Value.Area,
                    perimetro: agg.Value.Perimetro,
                    tipoForma: agg.Key));
            }

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

            var sumaPerimetros = agrupadoPorTipo.Sum(x => x.Value.Perimetro);
            var sumaAreas = agrupadoPorTipo.Sum(x => x.Value.Area);
            
            var textoTotalesFormas = traduccionHelper.Traducir(claveListaFormas, formas.Count.ToString());
            var textoSumaPerimetros = GeneracionContenidoHelper.ObtenerTextoPerimetro(traduccionHelper, sumaPerimetros);
            var textoSumaArea = GeneracionContenidoHelper.ObtenerTextoArea(traduccionHelper, sumaAreas);

            sb.Append($"{traduccionHelper.Traducir(ClavesRecursos.Terminos.TOTAL)}:<br/>");
            sb.Append($"{textoTotalesFormas} {textoSumaPerimetros} {textoSumaArea}");

            return sb.ToString();
        }
    }
}
