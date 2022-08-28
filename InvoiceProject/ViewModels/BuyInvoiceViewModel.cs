using InvoiceProject.Models;
using System.Collections.Generic;

namespace InvoiceProject.ViewModels
{
    public class BuyInvoiceViewModel
    {
        public List<Supplier> SuppllierList { get; set; }=new List<Supplier>();
        public List<Category> CategoriesList { get; set; }= new List<Category>();
        public BuyInvoice NewBuyInvoice { get; set; } = new BuyInvoice();
    }
}
