namespace Teacherfinder.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Teacher
    {
        public int TeacherId { get; set; }
        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }

        public virtual ICollection<Lesson> Lessons { get; set; }
    }
}