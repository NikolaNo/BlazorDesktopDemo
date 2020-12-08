using System;
using BlazorDesktopDemo.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorDesktopDemo.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<ToDoItem> Items {get;set;}
        public DbSet<Notebook> Notebooks { get;set;}
        public DbSet<Calendar> Calendars {get;set;}
    }


}