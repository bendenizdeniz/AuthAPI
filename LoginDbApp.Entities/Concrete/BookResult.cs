using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDbApp.Entities.Concrete
{
    public class BookResult : ResultMessage
    {
        public string Message { get; set; }
        public DateTime PostedTime { get; set; }
        public int IDUser { get; set; }
    }
}
