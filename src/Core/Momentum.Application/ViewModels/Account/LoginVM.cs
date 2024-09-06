using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Momentum.Application.ViewModels.Account
{
    public class LoginVM
    {
        [Required, MaxLength(64)]
        public string Username { get; set; }
        [Required, MaxLength(64), DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
