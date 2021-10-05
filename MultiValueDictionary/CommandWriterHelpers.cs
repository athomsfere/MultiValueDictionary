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
            int i = 1;
            toWrite.ForEach(e =>
            {
                Console.WriteLine($"{i}) {e}");
                i++;
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
