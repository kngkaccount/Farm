using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models
{
    internal class Plan
    {
        public int Id { get; set; }
        public int FieldId { get; set; }
        public int SeedsId { get; set; }
        public int Weight { get; set; }
        public DateTime Date { get; set; }

        public string FieldName { get; set; }
        public string SeedsName { get; set; }

    }
}
