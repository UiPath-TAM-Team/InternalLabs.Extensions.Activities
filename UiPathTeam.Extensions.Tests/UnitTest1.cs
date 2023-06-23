using UiPathTeam.Extensions.Activities;
using System.Activities;

namespace UiPathTeam.Extensions.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testActivity = new Test
            {
                InString = "test"
            };

            var output = WorkflowInvoker.Invoke(testActivity);

            Assert.IsFalse(String.IsNullOrEmpty(output["OutString"].ToString()));

            Assert.AreEqual("Hello, test", output["OutString"]);

            // Comment to show changes
        }
    }
}