using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceProject.Models
{
    public class BuyInvoice:BaseEntity
    {
        [Key]
        public int BuyInvoiceId { get; set; }
        public int SupplierId { get; set; }
        [ForeignKey("SupplierId")]
        public Supplier Supplier { get; set; }
        public DateTime Date { get; set; }
        public decimal Tatal { get; set; }
        public decimal Discount { get; set; }
        public decimal AfterDiscount { get; set; }

    }
}
