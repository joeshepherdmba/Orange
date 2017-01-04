using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orange.Model
{
    public class Share
    {
        public int Id { get; set; }
        public DateTime DateShared { get; set; }
        public string Message { get; set; }
        public string  Recipient { get; set; }

        public virtual MarketingItem Item { get; set; }

        
    }
}
