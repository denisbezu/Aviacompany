using System.Collections.Generic;
using System.Data.Entity;
using Aviacompany.Library.Abstract;
using Aviacompany.Library.DataAccess;
using Aviacompany.Library.Entities;

namespace Aviacompany.Library.Concrete
{
    public class RequestRepository : IRequestRepositiry
    {
        AviaCompanyContext context = new AviaCompanyContext();
        public IEnumerable<Request> Requests
        {
            get
            {
                context.Requests.Load();
                context.Users.Load();
                context.Brigades.Load();
                return context.Requests;
            }
        }
        public void SaveRequest(Request request)
        {
            if (request.RequestId == 0)
                context.Requests.Add(request);
            else
            {
                Request dbEntry = context.Requests.Find(request.RequestId);
                if (dbEntry != null)
                {
                    dbEntry.Message = request.Message;
                    dbEntry.RequestType = request.RequestType;
                    dbEntry.BrigadeId = request.BrigadeId;
                }
            }
            context.SaveChanges();
        }
        public Request DeleteRequest(int requestId)
        {
            Request dbEntry = context.Requests.Find(requestId);
            if (dbEntry != null)
            {
                context.Requests.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}