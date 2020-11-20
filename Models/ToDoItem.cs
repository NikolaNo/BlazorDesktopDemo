using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesktopDemo.Models
{
    public class ToDoItem
    {
        [Key]
        public string id { get; set; }
        
        [StringLength(80)]
        [Required]
        public string Description { get; set; }

        public bool IsDone { get; set; }
        
        [StringLength(80)]      
        public string Comment {get; set;}

        public DateTime finishedDate {get;set;}
    }

}