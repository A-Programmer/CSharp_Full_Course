using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrades()
        {
            //arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(77);
            book.AddGrade(97);
            book.AddGrade(37);


            //act
            var result = book.GetStats();
            

            //assert
            Assert.Equal(75.03, result.Average, 2);
            Assert.Equal(97, result.High);
            Assert.Equal(37, result.Low);

            
        }
    }
}
