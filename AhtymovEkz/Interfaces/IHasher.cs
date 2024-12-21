using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AhtymovEkz.Interfaces
{
    public interface IHasher
    {
        string Hash(string value);
    }
}
