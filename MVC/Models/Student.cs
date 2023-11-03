using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [Column("SName",TypeName ="varchar(100)")]
        public string? Name { get; set; }
        [Column("SGender", TypeName = "varchar(20)")]
        public string? Gender { get; set; }
        public int Age { get; set; }
        public int Standard { get; set; }
        public string city { get; set; }

    }
}
