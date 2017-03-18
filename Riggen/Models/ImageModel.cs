using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Riggen.Models
{
    public class ImageModel
    {
        [Key]
        public int ImageId { get; set; }

        public string ImagePath { get; set; }

        public string ImageName { get; set; }


        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<NewsModel> News { get; set; }


    }
}