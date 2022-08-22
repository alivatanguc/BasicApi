using FluentValidation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Xunit;

namespace OtelFinder.Entities
{
    public class Hotel : Entity
    {
       

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]//VERİ TABANIMIZDAKİ PRİMARY KEYİ BELİRLEMEK İÇİN KULLNADIĞIMIZ YAPI
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        public string Name { get; set; }
        [StringLength(50)]
        [Required]
        public int CityId { get; set; }
        public int CategoryId { get; set; }
        public int CountryId { get; set; }
        public int NumberOfRoom { get; set; }
        public double RoomPrice { get; set; }
        public int Star { get; set; }
        public int? RoomId { get; set; }
        public Category Category { get; set; }
        public Country Country { get; set; }
        public City City { get; set; }
        public Room Room { get; set; }

        virtual public ICollection<Customer> Customers { get; set; }

        public static object OfType<T>()
        {
            throw new NotImplementedException();
        }


      
       







    }
    
       
        
    
}
