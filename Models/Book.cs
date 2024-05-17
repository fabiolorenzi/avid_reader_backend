using System.ComponentModel.DataAnnotations;

namespace AvidReaderBackend.Models
{
    public class Book
    {
        [Key]
        public int Id {get; set;}
        public int UserId {get; set;}
        public string Title {get; set;}
        public string Author {get; set;}
        public float Cost {get; set;}
        public int Rating {get; set;}
    }
}