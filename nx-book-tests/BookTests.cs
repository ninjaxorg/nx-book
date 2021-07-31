using Ninjax.BookLib;
using Xunit;

namespace nx_book_tests
{
    public class BookTests
    {
        [Fact]
        public void T()
        {
            var book = new Book();

            var request = new OrderRequest();

            var order = book.PlaceOrder(request);
            
        }
    }
}