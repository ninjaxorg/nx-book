using System.Threading;
using System.Threading.Tasks;
using Nx.Book;

namespace Ninjax.BookingServer.Services
{
    public class Session
    {
        public Session(SessionRequest sessionRequest)
        {
        }

        public async Task<BookingResponse> Handle(BookingRequest request, CancellationToken cancellationToken)
        {
            return new BookingResponse();
        }
    }
}