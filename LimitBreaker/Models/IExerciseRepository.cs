using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    public interface IExerciseRepository
    {
        //   C r e a t e

        public Exercise Create(Exercise e);


        //   R e a d

        public IQueryable<Exercise> GetAllExercises(int maxId);

        public Exercise GetExerciseById(int id);


        //   U p d a t e

        public Exercise Update(Exercise e);


        //   D e l e t e

        public bool Delete(Exercise e);
    }
}
