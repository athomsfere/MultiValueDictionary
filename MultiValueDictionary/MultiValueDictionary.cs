using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiValueDictionary
{
    public class MultiValueDictionary<Tkey, TValue> : IMultivalueDictionary<Tkey, TValue>
    {
        private Dictionary<Tkey, List<TValue>> multiDictionary = new Dictionary<Tkey, List<TValue>>();
        /// <summary>
        /// Adds value to the MultiValueDictionary
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        public void AddMember(Tkey key, TValue member)
        {
            if (!DoesKeyExist(key))
            {
                multiDictionary.Add(key, new List<TValue>());
            }

            if (multiDictionary[key].Contains(member))
            {
                throw new ArgumentException($"Error - key already contains {member}");
            }
            multiDictionary[key].Add(member);
        }

        /// <summary>
        /// Clears all keys, and members
        /// </summary>
        public void Clear()
        {
            multiDictionary = new Dictionary<Tkey, List<TValue>>();
        }

        /// <summary>
        /// Determins if MultiValueDictionary contains the key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public bool DoesKeyExist(Tkey key)
        {
            return multiDictionary.ContainsKey(key);
        }
        /// <summary>
        /// Return false if either member, or key does not exist
        /// </summary>
        /// <param name="key"></param>
        /// <param name="member"></param>
        /// <returns></returns>
        public bool DoesMemberExist(Tkey key, TValue member)
        {
            if(DoesKeyExist(key))
            {
                return multiDictionary[key].Contains(member);
            }
            else
            {
                return false;
            }
        }

        public IDictionary<Tkey, List<TValue>> GetAllItems()
        {
            return multiDictionary;
        }
        /// <summary>
        /// Returns all members, from all keys
        /// </summary>
        /// <returns></returns>
        public IEnumerable<TValue> GetAllKeysMembers()
        {
            if(multiDictionary.Keys.Count() == 0)
            {
                return new List<TValue>();
            }

            List<TValue> values = new List<TValue>();
            foreach(var key in multiDictionary.Keys)
            {
                values.AddRange(multiDictionary[key].ToList());
            }

            return values;
        }

        public IEnumerable<Tkey> GetKeyMembers(Tkey key)
        {
            return (IEnumerable<Tkey>)multiDictionary[key]?.ToList() ?? null;
        }

        public IEnumerable<Tkey> GetKeys()
        {
            return multiDictionary.Keys.ToList();
        }

        public void RemoveAllMembers(Tkey key)
        {
            if(!multiDictionary.ContainsKey(key))
            {
                throw new ArgumentOutOfRangeException("ERROR, Key does not exist");
            }

            multiDictionary[key].Clear();
            multiDictionary.Remove(key);
        }

        public void RemoveMember(Tkey key, TValue member)
        {
            if(!DoesKeyExist(key))
            {
                throw new ArgumentNullException("ERROR, Key does not exist");
            }

            if(!DoesMemberExist(key, member))
            {
                throw new ArgumentNullException("ERROR, Member does not exist");
            }

            multiDictionary[key].Remove(member);

            if (multiDictionary[key].Count() == 0)
            {
                multiDictionary.Remove(key);
            }
        }
    }
}
