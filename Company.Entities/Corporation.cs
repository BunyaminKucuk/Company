using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Company.Entities
{
    public class Corporation
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CompanyId  { get; set; }
        [Required]
        [StringLength(50)]
        public string CompanyName  { get; set; }
        [Required]
        [StringLength(100)]
        public string CompanyAddress  { get; set; }
        [Required]
        [StringLength(11)]
        public string CompanyPhone  { get; set; }

    }
}
