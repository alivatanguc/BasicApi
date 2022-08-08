using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OtelFinder.Entities
{
    public class Room
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Capacitance { get; set; }
        virtual public ICollection<Customer> Customers { get; set; }
        virtual public ICollection<Hotel> Hotels { get; set; }
    }
}
