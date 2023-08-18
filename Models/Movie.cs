using System.ComponentModel.DataAnnotations;

namespace MoviesAPI.Models
{
    public class Movie
    {
        [Key]
        public int id { get; set; }
        public string title  { get; set; }
        public int runningTime { get; set; }
        public string genre { get; set; }
    }
}
