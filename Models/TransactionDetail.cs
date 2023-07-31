using System;
using System.Collections.Generic;

namespace InsuranceApi.Models
{
    public partial class TransactionDetail
    {
        public int ApplyId { get; set; }
        public int? CustomerId { get; set; }
        public int? PolicyId { get; set; }
        public DateTime? AppliedDate { get; set; }

        public virtual Customer? Customer { get; set; }
        public virtual InsPolicy? Policy { get; set; }
    }
}
