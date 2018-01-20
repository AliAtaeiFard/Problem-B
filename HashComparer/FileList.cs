using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashComparer
{
    public class FileList
    {
        public List<FileModel> Files = new List<FileModel>();

        public Tuple<int, int> GetNumbers()
        {
            var collisions = 0;
            var equals = 0;

            var equalHashTuples = GetEqualHashTuples();
            foreach (var tuple in equalHashTuples)
            {
                if (Files[tuple.Item1].Content != Files[tuple.Item2].Content)
                {
                    collisions++;
                }
                else
                {
                    equals++;
                }
            }

            return new Tuple<int, int>(Files.Count - equals, collisions);
        }

        private List<Tuple<int, int>> GetEqualHashTuples()
        {
            var equals = new List<Tuple<int, int>>();
            for (int i = 0; i < Files.Count; i++)
            {
                for (int j = 0; j < Files.Count; j++)
                {
                    if (Files[i].Hash == Files[j].Hash && i != j)
                    {
                        var tuple = new Tuple<int, int>(i, j);
                        if (!equals.Contains(tuple) && !equals.Contains(new Tuple<int, int>(tuple.Item2, tuple.Item1)))
                        {
                            equals.Add(tuple);
                        }
                        
                    }
                }
            }

            return equals;
        }
    }
}
