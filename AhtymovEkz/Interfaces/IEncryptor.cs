using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhtymovEkz.Interfaces
{
    public interface IEncryptor
    {
        string Encrypt(string value);
    }
}
