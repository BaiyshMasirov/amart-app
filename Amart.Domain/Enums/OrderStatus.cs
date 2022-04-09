using System.ComponentModel.DataAnnotations;

namespace Amart.Domain.Enums
{
    public enum OrderStatus
    {
        [Display(Name = "DRAFT")]
        Draft = 0,

        [Display(Name = "Submited")]
        Submited = 1,
    }
}