using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoginDbApp.Entities
{
    public class Like
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IDLike { get; set; }

        public int IDUser { get; set; }

        public int IDBook { get; set; }
    }
}
