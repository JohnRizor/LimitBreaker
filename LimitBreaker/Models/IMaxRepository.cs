using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    public interface IMaxRepository
    {
        //   C r e a t e

        public Max Create(Max m);


        //   R e a d

        public IQueryable<Max> GetAllMaxes();

        public Max GetMaxById(int maxId);


        //   U p d a t e

        public Max Update(Max m);


        //   D e l e t e

        public bool Delete(int id);
    }
}
