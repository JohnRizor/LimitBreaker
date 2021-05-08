using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    public class EfMaxRepository : IMaxRepository
    {
        //FIELDS & PROPS
        private AppDbContext _context;
        private IUserRepository _userRepository;

        //CONSTRUCTORS
        
        public EfMaxRepository(AppDbContext context, IUserRepository userRepository)
        {
            _context = context;
            _userRepository = userRepository;
        }

        //METHODS

        //CREATE


        public Max Create(Max m)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                try
                {
                    m.UserId = _userRepository.GetLoggedInUserId();
                    _context.Maxes.Add(m);
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    // return null; // Maybe
                }
                return m;
            }

            return null;
        }


        //   R e a d

        public IQueryable<Max> GetAllMaxes()
        {
            if (_userRepository.IsUserLoggedIn())
            {
                return _context.Maxes.Where(m => m.UserId == _userRepository.GetLoggedInUserId());
            }

            Max[]  newMax = new Max[0];
            return newMax.AsQueryable<Max>();
        }

        public Max GetMaxById(int id)
        {
            if (_userRepository.IsUserLoggedIn())
            {
                Max m = _context.Maxes
                                .Include(m => m.Goal)
                                .FirstOrDefault(m => m.Id == id && m.UserId == _userRepository.GetLoggedInUserId());
                if (m != null)
                {
                    //m.Goal = m.Goal.OrderByDescending(f => f.Odometer);
                    return m;
                }
                return m;
            }
            
            return null;
        }


        //   U p d a t e

        public Max Update(Max m)
        {
            Max maxToUpdate = GetMaxById(m.Id);
            if (maxToUpdate != null)
            {
                maxToUpdate.Exercise = m.Exercise;
                maxToUpdate.WeightAmount = m.WeightAmount;
                maxToUpdate.Date = m.Date;
                maxToUpdate.DifficultyLevel = m.DifficultyLevel;
                maxToUpdate.NewMax = m.NewMax;
                maxToUpdate.Completed = m.Completed;
                
                try
                {
                    _context.SaveChanges();
                }
                catch (Exception e)
                {
                    // return null; // Maybe
                }
            }
            return maxToUpdate;
        }


        //   D e l e t e

        public bool Delete(int id)
        {
            Max maxToDelete = GetMaxById(id);
            if (maxToDelete == null)
            {
                return false;
            }

            try
            {
                _context.Maxes.Remove(maxToDelete);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
            }

            return false;
        }

        
    }
}
