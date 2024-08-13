using System.ComponentModel.DataAnnotations.Schema;

namespace project.DTOs
{
    public class ProductDTO
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int CategorieId { get; set; }
    }
}
