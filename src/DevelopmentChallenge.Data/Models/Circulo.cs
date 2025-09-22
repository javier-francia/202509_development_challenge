using DevelopmentChallenge.Data.Classes;
using System;

namespace DevelopmentChallenge.Data.Models
{
    public class Circulo : FormaGeometrica
    {
        public decimal Diametro { get; set; }

        public Circulo(decimal diametro)
        {
            if (diametro <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(diametro), "El diámetro debe ser mayor a cero.");
            }

            Diametro = diametro;
        }

        public override decimal ObtenerArea()
        {
            return (decimal)Math.PI * (Diametro / 2) * (Diametro / 2);
        }

        public override decimal ObtenerPerimetro()
        {
            return (decimal)Math.PI * Diametro;
        }
    }
}
