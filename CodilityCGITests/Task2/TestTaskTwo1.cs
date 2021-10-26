using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CodilityCGI.Task2;

namespace CodilityCGITests.Task2 {
    
    /// <summary>
    /// Summary description for TestTaskOne1
    /// </summary>
    [TestClass]
    public class TestTaskTwo1 {

        #region Advanced Methods
        public TestTaskTwo1()
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

        int[] roads = new int[] {9, 0x1, 4, 9, 0, 4, 8, 9, 0, 1};
        int[] distances = new int[] {1, 3, 2, 3, 0, 0, 0, 0, 0};

        [TestMethod]
        public void TestMethod1()
        {
            int[] roads = new int[] { 9, 0x1, 4, 9, 0, 4, 8, 9, 0, 1 };
            int[] distances = new int[] { 1, 3, 2, 3, 0, 0, 0, 0, 0 };
            Solution solution = new Solution();
            solution.SetMap(roads);
            int expected = 1;
            int real = solution.GetCapital().OursSide;
            Assert.AreEqual(expected, real);
        }


        [TestMethod]
        public void TestNeighbors()
        {
            int[] roads = new int[] { 9, 0x1, 4, 9, 0, 4, 8, 9, 0, 1 };
            int[] distances = new int[] { 1, 3, 2, 3, 0, 0, 0, 0, 0 };
            Solution solution = new Solution();
            solution.SetMap(roads);
            var capital= solution.GetCapital();
            solution.GoToNeighBords(solution._Roads, capital.OursSide);
            var neig = solution._Roads.Where(x=>!x.IsCapital);
            foreach (var n in neig)
                Console.WriteLine(String.Format("{0} - {1}", n.OursSide, n.DistanceToCapital));
        }

        [TestMethod]
        public void ShowRoads()
        {
            int[] roads = new int[] { 9, 0x1, 4, 9, 0, 4, 8, 9, 0, 1 };
            Solution solution = new Solution();
            solution.SetMap(roads);
            var neig = solution._Roads.Where(x => !x.IsCapital);
            foreach (var n in neig)
                Console.WriteLine(String.Format("From {0} to {1}", n.OursSide, n.ForeignSide));

        }


        [TestMethod]
        public void TestFinalSolution()
        {
            var sourceArray = new int[] { 9, 1, 4, 9, 0, 4, 8, 9, 0, 1 };
            var expected = new int [] { 1, 3, 2, 3, 0, 0, 0, 0, 0 };
            Solution solution = new Solution();
            var ream = solution.solution(sourceArray);
            Assert.IsTrue(expected.SequenceEqual(ream));
        }
    }
}
