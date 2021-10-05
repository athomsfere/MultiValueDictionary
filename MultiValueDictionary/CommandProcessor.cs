using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public class CommandProcessor
    {
        internal void Process(DictionaryCommand command, IMultivalueDictionary<string, string> multiValueDictionary)
        {
            switch (command.Command)
            {
                case CommandConstants.Add:
                    multiValueDictionary.AddMember(command.KeyName, command.Value);
                    Console.WriteLine("Added");
                    break;
                case CommandConstants.AllMembers:
                    var allMembers = multiValueDictionary.GetAllKeysMembers();
                    WriteAllOrEmptySet(allMembers);
                    break;
                case CommandConstants.Clear:
                    multiValueDictionary.Clear();
                    Console.WriteLine("Cleared");
                    break;
                case CommandConstants.Items:
                    var allItems = multiValueDictionary.GetAllItems();
                    WriteAllMembersAndKeysOrEmptySet(allItems);
                    break;
                case CommandConstants.KeyExists:
                    Console.WriteLine(multiValueDictionary.DoesKeyExist(command.KeyName));
                    break;
                case CommandConstants.Keys:
                    var keys = multiValueDictionary.GetKeys();
                    WriteAllOrEmptySet(keys);
                    break;
                case CommandConstants.MemberExists:
                    Console.WriteLine(multiValueDictionary.DoesMemberExist(command.KeyName, command.Value));
                    break;
                case CommandConstants.Members:
                    var keyMembers = multiValueDictionary.GetKeyMembers(command.KeyName).ToList();
                    CommandWriterHelpers.WriteAll(keyMembers);
                    break;
                case CommandConstants.Remove:
                    multiValueDictionary.RemoveMember(command.KeyName, command.Value);
                    Console.WriteLine("REMOVED");
                    break;
                case CommandConstants.RemoveAll:
                    multiValueDictionary.RemoveAllMembers(command.KeyName);
                    Console.WriteLine("REMOVED");
                    break;
                default:
                    Console.WriteLine("No valid commands were entered");
                    break;
            }
        }

        private static void WriteAllMembersAndKeysOrEmptySet(IDictionary<string, List<string>> allItems)
        {
            if (!allItems.Any())
            {
                Console.WriteLine("(empty set)");
            }
            else
            {
                CommandWriterHelpers.WriteAllItems(allItems);
            }
        }

        private static void WriteAllOrEmptySet(IEnumerable<string> allMembers)
        {
            if (!allMembers.Any())
            {
                Console.WriteLine("(empty set)");
            }
            else
            {
                CommandWriterHelpers.WriteAll(allMembers.ToList<string>());
            }
        }
    }
}
