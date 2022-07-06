using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities
{
    public class Account : BaseEntity // Inheriting from Base Entity class
    {
        // String that uniquely identifies the account
        public string AccountNumber { get; set; }

        //Title of teh account
        public string AccountTitle { get; set; }

        //Available Balance of the account
        public decimal CurrentBalance { get; set; }

        // This decoration is required to conver integer coming in from UI to respective Enum
        [JsonConverter(typeof(JsonStringEnumConverter))]
        //Account's status
        public AccountStatus AccountStatus { get; set; }

        //Setting forignkey to resolve circular dependency
        [ForeignKey("UserId")]
        public string UserId { get; set; }

        // One User might have 1 or more Accounts (1:Many relationship) 
        public virtual User User { get; set; }

        // One Account might have 0 or more Transactions (1:Many relationship)
        public virtual ICollection<Transaction> Transactions { get; set; }
    }

    // Two posible statuses of an account
    public enum AccountStatus
    {
        Active = 1,     // When an account can perform transactions
        InActive = 0    // When an account cannot perform transaction
    }
}
