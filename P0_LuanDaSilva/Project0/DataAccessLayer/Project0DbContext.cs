using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Models;


namespace DataAccessLayer
{ 
    public class Project0DbContext : DbContext
 {

        


     public DbSet<FloorTourUsrLine> FloorTourUsrLines{get;set;}

        public DbSet<User> Users { get; set; }
        public DbSet<Painting> Paintings {get;set;}
        public DbSet<Tour> Tours{get;set;}
        public DbSet<BaseFloor> Floors{get;set;}

public Project0DbContext(){ }
   public Project0DbContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
      {
            options.UseSqlServer("Server=localhost\\SQLEXPRESS;"
            +"Database=AbstractMuseum;"
           + "Trusted_Connection=True;"+
           "MultipleActiveResultSets=true;");
        }

            
    }
}
   