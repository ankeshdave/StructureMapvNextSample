using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.DN46
{
    public class TestClass1:ITestClass1
    {
        public TestClass1(ITestClass2 testClass2)
        {
            testClass2.TestString = "I was created by a nested Container";
        }

    }

    public interface ITestClass1
    {
    }

    public class TestClass2:ITestClass2
    {
        public string TestString { get; set; }
    }

    public interface ITestClass2
    {
        string TestString { get; set; }
    }
}
