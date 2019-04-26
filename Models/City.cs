using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class City : Entity
    {
        public ICollection<Street> Streets { get; set; }
        public Country Country { get; set; }
    }
}
