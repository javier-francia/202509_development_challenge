using DevelopmentChallenge.Data.Classes;
using System;

namespace DevelopmentChallenge.Data.Models
{
    public class Trapecio : FormaGeometrica
    {
        public decimal BaseMayor { get; }
        public decimal BaseMenor { get; }
        public decimal Altura { get; }
        public decimal LadoIzquierdo { get; }
        public decimal LadoDerecho { get; }

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal altura, decimal ladoIzquierdo, decimal ladoDerecho)
        {
            if (baseMayor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(baseMayor), "La base mayor debe ser mayor a cero.");
            }

            if (baseMenor <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(baseMenor), "La base menor debe ser mayor a cero.");
            }

            if (altura <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(altura), "La altura debe ser mayor a cero.");
            }

            if (ladoIzquierdo <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ladoIzquierdo), "El lado izquierdo debe ser mayor a cero.");
            }

            if (ladoDerecho <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(ladoDerecho), "El lado derecho debe ser mayor a cero.");
            }

            BaseMayor = baseMayor;
            BaseMenor = baseMenor;
            Altura = altura;
            LadoIzquierdo = ladoIzquierdo;
            LadoDerecho = ladoDerecho;
        }

        public override decimal ObtenerArea()
        {
            return (BaseMayor + BaseMenor) / 2m * Altura;
        }

        public override decimal ObtenerPerimetro()
        {
            return BaseMayor + BaseMenor + LadoIzquierdo + LadoDerecho;
        }
    }
}
