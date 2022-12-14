using System;
using System.Collections.Generic;
using System.Text;

namespace OtelFinder.Entities
{
    public class City :Entity
    {
        public int Id { get; set; }
        public string Name { get; set; }
         virtual public ICollection<Hotel> Hotels { get; set; }
    }
}
