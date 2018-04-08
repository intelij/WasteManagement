using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildIndia.ViewModel
{
    public class CompactorViewModel
    {
        public int Id { get; set; }
        public string CompactorNumber { get; set; }
        public string Size { get; set; }
        public string Make { get; set; }
        public Nullable<int> LocationId { get; set; }
        public string Location { get; set; }
    }
}
