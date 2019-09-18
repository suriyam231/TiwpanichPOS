using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auther.API.DTOs
{
    public class EncryptionDTO
    {
        public string PlainText { get; set; }
        public string CipherText { get; set; }
        public string Key { get; set; }
    }
}
