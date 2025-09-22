using DevelopmentChallenge.Data.Enums;
using DevelopmentChallenge.Data.Localizacion;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using System.Threading;

namespace DevelopmentChallenge.Data.Helpers
{
    public class TraduccionHelper
    {
        private static readonly ResourceManager _rm = Recursos.ResourceManager;

        public TraduccionHelper(Idiomas idioma)
        {
            CambiarCulturaUi(idioma);
        }

        /// <summary>
        /// Permite cambiar la cultura UI actual.
        /// Si preferís un enum de Idioma, podés mapearlo a CultureInfo acá.
        /// </summary>
        public static void CambiarCulturaUi(Idiomas idioma)
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

        public string Traducir(string clave)
        {
            return TraducirConArgs(clave, args: null);
        }

        public string Traducir(string clave, string valor)
        {
            return TraducirConArgs(clave, new[] { valor });
        }

        public string Traducir(string clave, string valor1, string valor2)
        {
            return TraducirConArgs(clave, new[] { valor1, valor2 });
        }

        /// <summary>
        /// Devuelve el string localizado para la clave indicada y aplica string.Format con los argumentos.
        /// </summary>
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
