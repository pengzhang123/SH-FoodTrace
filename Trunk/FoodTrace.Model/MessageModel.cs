using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrace.Model
{
    public class MessageModel
    {
        public MessageStatus Status { get; set; }
        public string Message { get; set; }
        public int NewBusinessId { get; set; }
    }
    public enum MessageStatus
    {
        Success,
        Error,
        Exception
    }
}
