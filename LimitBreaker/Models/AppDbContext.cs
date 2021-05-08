using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    public class AppDbContext : DbContext 
    {
        public DbSet<User>  Users { get; set; }
        public DbSet<Goal> Goals { get; set; }
        public DbSet<Max> Maxes { get; set; }
        public DbSet<Exercise> Exercise { get; set; }


        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            //   U s e r s

            modelBuilder.Entity<User>().HasIndex(u => u.Username).IsUnique();

            // modelBuilder.Entity<User>().HasData(new User { Id = 1, UserName = "BantaP@ERAU.Edu", Password = "Wombat1" });


            //   V e h i c l e s

            modelBuilder.Entity<Goal>().HasData(new Goal
            {
                Id = 1,
                ExerciseType = "Squat",
                Date = new System.DateTime(2021, 05, 01),
                GoalDescription = "Squat 350 by next month.",
                UserId = 1
            });

            modelBuilder.Entity<Goal>().HasData(new Goal
            {
                Id = 2,
                ExerciseType = "Bench",
                Date = new System.DateTime(2021, 05, 02),
                GoalDescription = "I want to be able to bench 275.",
                UserId = 1
            }); ;


            //   F i l l u p s

            modelBuilder.Entity<Max>().HasData(new Max
            {
                Id = 1,
                Exercise = "Squat",
                WeightAmount = 450,
                Date = new System.DateTime(2021, 05, 01),
                DifficultyLevel = "Very Hard",
                NewMax = true,
                Completed = true,
                GoalId = 1,
                
            });


            modelBuilder.Entity<Max>().HasData(new Max
            {
                Id = 1,
                Exercise = "Bench",
                WeightAmount = 185,
                Date = new System.DateTime(2021, 05, 02),
                DifficultyLevel = "Hard",
                NewMax = true,
                Completed = false,
                GoalId = 2,
            });
            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 1,
                ExerciseType = "Squat",
                Repetition = "10/8/6/4/2",
                Set = 5,
                Date = new System.DateTime(2021, 05, 01),
                WeightAmount = "100,125,150,175,200",
                Percentage = null,
                Description = "A simple progression workout toward my squat goal",
                Completed = true,
                MaxId = 1
            });
            modelBuilder.Entity<Exercise>().HasData(new Exercise
            {
                Id = 2,
                ExerciseType = "Bench",
                Repetition = "8/6/4/2",
                Set = 4,
                Date = new System.DateTime(2021, 05, 02),
                WeightAmount = "125,150,175,200",
                Percentage = null,
                Description = "One step closer to my Bench goal",
                Completed = true,
                MaxId = 2
            });
        }


    }
}
