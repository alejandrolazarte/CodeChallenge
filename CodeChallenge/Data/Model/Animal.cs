using System;
using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Data.Model
{
    public abstract class Animal
    {
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Especie { get; set; }
        [Range(1, int.MaxValue, ErrorMessage = "El campo {0} es obligatorio")]
        public int Edad { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string LugarOrigen { get; set; }
        [Range(0.1D, double.MaxValue, ErrorMessage = "El campo {0} es obligatorio")]
        public double Peso { get; set; }
        [Range(0.1D, double.MaxValue, ErrorMessage = "El campo {0} es obligatorio")]
        public double Porcentaje { get; set; }
        [Range(0.1D, double.MaxValue, ErrorMessage = "El campo {0} es obligatorio")]
        public double Kilos { get; set; }
        public DateTime FechaIncorporacion { get; set; }
        public double CantidadAlimentoPorMes { get; set; }
    }
}