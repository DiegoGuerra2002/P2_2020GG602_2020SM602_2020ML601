using System.ComponentModel.DataAnnotations;
namespace P2_2020GG602_2020SM602_2020ML601.Models
{
    public class departamento
    {
        [Key]
        public int iddepartamento { get; set; }
        public string? nombredepartamento { get; set;}

    }
}
