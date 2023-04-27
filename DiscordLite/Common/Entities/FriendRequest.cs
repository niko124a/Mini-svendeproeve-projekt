using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class FriendRequest
    {
        public int Id { get; set; }
        public int SenderUserId { get; set; }
        public int ReceiverUserId { get; set; }
        public DateTime RequestDate { get; set; }


    }
}
