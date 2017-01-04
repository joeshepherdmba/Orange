using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orange.TransferObjects
{
    public class UserEntity
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }
        public byte[] Photo { get; set; }
        public virtual List<ItemEntity> Items { get; set; }
    }
}
