using System;
using System.Collections.Generic;
using System.Text;

namespace MS_Exam70_483.ProxyPattern
{
    //ISubject
    public interface IBookParser
    {
        int GetNumberOfPages();
    }
    //Real Subject
    public class BookParser : IBookParser
    {
        public BookParser(string book)
        {
            //Expensive Operation.
        }
        public int GetNumberOfPages()
        {
            throw new NotImplementedException();
        }
    }
    //proxy Following Same interface of ISubject
    public class LazyBookParserProxy : IBookParser
    {
        private string _book;
        private BookParser bookParser = null;
        public LazyBookParserProxy(string book)
        {
            // Delaying the instantiation of the Actual book Parser
            _book = book;
        }
        public int GetNumberOfPages()
        {
            //Constructing book parse only when the method is invoked
            if(bookParser == null)
            {
                this.bookParser = new BookParser(_book);
            }
            return this.bookParser.GetNumberOfPages();
            throw new NotImplementedException();
        }
    }
}
