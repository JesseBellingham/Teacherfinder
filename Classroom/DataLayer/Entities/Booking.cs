namespace Classroom.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Booking
    {
        public int BookingId { get; set; }
        //[Required]
        //public string LessonName { get; set; }
        public Location Location { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }        
    }
}