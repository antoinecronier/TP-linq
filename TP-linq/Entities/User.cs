using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_linq.Entities
{
    public class User
    {
        public long? Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
        public List<Car> Cars { get; set; } = new List<Car>();
    }
}
