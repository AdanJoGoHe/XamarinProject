using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using oldSolutions;

namespace Hash
{
    [TestClass]
    public class HashTest
    {
        [TestMethod]
        public void Test_Hash()
        {
            //Arrange
            string expected = "dd94709528bb1c83d08f3088d4043f4742891f4f";
            string toTest = "adminadmin";

            //Act
            Core core = new Core();
            string actual = core.Hash(toTest);

            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
