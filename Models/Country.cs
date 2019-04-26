using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Country : Entity
    {
        public ICollection<City> Cities { get; set; }
    }
}
