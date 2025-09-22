using DevelopmentChallenge.Data.Classes;
using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Localizacion;
using DevelopmentChallenge.Data.Models;
using System;

namespace DevelopmentChallenge.Data.Helpers
{
    /// <summary>
    /// Helper de utilidades para mapear instancias de formas a su tipo lógico
    /// y para resolver la clave de localización asociada a cada tipo de forma.
    /// </summary>
    public static class FormasHelper
    {
        /// <summary>
        /// Obtiene el <see cref="TipoFormas"/> correspondiente a la instancia concreta de <see cref="FormaGeometrica"/>.
        /// </summary>
        /// <param name="forma">Instancia de la forma geométrica (por ejemplo, <c>Cuadrado</c>, <c>Circulo</c>, etc.).</param>
        /// <returns>
        /// El valor de <see cref="TipoFormas"/> que representa el tipo lógico de la forma provista.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza cuando la instancia no coincide con ninguno de los tipos conocidos
        /// </exception>
        public static TipoFormas ObtenerTipoDeForma(FormaGeometrica forma)
        {
            if (forma is Cuadrado) return TipoFormas.Cuadrado;
            if (forma is Circulo) return TipoFormas.Circulo;
            if (forma is TrianguloEquilatero) return TipoFormas.TrianguloEquilatero;
            if (forma is Rectangulo) return TipoFormas.Rectangulo;
            if (forma is Trapecio) return TipoFormas.Trapecio;

            throw new ArgumentOutOfRangeException("Forma desconocida");
        }

        /// <summary>
        /// Devuelve la clave de recurso (i18n) asociada al <see cref="TipoFormas"/> indicado.
        /// Esta clave se utiliza para obtener los textos localizados (singular/plural) desde los archivos <c>.resx</c>.
        /// </summary>
        /// <param name="tipoForma">Tipo de forma para el cual se desea obtener la clave de recurso.</param>
        /// <returns>
        /// La clave de recurso definida en <see cref="ClavesRecursos.Formas"/> correspondiente al tipo indicado.
        /// </returns>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Se lanza cuando el tipo recibido no está soportado.
        /// </exception>
        public static string ObtenerClaveDeForma(TipoFormas tipoForma)
        {
            switch (tipoForma)
            {
                case TipoFormas.Circulo:
                    return ClavesRecursos.Formas.CIRCULO;
                case TipoFormas.Cuadrado:
                    return ClavesRecursos.Formas.CUADRADO;
                case TipoFormas.TrianguloEquilatero:
                    return ClavesRecursos.Formas.TRIANGULO;
                case TipoFormas.Rectangulo:
                    return ClavesRecursos.Formas.RECTANGULO;
                case TipoFormas.Trapecio:
                    return ClavesRecursos.Formas.TRAPECIO;
                default:
                    throw new ArgumentOutOfRangeException("Forma desconocida");
            }
        }
    }
}
