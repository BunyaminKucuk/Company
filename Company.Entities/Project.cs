using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Company.Entities
{
    public class Project
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProjectId  { get; set; }
        [Required]
        [StringLength(100)]
        public string ProjectName  { get; set; }
        [Required]
        public string ProjectStarTime { get; set; }
        [Required]
        public string ProjectFinishTime { get; set; }
        [Required]
        public float ProjectFee  { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId  { get; set; }
    }
}
