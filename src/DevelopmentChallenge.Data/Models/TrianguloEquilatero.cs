using DevelopmentChallenge.Data.Classes;
using System;

namespace DevelopmentChallenge.Data.Models
{
    public class TrianguloEquilatero : FormaGeometrica
    {
        public decimal Lado { get; set; }

        public TrianguloEquilatero(decimal lado)
        {
            if (lado <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lado), "El lado debe ser mayor a cero.");
            }

            Lado = lado;
        }

        public override decimal ObtenerArea()
        {
            return Lado * Lado * (decimal)Math.Sqrt(3) / 4;
        }

        public override decimal ObtenerPerimetro()
        {
            return Lado * 3;
        }
    }
}
