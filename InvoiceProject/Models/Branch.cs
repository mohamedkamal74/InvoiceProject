using System;
using System.ComponentModel.DataAnnotations;

namespace InvoiceProject.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        public string  BranchName { get; set; }
        public string Address { get; set; }

        public int CurrentState { get; set; } = 1;
        public string CreateUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string DeleteUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
