using System.ComponentModel.DataAnnotations;

namespace CodeChallenge.Data.Model
{
    public class Reptil : Animal
    {
        [Range(4, int.MaxValue, ErrorMessage = "El campo {0} es obligatorio y debe ser mayor que {1}.")]
        public int CantidadDiasCambioPiel { get; set; }

        public override string ToString()
        {
            return "Reptil";
        }
    }
}
