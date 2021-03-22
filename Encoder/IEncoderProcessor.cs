using System;
using System.Collections.Generic;
using System.Text;

namespace encoder
{
   public interface IEncoderProcessor
    {
        public string Encode(string message);
    }
}
