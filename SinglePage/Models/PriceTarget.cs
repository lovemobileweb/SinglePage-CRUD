using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SinglePage.Models
{
    public class PriceTarget
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "QA_Id is required.")]
        [Display(Name = "QA_Id")]
        [MaxLength(50)]
        public string QA_Id { get; set; }

        [Required(ErrorMessage = "AsofDate is required.")]
        [Display(Name = "AsofDate")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime AsofDate { get; set; }

        [Required(ErrorMessage = "PT_Period is required.")]
        [Display(Name = "PT_Period")]
        [MaxLength(50)]
        public string PT_Period { get; set; }

        [Required(ErrorMessage = "PriceTarget1 is required.")]
        [Display(Name = "PriceTarget1")]
        public Nullable<decimal> PriceTarget1 { get; set; }

        [Required(ErrorMessage = "DownsidePT is required.")]
        [Display(Name = "DownsidePT")]
        public Nullable<decimal> DownsidePT { get; set; }

        [Required(ErrorMessage = "BullPT is required.")]
        [Display(Name = "BullPT")]
        public Nullable<decimal> BullPT { get; set; }

        [Required(ErrorMessage = "BearPT is required.")]
        [Display(Name = "BearPT")]
        public Nullable<decimal> BearPT { get; set; }

        [Required(ErrorMessage = "CoveredBy is required.")]
        [Display(Name = "CoveredBy")]
        [MaxLength(50)]
        public string CoveredBy { get; set; }

        [Required(ErrorMessage = "PT_Note is required.")]
        [Display(Name = "PT_Note")]
        [MaxLength(50)]
        public string PT_Note { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "CreatedOn")]
        public Nullable<DateTime> CreatedOn { get; set; }

        [Display(Name = "CreatedBy")]
        [MaxLength(50)]
        public string CreatedBy { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        [Display(Name = "ModifiedOn")]
        public Nullable<DateTime> ModifiedOn { get; set; }

        [Display(Name = "ModifiedBy")]
        [MaxLength(50)]
        public string ModifiedBy { get; set; }
    }
}