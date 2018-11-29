using System;
using Xunit;
using leetcodeExplore.ArrayAndString;

namespace leetcodeExploreTest.ArrayAndString
{
    public class AddBinaryTest
    {
        [Fact]
        public void Add_Binary_Test()
        {
            //Arrange
            string a = "11";
            string b = "1";
            string expected = "100";

            //Act
            var target = new AddBinary();
            var actual = target.Add_Binary(a, b);
            
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
