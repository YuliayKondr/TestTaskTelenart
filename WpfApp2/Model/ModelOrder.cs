using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2.Model
{
    internal class ModelOrder
    {
        public int IdOrder { get; set; }
        public string NameClient { get; set; }
        public int CountPosition { get; set; }
        public decimal SummOrder { get; set; }
        public DateTime DateOrder { get; set; }
        public DateTime DateChange { get; set; }        
        
    }
}
