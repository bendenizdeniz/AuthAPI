using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDbApp.Entities
{
    public class UserResult : ResultMessage
    {
        public DateTime CreatedDate { get; set; }
        public int IDUser { get; set; }
    }
}
