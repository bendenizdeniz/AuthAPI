using System;
using System.Collections.Generic;
using System.Text;

namespace LoginDbApp.Businnes.Abstract
{
    public interface IEncryptOperation
    {
        public string Encrypt(string password);
    }
}
