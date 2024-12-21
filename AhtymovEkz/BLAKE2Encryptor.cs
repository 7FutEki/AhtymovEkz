using AhtymovEkz.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blake2Fast;

namespace AhtymovEkz
{
    public class BLAKE2Hasher : IHasher
    {
        private readonly byte[] _salt = Encoding.UTF8.GetBytes("oboudno");

        public string Hash(string value)
        {
            byte[] hash = Blake2b.ComputeHash(32, _salt, System.Text.Encoding.UTF8.GetBytes(value));
            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
