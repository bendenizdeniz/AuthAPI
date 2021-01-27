using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDbApp.Entities.Concrete
{
    public class LoginResult : ResultMessage
    {
        public string Message { get; set; }
        public DateTime LoginDate { get; set; }
        public int IDUser { get; set; }
    }
}
