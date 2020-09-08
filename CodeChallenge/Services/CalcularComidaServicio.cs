using CodeChallenge.Data.Model;
using CodeChallenge.Data.Model.Extensions;
using CodeChallenge.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Services
{
    public class CalcularComidaServicio : ICalcularAlimentoServicio
    {
        private readonly IEnumerable<ICalcularAlimentoPorTipoAnimalServicio> _calcularComidaPorTipoAnimalServicios;

        public CalcularComidaServicio(
            IEnumerable<ICalcularAlimentoPorTipoAnimalServicio> calcularComidaPorTipoAnimalServicios)
        {
            _calcularComidaPorTipoAnimalServicios = calcularComidaPorTipoAnimalServicios;
        }

        public double CalcularAlimentoPorDia(Animal animal)
        {
            var service = GetService(animal);
            return service.CalcularAlimentoPorDia(animal);
        }

        public double CalcularAlimentoParaElMes(Animal animal)
        {
            var service = GetService(animal);
            return service.CalcularAlimentoParaElMes(animal);
        }

        public double ObtenerTotalCarneDelMes(List<Animal> animales) =>
            animales.Where(x => x.EsCarnivoro() || x.EsReptil()).Sum(CalcularAlimentoParaElMes);


        public double ObtenerTotalHierbasDelMes(List<Animal> animales) =>
            animales.Where(x => x.EsHerviboro() || x.EsReptil()).Sum(CalcularAlimentoParaElMes);


        private ICalcularAlimentoPorTipoAnimalServicio GetService(Animal animal)
            => _calcularComidaPorTipoAnimalServicios
                .FirstOrDefault(x => x.EsTipo(animal));
    }
}
