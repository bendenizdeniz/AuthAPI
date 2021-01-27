using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LoginDbApp.Entities
{
    public class Book
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [StringLength(30)]
        public string Reader { get; set; }

        [StringLength(30)]
        public string BookName { get; set; }

        [StringLength(30)]
        public string AuthorName { get; set; }

        [StringLength(500)]
        public string Comment { get; set; }

        public int Likes { get; set; }

        public int IDUser { get; set; }

        public DateTime PostedTime { get; set; }

        
    }
}
