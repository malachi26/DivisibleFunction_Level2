using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DivisibleFunction_Level2;

namespace DivisibleFunctionTest1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var testVariable = DivisibleFunction_Level2.Program.isDivisibleBy(9, 9);
            Assert.AreEqual(testVariable, true);
        }
        [TestMethod]
        public void TestMethod2()
        {
            var testVariable = DivisibleFunction_Level2.Program.isDivisibleBy(93, 9);
            Assert.AreEqual(testVariable, false);
        }
        [TestMethod]
        public void TestMethod3()
        {
            var testVariable = DivisibleFunction_Level2.Program.isDivisibleBy(36,6);
            Assert.AreEqual(testVariable, true);
        }
    }

    [TestClass]
    public class Test_isDivby9
    {
        [TestMethod]
        public void TestMethod_isDivby9_1()
        {
            var testVariable = DivisibleFunction_Level2.Program.isDivby9(9);
            Assert.AreEqual(testVariable, true);
        }
        [TestMethod]
        public void TestMethod_isDivby9_2()
        {
            var testVariable = DivisibleFunction_Level2.Program.isDivby9(93);
            Assert.AreEqual(testVariable, false);
        }
    }
}
