using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    public class Max
    {
        //FIELD & PROPS
        public int Id { get; set; }
        [Required(ErrorMessage = "Exercise Type is Required")]
        public string Exercise { get; set; }
        [Required(ErrorMessage = "Weight Amount is Required")]
        public int WeightAmount { get; set; }
        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        public string DifficultyLevel { get; set; }
        public bool? NewMax { get; set; }
        public bool? Completed { get; set; }
        public IEnumerable<Exercise> Exercises { get; set; }
        public int GoalId { get; set; }
        public Goal Goal { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

        // CONSTRUCTORS


        //METHODS
    }
}
