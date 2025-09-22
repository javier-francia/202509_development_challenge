namespace DevelopmentChallenge.Data.Classes
{
    /// <summary>
    /// Clase base abstracta para todas las formas geométricas del sistema.
    /// Define la interfaz mínima que deben implementar las figuras concretas
    /// (por ejemplo: <see cref="Cuadrado"/>, <see cref="Circulo"/>, <see cref="TrianguloEquilatero"/>, etc.).
    /// </summary>
    public abstract class FormaGeometrica
    {
        /// <summary>
        /// Calcula el área de la forma geométrica.
        /// </summary>
        /// <returns>Área de la figura.</returns>
        public abstract decimal ObtenerArea();

        /// <summary>
        /// Calcula el perímetro de la forma geométrica.
        /// </summary>
        /// <returns>Perímetro de la figura.</returns>
        public abstract decimal ObtenerPerimetro();
    }
}
