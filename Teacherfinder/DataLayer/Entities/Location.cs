namespace Teacherfinder.DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.Data.Entity.Spatial;

    public class Location
    {
        public int LocationId { get; set; }
        [Required]
        public string AddressLine1 { get; set; }
        public string Suburb { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        [Required]
        public DbGeography GeoLocation { get; set; }
        //[Required]
        //public double Latitude { get; set; }
        //[Required]
        //public double Longitude { get; set; }
    }
}