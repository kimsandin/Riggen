using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Riggen.Models
{
    public class GuestUserModel
    {   
        [Key]
        [Required]
        public int GuestUserId { get; set; }
        
        [Required]
        [Display(Name = "Gästspelare")]
        public string GuestUserName { get; set; }


        public virtual ICollection<NewsModel> News { get; set; }
       
        public virtual ICollection<TournamentModel>Tournaments { get; set; }

        public virtual ICollection<ResultModel> Results { get; set; }
    }
}