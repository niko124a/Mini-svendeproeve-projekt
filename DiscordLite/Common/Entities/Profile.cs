using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Entities
{
    public class Profile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
    }
}
