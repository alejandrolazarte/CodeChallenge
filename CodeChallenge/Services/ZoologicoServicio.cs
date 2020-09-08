using System;
using CodeChallenge.Data.Model;
using CodeChallenge.Services.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallenge.Services
{
    public class ZoologicoServicio : IZoologicoServicio
    {
        private readonly List<Animal> _animales;
        private readonly ICalcularAlimentoServicio _calcularComidaServicio;
        private const int TopeAlimento = 1500;
        public ZoologicoServicio(ICalcularAlimentoServicio calcularComidaServicio)
        {
            _animales = new List<Animal>();
            _calcularComidaServicio = calcularComidaServicio;
        }

        public void AgregarAnimal(Animal animal)
        {
            animal.FechaIncorporacion = DateTime.Now;
            _animales.Add(animal);
        }

        public List<Animal> ObtenerTodos()
        {
             _animales.ForEach(x => x.CantidadAlimentoPorMes = _calcularComidaServicio.CalcularAlimentoParaElMes(x));
             return _animales;
        }

        public bool ExedioTopeAlimentoMes()
        {
            var totalDeConsumoPorMes = _animales.Sum(_calcularComidaServicio.CalcularAlimentoParaElMes);
            return totalDeConsumoPorMes > TopeAlimento;
        }
    }
}
