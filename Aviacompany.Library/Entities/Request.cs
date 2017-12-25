using System.ComponentModel.DataAnnotations;
using Aviacompany.Library.Models;

namespace Aviacompany.Library.Entities
{
    public enum RequestType
    {
        None,
        Accepted,
        Rejected
    }

    public class Request
    {
        public int RequestId { get; set; }

        public RequestType RequestType { get; set; }

        public int BrigadeId { get; set; }

        public Brigade Brigade { get; set; }
        [Display(Name = "Сообщение")]
        public string Message { get; set; }

    }
}