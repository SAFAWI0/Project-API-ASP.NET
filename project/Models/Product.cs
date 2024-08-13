using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace project.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }




        public int CategorieId { get; set; }
        [ForeignKey ("CategorieId")]
        public Categorie Categorie { get; set; }

    }
}
