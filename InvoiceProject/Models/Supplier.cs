using System.ComponentModel.DataAnnotations;

namespace InvoiceProject.Models
{
    public class Supplier:BaseEntity
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
    }
}
