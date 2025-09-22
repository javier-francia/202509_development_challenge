using DevelopmentChallenge.Data.Classes;
using System;

namespace DevelopmentChallenge.Data.Models
{
    public class Rectangulo : FormaGeometrica
    {
        public decimal Ancho { get; }
        public decimal Alto { get; }

        public Rectangulo(decimal ancho, decimal alto)
        {
            if (ancho <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ancho), "El ancho debe ser mayor a cero.");
            }

            if (alto <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(alto), "El alto debe ser mayor a cero.");
            }

            Ancho = ancho;
            Alto = alto;
        }

        public override decimal ObtenerArea()
        {
            return Ancho * Alto;
        }

        public override decimal ObtenerPerimetro()
        {
            return 2m * (Ancho + Alto);
        }
    }
}
