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
        public void TestClearDictionary()
        {
            //Create a dictionary with some test key, value pairs
            var dictionary = new Dictionary<object, object>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };

            //create the Clear Dictionary function
            var clearDictionaryActivity = new ClearDictionary
            {
                In_Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
            };

            //Invoke the workflow
            WorkflowInvoker.Invoke(clearDictionaryActivity);

            //Assert the count of the Dictionary is 0
            Assert.IsTrue(dictionary.Count == 0);
        }

        [TestMethod]
        public void TestDictionaryToString()
        {
            //Create a dictionary with some test key, value pairs
            var dictionary = new Dictionary<object, object>
            {
                { "key1", "value1" },
                { "key2", "value2" },
            };
            string expectedvalue = "[key1, value1], [key2, value2]";
            string outputvalue = String.Empty;

            //create the DictionaryToSting function
            var DictionaryToStringActivity = new DictionaryToString
            {
                In_Dictionary = new InArgument<Dictionary<Object, Object>>(ctx => dictionary),
            };

            //Invoke the workflow
            var output = WorkflowInvoker.Invoke(DictionaryToStringActivity);

            outputvalue = (string)output["Result"]; // "Result" is the output argument as described in the wizard

            // Matches expected value
            Assert.AreEqual(outputvalue, expectedvalue); // Verify the expected value
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

        [TestMethod]
        public void TestUpdateDictionary()
        {
            // Create a dictionary with a test key, value pair
            var dictionary = new Dictionary<Object, Object>();

            var stringKey = "test key";
            var stringValue = "test value";

            dictionary.Add(stringKey, stringValue);

            // Create the UpdateDictionary function
            var updateDictionaryActivity = new UpdateDictionary
            {
                In_Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
                In_Key = new InArgument<Object>((ctx) => stringKey),
                In_Value = new InArgument<Object>((ctx) => stringKey),
            };

            // Invoke the workflow synchronously and capture the results
            IDictionary<string, object> output = WorkflowInvoker.Invoke(updateDictionaryActivity);

            // Retrieve the output value from the dictionary
            var outputResult = (bool)output["Out_Result"]; // Assuming "Out_Result" is the output argument

            // Assert the result based on your activity's logic
            Assert.IsTrue(outputResult);
        }
    
        public void TestDictionaryGetValues()
        {
            var dictionary = new Dictionary<Object, Object>();
            var objectResult = new List<Object>();
            var stringKey = "test key";
            var stringValue = "test value";

            dictionary.Add(stringKey, stringValue);
            
            stringKey = "test key 2";
            stringValue = "test value 2";

            dictionary.Add(stringKey, stringValue);

            var dictionaryGetValues = new GetDictionaryValues
            {
                Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
                Result = new OutArgument<List<Object>>((ctx) => objectResult),
            };

            WorkflowInvoker.Invoke(dictionaryGetValues);

            Assert.IsTrue(objectResult.Count == 2);
        }

        [TestMethod]
        public void TestGetDictionaryKeys()
        {
            var dictionary = new Dictionary<Object, Object>();
            var objectResult = new List<Object>();
            var stringKey = "test key";
            var stringValue = "test value";
            var stringKey2 = "test key2";
            var stringValue2 = "test value2";

            dictionary.Add(stringKey, stringValue);
            dictionary.Add(stringKey2, stringValue2);

            var dictionaryGetKeys = new GetDictionaryKeys
            {
                In_Dictionary = new InArgument<Dictionary<Object, Object>>((ctx) => dictionary),
                Out_Keys = new OutArgument<List<Object>>((ctx) => objectResult),
            };

            WorkflowInvoker.Invoke(dictionaryGetKeys);

            Assert.IsTrue(objectResult[0].ToString() == stringKey && objectResult[1].ToString() == stringKey2);
        }

    }

}
