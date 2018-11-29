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
    public class TreaterModel
    {
        public List<Treater> TreaterList { get; set; }
        public List<Candy> CandyList { get; set; }
        public List<Costume> CostumeList { get; set; }


        public int TreaterID;

        [Required(ErrorMessage = "Treater needs a name")]
        [DisplayName("Treater's Name")]
        public string TreaterName { get; set; }

        [Required(ErrorMessage ="Treater needs a favorite Candy")]
        [DisplayName("Treater's Favorite Candy")]
        [UIHint("CandyDropdown")]
        public int CandyID { get; set; }
        public string CandyName { get; set; }
        [Required(ErrorMessage = "Treater needs a costume")]
        [DisplayName("Treater's costume")]
        [UIHint("CostumeDropdown")]
        public int CostumeID { get; set; }
        public string CostumeName { get; set; }
    }
}
