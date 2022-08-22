using OtelFinder.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OtelFinder.Entities
{
    public class Reservation :Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }
        public string Name { get; set; }
        public double RoomPrice { get; set; }
        public int Star { get; set; }

    }
}