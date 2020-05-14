using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void Test1()
        {
            var x = GetInt();
            SetInt(x);

            Assert.Equal(42, x);
        }

        private void SetInt(int x)
        {
            x=42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassbyRef()
        {   

            var book1 = GetBook("Book 1");
            GetBookRefSetName(out book1,"New Name");

            Assert.Equal("New Name",book1.Name);

        }

        private void GetBookRefSetName(out Book book, string name)
        {/* out and ref are similar

            The only difference is that with the out parameter 
            C# assumes that the incoming reference has been initialized 
            and so it will be an error if you do not assign to a parameter.

        */
            book=new Book(name);
        }

        [Fact]
        public void CSharpIsPassbyValue()
        {   

            var book1 = GetBook("Book 1");
            GetBookSetName(book1,"New Name");

            Assert.Equal("Book 1",book1.Name);

        }

        private void GetBookSetName(Book book, string name)
        {
            book=new Book(name);
        }


        [Fact]
        public void CanSetNameFromReference()
        {   

            var book1 = GetBook("Book 1");
            SetName(book1,"New Name");

            Assert.Equal("New Name",book1.Name);

        }

        private void SetName(Book book1, string name)
        {
            book1.Name=name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {   

            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1",book1.Name);
            Assert.Equal("Book 2",book2.Name);

        }

        [Fact]
          public void TwoVarsCanRefSameObject()
        {   

            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));

        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
