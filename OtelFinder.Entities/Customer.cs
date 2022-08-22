using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OtelFinder.Entities
{
    public class Customer : Entity
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CId { get; set; }
        [StringLength(50)]
        public int Age { get; set; }
       // public string Gender { get; set; }
       // public void SetGender(string gender)
       // {
            
       //     if(gender == "Female")
       //     {
       //         this.Gender = gender;
               
       //     }
       //     else if(gender == "Male")
       //     {
       //         this.Gender = gender;
       //     }
       //     else
       //     {
       //         Console.WriteLine ("error message"); 
       //     }
       // }
       //*/
        public string FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; }
        [StringLength(50)]
        public string Phone { get; set; }
        [StringLength(100)]
        public string Adress { get; set; }

        public int HotelId { get; set; }
        public int? RoomId { get; set; }
        public Hotel Hotel { get; set; }
        public Room Room { get; set; }
        //virtual public ICollection<Hotel> Hotels { get; set; }

        
    }
}
