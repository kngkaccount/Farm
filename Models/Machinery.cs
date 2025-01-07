using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farm.Models
{
    internal class Machinery
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Information { get; set; }
        public int FieldId { get; set; }

        public string FieldName { get; set; }
    }
}
