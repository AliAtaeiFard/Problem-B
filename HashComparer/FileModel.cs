using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashComparer
{
    public class FileModel
    {
        public string Content { get; }
        public byte Hash { get; }

        public FileModel(string content)
        {
            Content = content;
            Hash = CalculateHash(Content);
        }

        private byte CalculateHash(string content)
        {
            byte hash = 0;
            var arr = Encoding.ASCII.GetBytes(content);

            arr.ToList().ForEach(a => hash ^= a);

            return hash;
        }
    }
}
