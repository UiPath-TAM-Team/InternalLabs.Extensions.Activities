using UiPathTeam.Extensions.Activities;
using System.Activities;
using UiPathTeam.Extensions.Activities.Design;

namespace UiPathTeam.Extensions.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestTestActivity()
        {
            var testActivity = new Test
            {
                InString = new InArgument<String>("test")
            };

            var output = WorkflowInvoker.Invoke(testActivity);

            Assert.IsFalse(String.IsNullOrEmpty(output["OutString"].ToString()));

            Assert.AreEqual("Hello, test", output["OutString"]);
        }

        [TestMethod]
        public void TestAddToDictionary()
        {
            var dictionary = new Dictionary<Object, Object>();
            var key = "test key";
            var value = "test value";

            var addToDictionaryActivity = new AddToDictionary
            {
                Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
                Key = new InArgument<Object>((ctx) => key),
                Value = new InArgument<Object>((ctx) => value)
            };

            WorkflowInvoker.Invoke(addToDictionaryActivity);

            Assert.AreEqual("test value", dictionary["test key"]);
            Assert.AreEqual(1, dictionary.Count);
        }
    }
}