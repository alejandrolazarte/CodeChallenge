using System;
using CodeChallenge.Data.Model;
using CodeChallenge.Data.Model.Extensions;
using CodeChallenge.Services.Contracts;

namespace CodeChallenge.Services
{
    public class CalcularAlimentoCarnivoroServicio : ICalcularAlimentoPorTipoAnimalServicio
    {
        public bool EsTipo(Animal animal) => animal.EsCarnivoro();
        public double CalcularAlimentoPorDia(Animal animal) => animal.Peso * animal.Porcentaje;
        public double CalcularAlimentoParaElMes(Animal animal) => DiasDelMes * CalcularAlimentoPorDia(animal);
        private static int DiasDelMes => DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);
    }
}
