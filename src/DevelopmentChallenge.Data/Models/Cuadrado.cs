using DevelopmentChallenge.Data.Classes;
using System;

namespace DevelopmentChallenge.Data.Models
{
    public class Cuadrado : FormaGeometrica
    {
        public decimal Lado { get; set; }

        public Cuadrado(decimal lado)
        {
            if (lado <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(lado), "El lado debe ser mayor a cero.");
            }

            Lado = lado;
        }

        public override decimal ObtenerArea()
        {
            return Lado * Lado;
        }

        public override decimal ObtenerPerimetro()
        {
            return Lado * 4;
        }
    }
}
