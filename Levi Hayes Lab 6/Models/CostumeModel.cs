using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using BusinessObjects;


namespace Levi_Hayes_Lab_6.Models
{
    public class CostumeModel
    {
        public List<Costume> CostumeList { get; set; }

        [DisplayName("Costume Name")]
        [Required(ErrorMessage = "Please enter a name of a costume")]
        public string CostumeName { get; set; }
    }
}
