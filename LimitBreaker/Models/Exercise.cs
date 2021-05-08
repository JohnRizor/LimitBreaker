using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LimitBreaker.Models
{
    public class Exercise
    {
        //FIELD & PROPS
        public int Id { get; set; }
        public string ExerciseType { get; set; }

        [Required(ErrorMessage = "Repetition  the Exercise is Required (Format #/#/#/#/#)")]
        public string Repetition { get; set; }
        [Required(ErrorMessage = "Set(s) is/are Required")]
        public int Set { get; set; }
        [Required(ErrorMessage = "Date is Required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Weight Amounts are Required (Format ###/###/###/###/###)")]
        public string WeightAmount { get; set; }
        public string Percentage { get; set; }
        public string Description { get; set; }
        public bool? Completed { get; set; }
        public int MaxId { get; set; }
        public Max Max { get; set; }

        // CONSTRUCTORS


        //METHODS
    }
}
