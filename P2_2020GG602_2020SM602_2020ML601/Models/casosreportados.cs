using System.ComponentModel.DataAnnotations;
namespace P2_2020GG602_2020SM602_2020ML601.Models
{
    public class casosreportados
    {
        [Key]
        public int idcaso { get; set; }
        public int confirmados { get; set; }
        public int recuperados { get; set; }
        public int fallecidos { get; set; }
        public int iddepartamento { get; set; }

    }
}
