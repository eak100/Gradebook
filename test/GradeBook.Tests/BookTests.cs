using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void Test1()
        {   /*//there are 3 sections
            //arrange
            var x=5;
            var y=2;
            var expected =7;
            //act
            var actual=x+y;
            //assert
            Assert.Equal(expected, actual);*/

            // Arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act
            var result= book.GetStatistics();

            //Assert
            Assert.Equal(85.6, result.Average,1);
            Assert.Equal(90.5, result.High,1);
            Assert.Equal(77.3, result.Low,1);

        }
    }
}
