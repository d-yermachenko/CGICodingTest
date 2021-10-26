using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodilityCGI.Task1;

namespace CodilityCGITests.Task1 {
    /// <summary>
    /// Summary description for TestTaskOne1
    /// </summary>
    [TestClass]
    public class TestTaskOne1 {



        #region Test class advanced methods
        public TestTaskOne1()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion
        #endregion

        [TestMethod]
        public void TestSequenceTwo()
        {
            string stackCommands = "13 DUP 4 POP 5 DUP + DUP + -";
            uint expected = 7;
            uint result = new StackMachine().Perform(stackCommands);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestSequenceOne()
        {
            string stackCommands = "4 5 6 - 7 +";
            uint expected = 8;
            uint result = new StackMachine().Perform(stackCommands);
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        public void TestOverflow()
        {
            try
            {
                string stackCommands = String.Format("{0} {1} +", UInt32.MaxValue - 1024, UInt32.MaxValue - 1024);
                uint expected = 8;
                uint result = new StackMachine().Perform(stackCommands);
                Assert.IsTrue(false);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArithmeticException));
            }
            
        }
    }
}
