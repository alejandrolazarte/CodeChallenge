using System;
using CodeChallenge.Data.Model;
using CodeChallenge.Data.Model.Extensions;
using CodeChallenge.Services.Contracts;

namespace CodeChallenge.Services
{
    public class CalcularAlimentoHervivoroServicio : ICalcularAlimentoPorTipoAnimalServicio
    {
        public bool EsTipo(Animal animal) => animal.EsHerviboro();
        public double CalcularAlimentoPorDia(Animal animal) => 2 * animal.Peso + animal.Kilos;
        public double CalcularAlimentoParaElMes(Animal animal) => DiasDelMes * CalcularAlimentoPorDia(animal);
        private static int DiasDelMes => DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
    }
}
