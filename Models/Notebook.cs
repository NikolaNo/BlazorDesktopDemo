using System;
using System.ComponentModel.DataAnnotations;

namespace BlazorDesktopDemo.Models
{
  public class Notebook
  {
      [Key]
      public string id { get; set; }

      public string Note {get;set;}

      public DateTime Date { get;set;}

      public string Category { get;set;}  

  }


}