using Aviacompany.Library.Models;

namespace Aviacompany.Library.Entities
{
    public enum RequestType
    {
        Accepted,
        Rejected
    }

    public class Request
    {
        public int RequestId { get; set; }

        public RequestType RequestType { get; set; }

        public string AppUserId { get; set; } //тот кто отправляет заявку

        public AppUser AppUser { get; set; }

        public int BrigadeId { get; set; }

        public Brigade Brigade { get; set; }

        public string Message { get; set; }

    }
}