using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Test1_True()
        {
            MarsRover.Program.Run("5 5");
            string result = MarsRover.Program.ReadProcess("1 2 N","LMLMLMLMM",true);
            if (result != "1 3 N")
            {
                throw new Exception("Error");
            }
        }
        [TestMethod]
        public void Test1_False()
        {
            MarsRover.Program.Run("5 5");
            string result = MarsRover.Program.ReadProcess("1 3 N", "LMLMLMLMM", true);
            if (result == "1 3 N")
            {
                throw new Exception("Error");
            }
        }

        [TestMethod]
        public void Test2_True()
        {
            MarsRover.Program.Run("5 5");
            string result = MarsRover.Program.ReadProcess("3 3 E", "MMRMMRMRRM", true);
            if (result != "5 1 E")
            {
                throw new Exception("Error");
            }
        }

        [TestMethod]
        public void Test2_False()
        {
            MarsRover.Program.Run("5 5");
            string result = MarsRover.Program.ReadProcess("1 3 E", "MMRMMRMRRM", true);
            if (result == "5 1 E")
            {
                throw new Exception("Error");
            }
        }
    }
}
