using System.Threading.Tasks;
using Grpc.Core;
using Nx.Book;

namespace Ninjax.BookingServer.Services
{
    public class BookingService : Booking.BookingBase
    {
        public override async Task OpenSession(IAsyncStreamReader<BookingRequest> requestStream, IServerStreamWriter<BookingResponse> responseStream, ServerCallContext context)
        {
            Session session = null;
            while (await requestStream.MoveNext(context.CancellationToken))
            {
                var request = requestStream.Current;

                if (session == null)
                {
                    session = new Session(request.SessionRequest);
                    continue;
                }

                var response = await session.Handle(request, context.CancellationToken);
                await responseStream.WriteAsync(response);
            }
        }
    }
    
}