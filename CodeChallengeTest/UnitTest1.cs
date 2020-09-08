using CodeChallenge.Data.Model;
using CodeChallenge.Services;
using CodeChallenge.Services.Contracts;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallengeTest
{
    public class Tests
    {
        private List<Animal> _animales;
        private ICalcularAlimentoServicio _calcularAlimentoServicio;
        private IZoologicoServicio _zoologicoServicioServicio;


        [SetUp]
        public void Setup()
        {
            _animales = new List<Animal>();
            var services = new ServiceCollection();
            services.AddSingleton<IZoologicoServicio, ZoologicoServicio>();
            services.AddTransient<ICalcularAlimentoServicio, CalcularComidaServicio>();
            services.AddTransient<ICalcularAlimentoPorTipoAnimalServicio, CalcularAlimentoCarnivoroServicio>();
            services.AddTransient<ICalcularAlimentoPorTipoAnimalServicio, CalcularAlimentoHervivoroServicio>();
            services.AddTransient<ICalcularAlimentoPorTipoAnimalServicio, CalcularAlimentoReptilServicio>();
            var provider = services.BuildServiceProvider();
            _calcularAlimentoServicio = provider.GetService<ICalcularAlimentoServicio>();
            _zoologicoServicioServicio = provider.GetService<IZoologicoServicio>();
        }

        [Test]
        public void CalcularAlimentoSinAnimales()
        {
            var result = _animales.Sum(_calcularAlimentoServicio.CalcularAlimentoPorDia);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void CalcularAlimentoSoloCarnivoros()
        {
            _animales.AddRange(MockFactoryCarnivoros());
            var result = _animales
                .Sum(_calcularAlimentoServicio.CalcularAlimentoPorDia);
            Assert.AreEqual(22.5, result);
        }

        [Test]
        public void CalcularAlimentoSoloHerviboros()
        {
            _animales.AddRange(MockFactoryHerivboros());
            var result = _animales
                .Sum(_calcularAlimentoServicio.CalcularAlimentoPorDia);
            Assert.AreEqual(185, result);
        }

        [Test]
        public void CalcularAlimentoSoloReptiles()
        {
            _animales.AddRange(MockFactoryReptiles());
            var result = _animales
                .Sum(_calcularAlimentoServicio.CalcularAlimentoPorDia);
            Assert.AreEqual(1.1428571428571428, result);
        }

        [Test]
        public void CalcularAlimentoTodos()
        {
            _animales.AddRange(MockFactoryTodos());
            var result = _animales
                .Sum(_calcularAlimentoServicio.CalcularAlimentoPorDia);
            Assert.AreEqual(207.5, result);
        }

        [Test]
        public void ExedioTopeAlimentoMes()
        {
            _zoologicoServicioServicio.AgregarAnimal(new Carnivoro {Porcentaje = 0.6,Peso = 100} );
           var result = _zoologicoServicioServicio.ExedioTopeAlimentoMes();
           Assert.AreEqual(true, result);
        }

        [Test]
        public void CalcularAlimentoDelMesSoloCarnivoros()
        {
            _animales.AddRange(MockFactoryCarnivoros());
            var result = _animales
                .Sum(_calcularAlimentoServicio.CalcularAlimentoParaElMes);
            Assert.AreEqual(675, result);
        }

        [Test]
        public void CalcularAlimentoDelMesSoloHervivoros()
        {
            _animales.AddRange(MockFactoryHerivboros());
            var result = _animales
                .Sum(_calcularAlimentoServicio.CalcularAlimentoParaElMes);
            Assert.AreEqual(5550, result);
        }

        #region Mock Factory
        private static IEnumerable<Animal> MockFactoryCarnivoros() =>
            new List<Animal> {
                new Carnivoro {
                    Peso = 100,
                    Porcentaje = 0.05
                },
                new Carnivoro {
                    Peso = 80,
                    Porcentaje = 0.1
                },
                new Carnivoro {
                    Peso = 95,
                    Porcentaje = 0.1
                }
            };

        private static IEnumerable<Animal> MockFactoryHerivboros()
        {
            return new List<Animal> {
                new Hervivoro {
                    Peso = 30,
                    Kilos = 10
                },
                new Hervivoro {
                    Peso = 50,
                    Kilos = 15
                }
            };
        }

        private static IEnumerable<Animal> MockFactoryReptiles()
        {
            return new List<Animal> {
                new Reptil {
                    Peso = 30,
                    Porcentaje = 0.1
                },
                new Reptil {
                    Peso = 50,
                    Porcentaje = 0.1
                }
            };
        }

        private static IEnumerable<Animal> MockFactoryTodos()
        {
            return new List<Animal> {
                new Carnivoro {
                    Peso = 100,
                    Porcentaje = 0.05
                },
                new Carnivoro {
                    Peso = 80,
                    Porcentaje = 0.1
                },
                new Carnivoro {
                    Peso = 95,
                    Porcentaje = 0.1
                },
                new Hervivoro {
                    Peso = 30,
                    Kilos = 10
                },
                new Hervivoro {
                    Peso = 50,
                    Kilos = 15
                }
            };
        }
        #endregion
    }
}