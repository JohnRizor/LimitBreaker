using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    public interface IGoalRepository
    {
        //   C r e a t e

        public Goal Create(Goal g);


        //   R e a d

        public IQueryable<Goal> GetAllGoals(int vehicleId);

        public Goal GetGoalById(int fillupId);


        //   U p d a t e

        public Goal Update(Goal g);


        //   D e l e t e

        public bool Delete(Goal g);
    }
}
