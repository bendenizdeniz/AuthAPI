using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoginDbApp.Entities
{
    public class Login
    {

        [StringLength(30)]
        [Required]
        public string Email { get; set; }

        [StringLength(500)]
        [Required]
        public string Password { get; set; }

        public DateTime LoginDate { get; set; }

    }
}
