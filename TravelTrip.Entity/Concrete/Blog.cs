using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TravelTrip.Entity.Concrete
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Başlık")]
        public string Title { get; set; }
        [DisplayName("Açıklama")]
        public string Description { get; set; }
        [DisplayName("Resim")]
        public string BlogImage { get; set; }
        [DisplayName("Tarih")]
        public DateTime Date { get; set; }
        public ICollection<Comments> Comments { get; set; }
    }
}