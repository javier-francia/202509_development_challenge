using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Localizacion;
using System.Globalization;

namespace DevelopmentChallenge.Data.Helpers
{
    /// <summary>
    /// Helper responsable de generar fragmentos de contenido (HTML) para el reporte:
    /// encabezado, mensaje de lista vacía, líneas por tipo de forma y textos de área/perímetro.
    /// No realiza cálculos; sólo formatea salidas a partir de datos ya agregados.
    /// </summary>
    public static class GeneracionContenidoHelper
    {
        /// <summary>
        /// Construye el encabezado del reporte en el idioma provisto.
        /// </summary>
        /// <param name="traduccionHelper">Helper de traducción.</param>
        /// <returns>Cadena HTML con la etiqueta H1 del reporte.</returns>
        public static string ObtenerHeader(TraduccionHelper traduccionHelper) => $"<h1>{traduccionHelper.Traducir(ClavesRecursos.Textos.LISTA_CABECERA)}</h1>";

        /// <summary>
        /// Construye el mensaje a mostrar cuando no hay formas para reportar.
        /// </summary>
        /// <param name="traduccionHelper">Helper de traducción.</param>
        /// <returns>Cadena HTML con la etiqueta H1 indicando que la lista está vacía.</returns>
        public static string ObtenerRespuestaListaVacia(TraduccionHelper traduccionHelper) => $"<h1>{traduccionHelper.Traducir(ClavesRecursos.Textos.LISTA_VACIA)}</h1>";

        /// <summary>
        /// Genera la línea de información (cantidad, área y perímetro) para un tipo de forma específico.
        /// Si la cantidad es 0, devuelve una cadena vacía (no se imprime línea).
        /// </summary>
        /// <param name="traduccionHelper">Helper de traducción.</param>
        /// <param name="cantidad">Cantidad de elementos del tipo indicado.</param>
        /// <param name="area">Área total agregada del tipo.</param>
        /// <param name="perimetro">Perímetro total agregado del tipo.</param>
        /// <param name="tipoForma">Tipo de forma al que corresponde la línea.</param>
        /// <returns>
        /// Cadena con el formato: <c>"{textoForma} | {textoArea} | {textoPerimetro}"</c>,
        /// o <see cref="string.Empty"/> si <paramref name="cantidad"/> es 0.
        /// </returns>
        public static string ObtenerInformacionDeForma(
            TraduccionHelper traduccionHelper,
            int cantidad,
            decimal area,
            decimal perimetro,
            TipoFormas tipoForma)
        {
            if (cantidad == 0)
            {
                return string.Empty;
            }

            var formaKey = FormasHelper.ObtenerClaveDeForma(tipoForma);

            if (cantidad == 1)
            {
                formaKey += ClavesRecursos.SUFIJO_SINGULAR;
            }
            else
            {
                formaKey += ClavesRecursos.SUFIJO_PLURAL;
            }

            var textoForma = traduccionHelper.Traducir(formaKey, cantidad.ToString());
            var textoArea = ObtenerTextoArea(traduccionHelper, area);
            var textoPerimetro = ObtenerTextoPerimetro(traduccionHelper, perimetro);

            return $"{textoForma} | {textoArea} | {textoPerimetro} <br/>";
        }

        /// <summary>
        /// Formatea el texto de área utilizando el recurso localizado y el formato numérico de la cultura actual.
        /// </summary>
        /// <param name="traduccionHelper">Helper de traducción.</param>
        /// <param name="area">Valor de área a imprimir.</param>
        /// <returns>Texto de área localizado.</returns>
        public static string ObtenerTextoArea(TraduccionHelper traduccionHelper, decimal area)
        {
            return traduccionHelper.Traducir(ClavesRecursos.Textos.AREA, area.ToString("#.##", CultureInfo.CurrentCulture));
        }

        /// <summary>
        /// Formatea el texto de perímetro utilizando el recurso localizado y el formato numérico de la cultura actual.
        /// </summary>
        /// <param name="traduccionHelper">Helper de traducción.</param>
        /// <param name="perimetro">Valor de perímetro a imprimir.</param>
        /// <returns>Texto de perímetro localizado.</returns>
        public static string ObtenerTextoPerimetro(TraduccionHelper traduccionHelper, decimal perimetro)
        {
            return traduccionHelper.Traducir(ClavesRecursos.Textos.PERIMETRO, perimetro.ToString("#.##", CultureInfo.CurrentCulture));
        }
    }
}
