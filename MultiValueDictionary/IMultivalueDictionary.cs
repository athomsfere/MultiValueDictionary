using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    interface IMultivalueDictionary<T1, T2>
    {
        IEnumerable<T1> GetKeys();
        IEnumerable<T1> GetKeyMembers(T1 key);
        void AddMember(T1 key , T2 member);
        void RemoveMember(T1 key, T2 member);
        void RemoveAllMembers(T1 key);
        void Clear();
        bool DoesKeyExist(T1 key);
        bool DoesMemberExist(T1 key, T2 member);
        IEnumerable<T2> GetAllKeysMembers();
        IDictionary<T1, List<T2>> GetAllItems();
    }
}
