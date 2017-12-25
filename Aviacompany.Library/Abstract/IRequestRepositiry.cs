using System.Collections.Generic;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Abstract
{
    public interface IRequestRepositiry
    {
        IEnumerable<Request> Requests { get; }

        void SaveRequest(Request request);

        Request DeleteRequest(int requestId);
    }
}