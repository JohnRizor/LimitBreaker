using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    public class EfExerciseRepository : IExerciseRepository
    {
        //FIELD & PROP
        private AppDbContext _context;

        //CONSTRUCTOR

        public EfExerciseRepository(AppDbContext context)
        {
            _context = context;
        }

        //METHODS

        //CREATE

        
        public Exercise Create(Exercise e)
        {
            _context.Exercise.Add(e);
            _context.SaveChanges();
            return e;
        }

        //Read
        public IQueryable<Exercise> GetAllExercises(int maxId)
        {
            return _context.Exercise.Where(e => e.MaxId == maxId);
        }

        public Exercise GetExerciseById(int exerciseId)
        {
            return _context.Exercise.FirstOrDefault(e => e.Id == exerciseId);
        }


        public Exercise Update(Exercise e)
        {
            Exercise exerciseToUpdate = GetExerciseById(e.Id);
            if(exerciseToUpdate != null)
            {
                exerciseToUpdate.ExerciseType = e.ExerciseType;
                exerciseToUpdate.Completed = e.Completed;
                exerciseToUpdate.Date = e.Date;
                exerciseToUpdate.Description = e.Description;
                exerciseToUpdate.Percentage = e.Percentage;
                exerciseToUpdate.Repetition = e.Repetition;
                exerciseToUpdate.Set = e.Set;
                exerciseToUpdate.WeightAmount = e.WeightAmount;
                _context.SaveChanges();
            }
            return exerciseToUpdate;
        }
        public bool Delete(Exercise e)
        {
            Exercise exerciseToDelete = GetExerciseById(e.Id);
            if(exerciseToDelete == null)
            {
                return false;
            }
            _context.Exercise.Remove(exerciseToDelete);
            _context.SaveChanges();
            return true;
        }
    }
}
