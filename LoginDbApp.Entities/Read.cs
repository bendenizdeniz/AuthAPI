using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoginDbApp.Entities
{
    public class Read
    {
        public int IDBook { get; set; }

        public int IDUser { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDRead { get; set; }

        public string Name { get; set; }
    }
}
