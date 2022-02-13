using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mission5Real.Models
{
    public class MovieInputContext : DbContext
    {
        //Constructor
        public MovieInputContext(DbContextOptions<MovieInputContext> options) : base (options)
        {

        }
        public DbSet<MovieResponse> Responses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.Entity<Category>().HasData(
                new Category {  CategoryId = 1, CategoryName="Action/Adventure"},
                new Category { CategoryId = 2, CategoryName = "Family" },
                new Category { CategoryId = 3, CategoryName = "Television" }
                );

            mb.Entity<MovieResponse>().HasData(
                new MovieResponse
                {
                    MovieId = 1,
                    CategoryId = 1,
                    Title = "The Dark Knight",
                    Year = 2008,
                    Director = "Christian Nolan",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieResponse
                {
                    MovieId = 2,
                    CategoryId = 2,
                    Title = "The Sandlot",
                    Year = 1993,
                    Director = "David Mickey Evans",
                    Rating = "PG",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                },
                new MovieResponse
                {
                    MovieId = 3,
                    CategoryId = 1,
                    Title = "Pirates of the Carribean: The Curse of the Black Pearl",
                    Year = 2003,
                    Director = "Gore Verbinski",
                    Rating = "PG-13",
                    Edited = false,
                    LentTo = "",
                    Notes = ""
                }
                );
        }
    }
}
