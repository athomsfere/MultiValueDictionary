using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public static class CommandWriterHelpers
    {
        public static void WriteAll<T>(List<T> toWrite)
        {
            toWrite.ForEach(e =>
            {
                Console.WriteLine($"{toWrite.IndexOf(e) + 1}) {e}");
            });
        }

        public static void WriteAllItems<T1, T2>(IDictionary<T1, List<T2>> itemsToWrite)
        {
            int lineNumber = 1;
            foreach(var key in itemsToWrite.Keys)
            {
                itemsToWrite[key].ForEach(e =>
                {
                    Console.WriteLine($"{lineNumber}) {key}:{e.ToString()}");
                    lineNumber++;
                });
            }
        }
    }
}
