using System;
using Xunit;
using MultiValueDictionary;
using System.Linq;

namespace MultiValueDictionary.Test
{
    public class MultivalueTests
    {
        [Fact]
        public void AddMembers_OK()
        {
            IMultivalueDictionary<string, string> multiValueDictionary = addTwoFoos();

            Assert.True(multiValueDictionary.GetKeyMembers("foo").ToList().Count() == 2);
        }

        private static IMultivalueDictionary<string, string> addTwoFoos()
        {
            var multiValueDictionary = new MultiValueDictionary<string, string>() as IMultivalueDictionary<string, string>;

            multiValueDictionary.AddMember("foo", "bar");
            multiValueDictionary.AddMember("foo", "baz");
            return multiValueDictionary;
        }

        [Fact]
        public void AddDuplicateErrors_Exeption()
        {
            var multiValueDictionary = new MultiValueDictionary<string, string>() as IMultivalueDictionary<string, string>;

            multiValueDictionary.AddMember("foo", "bar");

            Assert.Throws<ArgumentException>(() => multiValueDictionary.AddMember("foo", "bar"));
        }

        [Fact]
        public void ClearMultiObject_NoKeys()
        {
            var twoFoos = addTwoFoos();

            twoFoos.Clear();
            var emptyFoos = twoFoos.GetAllItems();

            Assert.True(twoFoos.GetAllKeysMembers().Count() == 0);
        }

        [Fact]
        public void Create2KeysANd2Members_4ItemsResult()
        {
            var results = addTwoFoos();
            results.AddMember("bang", "bar");
            results.AddMember("bang", "bazz");
            int countedResults = 0;
            results.GetAllItems().ToList().ForEach(e => countedResults += e.Value.Count());
            
            Assert.True(countedResults == 4);
        }

        [Fact]
        public void TestHasMember()
        {
            var results = addTwoFoos();
            Assert.True(results.DoesMemberExist("foo", "bar"));
        }

        [Fact]
        public void TestHasKey()
        {
            var results = addTwoFoos();
            Assert.True(results.DoesKeyExist("foo"));
        }

        [Fact]
        public void TestGetKeys()
        {
            var twoItems = addTwoFoos();
            var result = twoItems.GetKeys().Count();

            Assert.True(result == 1);
        }

        [Fact]
        public void RemoveOne()
        {
            var twoItems = addTwoFoos();
            twoItems.RemoveMember("foo", "bar");

            Assert.True(twoItems.GetKeyMembers("foo").Count() == 1);
        }

        [Fact]
        public void RemoveAll_ClearsKey()
        {
            var twoItems = addTwoFoos();
            twoItems.RemoveAllMembers("foo");

            Assert.False(twoItems.DoesKeyExist("foo"));
        }
    }
}
