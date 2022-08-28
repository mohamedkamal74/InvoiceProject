using System;
using System.Collections.Generic;
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
        public decimal Total { get; set; }
        public decimal Discount { get; set; }
        public decimal AfterDiscount { get; set; }
        public List<BuyInvoiceItem> BuyInvoiceItemList { get; set; }=new List<BuyInvoiceItem>();

    }
}
