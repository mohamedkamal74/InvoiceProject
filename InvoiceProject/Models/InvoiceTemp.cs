using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceProject.Models
{
    public class InvoiceTemp:RelBranch
    {
        [Key]
        public int InvoiceId { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category  Category { get; set; }

        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public decimal Price { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }

    }
}
