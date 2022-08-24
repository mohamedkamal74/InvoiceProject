using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceProject.Models
{
    public class RelBranch
    {
        public int BranchId { get; set; }
        [ForeignKey("BranchId")]
        public Branch Branch { get; set; }
    }
}
