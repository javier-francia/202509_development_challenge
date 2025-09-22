using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Localizacion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace DevelopmentChallenge.Data.Helpers
{
    /// <summary>
    /// Helper de traducción para obtener textos localizados desde recursos <c>.resx</c>.
    /// Controla la <see cref="Thread.CurrentThread.CurrentUICulture"/> según el <see cref="Idiomas"/> elegido
    /// y expone métodos de conveniencia para formatear cadenas con parámetros.
    /// </summary>
    public class TraduccionHelper
    {
        /// <summary>
        /// Administrador de recursos generado por la clase <c>Recursos</c>.
        /// </summary>
        private static readonly ResourceManager _rm = Recursos.ResourceManager;

        /// <summary>
        /// Crea una nueva instancia configurando la cultura UI según el idioma indicado.
        /// </summary>
        /// <param name="idioma">Idioma a utilizar para la obtención de recursos.</param>
        public TraduccionHelper(Idiomas idioma)
        {
            CambiarIdiomaCulturaUi(idioma);
        }

        /// <summary>
        /// Cambia el idioma de la cultura de interfaz de usuario (<see cref="Thread.CurrentThread.CurrentUICulture"/>) a partir del enum de <see cref="Idiomas"/>.
        /// </summary>
        /// <param name="idioma">Idioma deseado.</param>
        public static void CambiarIdiomaCulturaUi(Idiomas idioma)
        {
            var codigoCultura = string.Empty;

            switch (idioma)
            {
                case Idiomas.Castellano:
                    codigoCultura = "es";
                    break;
                case Idiomas.Italiano:
                    codigoCultura = "it";
                    break;
                case Idiomas.Ingles:
                default:
                    codigoCultura = "en";
                    break;
            }

            Thread.CurrentThread.CurrentUICulture = new CultureInfo(codigoCultura);
        }

        /// <summary>
        /// Traduce una clave sin parámetros.
        /// </summary>
        /// <param name="clave">Clave de recurso a buscar.</param>
        /// <returns>Texto localizado correspondiente a la clave.</returns>
        /// <exception cref="ArgumentException">Si la clave es nula o vacía.</exception>
        /// <exception cref="KeyNotFoundException">Si no existe un recurso para la clave en la cultura actual.</exception>

        public string Traducir(string clave)
        {
            return TraducirConArgs(clave, args: null);
        }

        /// <summary>
        /// Traduce una clave aplicando un parámetro de formato.
        /// </summary>
        /// <param name="clave">Clave de recurso a buscar.</param>
        /// <param name="valor">Valor a inyectar en <c>{0}</c>.</param>
        /// <returns>Texto localizado formateado.</returns>
        /// <exception cref="ArgumentException">Si la clave es nula o vacía.</exception>
        /// <exception cref="KeyNotFoundException">Si no existe un recurso para la clave en la cultura actual.</exception>
        public string Traducir(string clave, string valor)
        {
            return TraducirConArgs(clave, new[] { valor });
        }

        /// <summary>
        /// Obtiene el recurso asociado a la clave y aplica <see cref="string.Format(IFormatProvider, string, object[])"/>
        /// con la cultura actual del hilo para formatear los argumentos provistos.
        /// </summary>
        /// <param name="clave">Clave de recurso a buscar.</param>
        /// <param name="args">Argumentos opcionales para formatear el texto (puede ser <c>null</c> o vacío).</param>
        /// <returns>Texto localizado (formateado si se proveyeron argumentos).</returns>
        /// <exception cref="ArgumentException">Si la clave es nula o vacía.</exception>
        /// <exception cref="KeyNotFoundException">Si no existe un recurso para la clave en la cultura actual.</exception>
        private string TraducirConArgs(string clave, params object[] args)
        {
            if (string.IsNullOrWhiteSpace(clave))
            {
                throw new ArgumentException("La clave de recurso no puede ser nula o vacía.", nameof(clave));
            }

            string valorObtenido = _rm.GetString(clave, CultureInfo.CurrentUICulture) ?? throw new KeyNotFoundException("No existe el recurso de localización buscado.");

            if (args == null || args.Length == 0)
            {
                return valorObtenido;
            }

            return string.Format(CultureInfo.CurrentCulture, valorObtenido, args);
        }
    }
}
