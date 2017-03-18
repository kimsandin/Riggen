using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Riggen.Models
{
    public class NewsModel
    {
        [Key]
        [Required]
        public int NewsId { get; set; }

        [Required]
        public string NewsText { get; set; }
        
        public DateTime DateOfNews { get; set; }


        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public virtual ICollection<GuestUserModel> GuestUsers { get; set; }

        public virtual ICollection<ImageModel> Images { get; set; }
    }
}