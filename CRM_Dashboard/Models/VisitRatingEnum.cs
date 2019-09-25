using System.ComponentModel.DataAnnotations;

namespace CRM_Dashboard.Models
{
    public enum VisitRatingEnum
    {
        [Display(Name = "Very Unsatisfied")]
        VeryUnsatisfied = 1,

        [Display(Name = "Unsatisfied")]
        Unsatidfied = 2,

        [Display(Name = "Neutral")]
        Neutral = 3,

        [Display(Name = "Satisfied")]
        Satisfied = 4,

        [Display(Name = "Very Satisfied")]
        VerySatisfied = 5
    }

}
