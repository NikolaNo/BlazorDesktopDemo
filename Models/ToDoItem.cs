using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesktopDemo.Models
{
    public class ToDoItem
    {
        [Key]
        public string id { get; set; }
        
        public string Description { get; set; }

        public bool IsDone { get; set; }
           
        public string Comment {get; set;}        
       
        public string Category {get;set;}

        public DateTime finishedDate {get;set;}
    }

}