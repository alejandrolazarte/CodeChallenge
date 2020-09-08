using System.Collections.Generic;
using CodeChallenge.Data.Model;

namespace CodeChallenge.Services.Contracts
{
    public interface IZoologicoServicio
    {
        void AgregarAnimal(Animal animal);
        List<Animal> ObtenerTodos();
        bool ExedioTopeAlimentoMes();
    }
}
