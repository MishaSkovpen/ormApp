using System;
using System.Collections.Generic;

namespace ormApp.Models
{
    public partial class Income
    {
        public int IncomeId { get; set; }
        public int? UserId { get; set; }
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
        public string? Source { get; set; }

        public virtual User? User { get; set; }
    }
}
