using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    public class Goal // POCO
    {
        //FIELDS AND PROPS
        public int Id { get; set; }
        [Required(ErrorMessage = "Exercise Type is Required")]
        public string ExerciseType { get; set; }
        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Description is Required")]
        public string GoalDescription { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<Max> Maxes { get; set; }


        //CONSTRUCTORS


        //METHODS
    }
}
