using System;

namespace InvoiceProject.Models
{
    public class BaseEntity:RelBranch
    {
        public int CurrentState { get; set; } = 1;
        public string CreateUserId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string UpdateUserId { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public string DeleteUserId { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}
