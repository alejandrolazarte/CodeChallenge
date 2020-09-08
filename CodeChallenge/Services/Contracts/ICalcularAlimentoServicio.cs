using System.Collections.Generic;
using CodeChallenge.Data.Model;

namespace CodeChallenge.Services.Contracts
{
    public interface ICalcularAlimentoServicio
    {
        double CalcularAlimentoPorDia(Animal animal);
        double CalcularAlimentoParaElMes(Animal animal);
        double ObtenerTotalCarneDelMes(List<Animal> animales);
        double ObtenerTotalHierbasDelMes(List<Animal> animales);
    }
}
