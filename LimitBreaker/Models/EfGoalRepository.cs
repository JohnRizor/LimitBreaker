using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    public class EfGoalRepository
        : IGoalRepository
    {
        //FIELD & PROP

        private AppDbContext _context;

        //CONSTRUCTORS
        public EfGoalRepository(AppDbContext context)
        {
            _context = context;
        }

        //METHODS

        //CREATE

        public Goal Create(Goal g)
        {
            _context.Goals.Add(g);
            _context.SaveChanges();
            return g;
        }

        //READ

        public IQueryable<Goal> GetAllGoals(int userId)
        {
            return _context.Goals.Where(g => g.UserId == userId);
        }

        public Goal GetGoalById(int goalId)
        {
            return _context.Goals.FirstOrDefault(g => g.Id == goalId);
        }

        // Update

        public Goal Update(Goal g)
        {
            Goal goalToUpdate = GetGoalById(g.Id);
            if (goalToUpdate != null)
            {
                goalToUpdate.ExerciseType = g.ExerciseType;
                goalToUpdate.Date = g.Date;
                goalToUpdate.GoalDescription = g.GoalDescription;
                _context.SaveChanges();
            }
            return goalToUpdate;
        }
        //DELETE

        public bool Delete(Goal g)
        {
            Goal goalToDelete = GetGoalById(g.Id);
            if(goalToDelete == null)
            {
                return false;
            }
            _context.Goals.Remove(goalToDelete);
            _context.SaveChanges();
            return true;
        }


    }
}
