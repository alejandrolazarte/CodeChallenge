using CodeChallenge.Data.Model;
using CodeChallenge.Data.Model.Extensions;
using CodeChallenge.Services.Contracts;
using System;

namespace CodeChallenge.Services
{
    public class CalcularAlimentoReptilServicio : ICalcularAlimentoPorTipoAnimalServicio
    {

        public bool EsTipo(Animal animal) => animal.EsReptil();
        public double CalcularAlimentoPorDia(Animal animal) => (animal.Peso * animal.Porcentaje) / 7;
        public double CalcularAlimentoParaElMes(Animal animal)
        {
            var reptil = (Reptil)animal;
            var total = CalcularAlimentoPorDia(reptil) * DiasDelMes - DiasQueNoCome(reptil);
            return total;
        }

        private double DiasQueNoCome(Reptil reptil)
        {
            if (reptil.CantidadDiasCambioPiel <= 31)
                return ((double)reptil.CantidadDiasCambioPiel / DiasDelMes + reptil.CantidadDiasCambioPiel % DiasDelMes) *
                   CalcularAlimentoPorDia(reptil);

            return 3 * CalcularAlimentoPorDia(reptil);
        }
        private static int DiasDelMes => DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
    }
}
