using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ormApp.Models
{
    public partial class User
    {
        public User()
        {
            Expenses = new HashSet<Expense>();
            Incomes = new HashSet<Income>();
        }

        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }

        [MaxLength(100)]
        public string Residence { get; set; }// Додано атрибут residence

        public virtual ICollection<Expense> Expenses { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
    }
}
