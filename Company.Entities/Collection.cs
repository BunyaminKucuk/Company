using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Microsoft.VisualBasic;
using Microsoft.VisualBasic.CompilerServices;

namespace Company.Entities
{
    public class Collection
    {
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CollectionId { get; set; }
        [Required ]
        public float CollectionPaymentAmount  { get; set; }
        [Required]
        public string CollectionPaymentDate  { get; set; }
        [Required]
        [ForeignKey("Project")]
        public  int ProjectId{ get; set; }
    }
}
