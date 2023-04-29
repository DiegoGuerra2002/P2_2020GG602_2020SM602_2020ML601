using System.ComponentModel.DataAnnotations;
namespace P2_2020GG602_2020SM602_2020ML601.Models
{
    public class generos
    {
        [Key]
        public int idgenero { get; set; }
        public string generotipo { get; set; }
        
    }
}
