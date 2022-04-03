using System;
using System.ComponentModel.DataAnnotations;

namespace ServerApp.Models
{
    public class Todo:IEntity
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime Date { get; set; }
    }
}