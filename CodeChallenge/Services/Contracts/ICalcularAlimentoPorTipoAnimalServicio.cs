using CodeChallenge.Data.Model;

namespace CodeChallenge.Services.Contracts
{
    public interface ICalcularAlimentoPorTipoAnimalServicio
    {
        bool EsTipo(Animal animal);
        double CalcularAlimentoPorDia(Animal animal);
        double CalcularAlimentoParaElMes(Animal animal);
    }
}
