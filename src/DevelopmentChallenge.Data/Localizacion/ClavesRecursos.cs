namespace DevelopmentChallenge.Data.Localizacion
{
    /// <summary>
    /// Catálogo centralizado de claves de recursos de localización (.resx).
    /// Evita errores tipográficos al acceder a los textos traducidos y
    /// facilita el descubrimiento de claves disponibles en el proyecto.
    /// </summary>
    public static class ClavesRecursos
    {
        /// <summary>
        /// Sufijo que se concatena a una clave base para solicitar su versión en singular.
        /// Por ejemplo: <c>CIRCULO</c> + <c>_SINGULAR</c> ⇒ <c>CIRCULO_SINGULAR</c>.
        /// </summary>
        public const string SUFIJO_SINGULAR = "_SINGULAR";

        /// <summary>
        /// Sufijo que se concatena a una clave base para solicitar su versión en plural.
        /// Por ejemplo: <c>CIRCULO</c> + <c>_PLURAL</c> ⇒ <c>CIRCULO_PLURAL</c>.
        /// </summary>
        public const string SUFIJO_PLURAL = "_PLURAL";

        /// <summary>
        /// Claves de recursos asociadas a nombres de formas geométricas.
        /// Las variantes singular/plural se obtienen concatenando los sufijos correspondientes.
        /// </summary>
        public static class Formas
        {
            public const string FORMA = "FORMA";
            public const string CIRCULO = "CIRCULO";
            public const string CUADRADO = "CUADRADO";
            public const string TRIANGULO = "TRIANGULO";
            public const string TRAPECIO = "TRAPECIO";
            public const string RECTANGULO = "RECTANGULO";
        }

        /// <summary>
        /// Claves de recursos para textos del reporte (encabezados, etiquetas, etc.).
        /// </summary>
        public static class Textos
        {
            /// <summary>
            /// Texto de encabezado de lista con elementos.
            /// </summary>
            public const string LISTA_CABECERA = "LISTA_CABECERA";

            /// <summary>
            /// Texto de encabezado para lista vacía.
            /// </summary>
            public const string LISTA_VACIA = "LISTA_VACIA";

            /// <summary>
            /// Etiqueta para área formateada.
            /// </summary>
            public const string AREA = "AREA";

            /// <summary>
            /// Etiqueta para perímetro formateado.
            /// </summary>
            public const string PERIMETRO = "PERIMETRO";
        }

        /// <summary>
        /// Claves de recursos para términos sueltos usados en el reporte.
        /// </summary>
        public static class Terminos
        {
            /// <summary>
            /// Término "TOTAL" utilizado en el pie del reporte.
            /// </summary>
            public const string TOTAL = "TOTAL";
        }
    }
}
