using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    class CommandConstants
    {
        public const string Add = "ADD";
        public const string AllMembers = "ALLMEMBERS";
        public const string Clear = "CLEAR";
        public const string Keys = "KEYS";
        public const string KeyExists = "KEYEXISTS";
        public const string Members = "MEMBERS";
        public const string MemberExists = "MEMBEREXISTS";
        public const string Remove = "REMOVE";
        public const string RemoveAll = "REMOVEALL";
        public const string Items = "ITEMS";

        public const string Help = "-H for help; Commands: | ADD | ALLMEMBERS | CLEAR | KEYS | KEYEXISTS | MEMBERS | MEMBEREXISTS \r\n | REMOVE | REMOVEALL | ITEMS";
    }
}
