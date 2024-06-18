using System;
using System.Collections.Generic;

namespace ormApp.Models
{
    public partial class Expense
    {
        public int ExpenseId { get; set; }
        public int? UserId { get; set; }
        public decimal Amount { get; set; }
        public DateOnly Date { get; set; }
        public int? CategoryId { get; set; }

        public virtual User? User { get; set; }
    }
}
