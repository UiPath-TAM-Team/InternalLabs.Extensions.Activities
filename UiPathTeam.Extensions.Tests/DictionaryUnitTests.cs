using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Activities;
using System.Collections.Generic;
using UiPathTeam.Extensions.Activities;

namespace UiPathTeam.Extensions.Tests
{
	[TestClass]
	public class DictionaryUnitTests
	{
		[TestMethod]
		public void TestAddToDictionary()
		{
			var dictionary = new Dictionary<Object, Object>();
			var stringKey = "test key";
			var stringValue = "test value";

			var addToDictionaryActivity = new AddToDictionary
			{
				Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
				Key = new InArgument<Object>((ctx) => stringKey),
				Value = new InArgument<Object>((ctx) => stringValue)
			};

			WorkflowInvoker.Invoke(addToDictionaryActivity);

			Assert.AreEqual(stringValue, dictionary[stringKey]);
			Assert.AreEqual(1, dictionary.Count);

			stringKey = "another key";
			var integerValue = 32;

			addToDictionaryActivity = new AddToDictionary
			{
				Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
				Key = new InArgument<Object>((ctx) => stringKey),
				Value = new InArgument<Object>((ctx) => integerValue)
			};

			WorkflowInvoker.Invoke(addToDictionaryActivity);
			Assert.AreEqual(integerValue, dictionary[stringKey]);
			Assert.AreEqual(2, dictionary.Count);

			var integerKey = 42;
			stringValue = "the answer";

			addToDictionaryActivity = new AddToDictionary
			{
				Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
				Key = new InArgument<Object>((ctx) => integerKey),
				Value = new InArgument<Object>((ctx) => stringValue)
			};

			WorkflowInvoker.Invoke(addToDictionaryActivity);
			Assert.AreEqual(stringValue, dictionary[integerKey]);
			Assert.AreEqual(3, dictionary.Count);
		}

        [TestMethod]
        public void TestRemoveFromDictionary()
		{
            var dictionary = new Dictionary<Object, Object>();
			
            var stringKey = "test key";
            var stringValue = "test value";

			dictionary.Add(stringKey, stringValue);

            var removeFromDictionaryActivity = new RemoveFromDictionary
            {
                In_Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
                In_Key = new InArgument<Object>((ctx) => stringKey),
            };

            WorkflowInvoker.Invoke(removeFromDictionaryActivity);

			Assert.IsTrue(dictionary.Count == 0);
        }
        [TestMethod]
        public void TestDictionaryContainsValue()
        {
            var dictionary = new Dictionary<Object, Object>();
            var boolResult = true;
            var stringKey = "test key";
            var stringValue = "test value";
            

            dictionary.Add(stringKey, stringValue);

            var dictionaryContainsValue = new DictionaryContainsValue
            {
                Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
                Value = new InArgument<Object>((ctx) => stringValue),
                Result = new OutArgument<Boolean>((ctx) => boolResult),
            };

            WorkflowInvoker.Invoke(dictionaryContainsValue);

            Assert.IsTrue(boolResult);
        }
        [TestMethod]
        public void TestDictionaryGetValue()
        {
            var dictionary = new Dictionary<Object, Object>();
            var objectResult = new Object();
            var stringKey = "test key";
            var stringValue = "test value";


            dictionary.Add(stringKey, stringValue);

            var dictionaryGetValue = new GetDictionaryValue
            {
                Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
                Key = new InArgument<Object>((ctx) => stringKey),
                Result = new OutArgument<Object>((ctx) => objectResult),
            };

            WorkflowInvoker.Invoke(dictionaryGetValue);

            Assert.IsTrue(objectResult.ToString() == stringValue);
        }

        [TestMethod]
        public void TestCountDictionary()
        {
            var dictionary = new Dictionary<Object, Object>();
            var stringKey = "test key";
            var stringValue = "test value";
            var Out_Result = new int();

            dictionary.Add(stringKey, stringValue);

            var CountDictionaryActivity = new CountDictionary
            {
                In_dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
                Out_result = new OutArgument<int> ((ctx) => Out_Result),
            };

            WorkflowInvoker.Invoke(CountDictionaryActivity);

            Assert.IsTrue(Out_Result == 1);
        }

        [TestMethod]
        public void TestDictionaryContainsKey_KeyExists()
        {
            // Create the dictionary and populate it with key-value pairs
            var dictionary = new Dictionary<object, object>
            {
                { "key1", "value1" },
                { "key2", "value2" },
                // Add more key-value pairs as needed
            };

            // Set the key you want to test
            var in_key = "key1";

            // Positive Test: Key is in dictionary, return true and value
            // Create an instance of your workflow activity
            var DictionaryContainsKeyActivity = new DictionaryContainsKey
            {
                In_dictionary = new InArgument<Dictionary<object, object>>(ctx => dictionary),
                In_key = new InArgument<object>(ctx => in_key),
            };

            // Invoke the workflow synchronously and capture the results
            IDictionary<string, object> output = WorkflowInvoker.Invoke(DictionaryContainsKeyActivity);

            // Retrieve the output values from the dictionary
            var outputResult = (bool)output["Out_result"]; // Assuming "Out_result" is the output argument
            var outputValue = (object)output["Out_value"]; // Assuming "Out_value" is the output argument

            // Assert the result based on your activity's logic
            Assert.IsTrue(outputResult); // Verify that the result is true when the key exists

            // Additional assertions based on your activity's behavior
            Assert.AreEqual("value1", outputValue); // Verify the expected value
        }

        [TestMethod]
        public void TestDictionaryContainsKey_KeyDoesNotExists()
        {
            // Create the dictionary and populate it with key-value pairs
            var dictionary = new Dictionary<object, object>
            {
                { "key1", "value1" },
                { "key2", "value2" },
                // Add more key-value pairs as needed
            };

            // Set the key you want to test
            var in_key = "failure";

            // Positive Test: Key is in dictionary, return true and value
            // Create an instance of your workflow activity
            var DictionaryContainsKeyActivity = new DictionaryContainsKey
            {
                In_dictionary = new InArgument<Dictionary<object, object>>(ctx => dictionary),
                In_key = new InArgument<object>(ctx => in_key),
            };

            // Invoke the workflow synchronously and capture the results
            IDictionary<string, object> output = WorkflowInvoker.Invoke(DictionaryContainsKeyActivity);

            // Retrieve the output values from the dictionary
            var outputResult = (bool)output["Out_result"]; // Assuming "Out_result" is the output argument
            var outputValue = (object)output["Out_value"]; // Assuming "Out_value" is the output argument

            // Assert the result based on your activity's logic
            Assert.IsFalse(outputResult); // Verify that the result is true when the key exists

            // Additional assertions based on your activity's behavior
            Assert.AreNotEqual("value1", outputValue); // Verify the expected value
        }
        [TestMethod]
        public void TestBuildDictionary()
        {
            var dictionary = new Dictionary<Object, Object>();

            var stringKeys = new string[] { "test key1", "test key2" };
            var stringValues = new string[] { "test value1", "test value2" };
            

            dictionary.Add(stringKeys, stringValues);

            var buildDictionaryActivity = new BuildDictionary
            {

                In_keys = new InArgument<Object[]>((ctx) => stringKeys),
                In_values = new InArgument<Object[]>((ctx) => stringValues),
                Out_dictionary = new OutArgument<Dictionary<Object, Object>>((ctx) => dictionary)

            };

            WorkflowInvoker.Invoke(buildDictionaryActivity);

            Assert.IsTrue(dictionary.Count == 2);
        }

    }
}