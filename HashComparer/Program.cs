using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashComparer
{
    class Program
    {
        const string FileName = "hashes.txt";

        static void Main(string[] args)
        {
            var lines = File.ReadAllLines(FileName);

            int number = 0;
            int index = 0;
            do
            {
                if (int.TryParse(lines[index], out number) && number > 0)
                {
                    var list = new FileList();
                    index++;
                    for (int i = index; i < index + number; i++)
                    {
                        var file = new FileModel(lines[i]);
                        list.Files.Add(file);

                    }

                    index += number;
                    Console.WriteLine(list.GetNumbers());
                }
            } while (number != 0);

            Console.ReadLine();
        }
    }

}
