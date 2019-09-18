using Auther.API.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.Interfaces
{
    public interface IEncryptionService
    {
        string GeneratePasswordSalt();
        string HashToMD5(string input);
        EncryptionDTO StandardMD5Encryption(string PlainText);
        EncryptionDTO StandardMD5Decryption(string cipher);
    }
}
