using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace IT_Notes.Utils
{
    public static class Extensions
    {
        public static byte[] GetBytesStream(this Stream stream)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                stream.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
