using System;
using Xunit;
using leetcodeExplore.ArrayAndString;

namespace leetcodeExploreTest.ArrayAndString
{
    public class AddBinaryTest
    {
        [Theory]
        [InlineData("11","1","100")]
        [InlineData("1010", "1011", "10101")]
        public void Add_Binary_Test(string a,string b, string expected)
        {
            //Arrange

            //Act
            var target = new AddBinary();
            var actual = target.Add_Binary(a, b);
            
            //Assert
            Assert.Equal(expected, actual);
        }
    }
}
