using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models
{
    internal class Harvest
    {
        public int Id { get; set; }
        public int PlanId { get; set; }
        public DateTime Date { get; set; }
        public int Weight { get; set; }
    }
}
