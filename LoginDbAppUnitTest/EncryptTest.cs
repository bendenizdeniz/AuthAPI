
using LoginDbApp.Businnes.Abstract;
using LoginDbApp.Businnes.Concrete;
using System;
using Xunit;

namespace LoginApplication.UnitTest
{
    public class EncryptTest
    {
        [Fact]
        public void Encrypt_Success()
        {
            IEncryptOperation encryptOperation = new EncryptManager();
            var result = encryptOperation.Encrypt("a");
            Assert.Equal("ca978112ca1bbdcafac231b39a23dc4da786eff8147c4e72b9807785afee48bb", result);
        }
    }
}
