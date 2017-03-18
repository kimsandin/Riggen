using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Riggen.Models
{
    public class ResultModel
    {
        [Key]
        [Required]
        public int ResultId { get; set; }

        public DateTime Date { get; set; }

        public decimal NewScore { get; set; }

        public decimal ResultHistory { get; set; }

        public decimal TotalScore { get; set; }


        public virtual ScoreHistoryModel ScoreHistory { get; set; }

        public virtual ICollection<TournamentModel>Tournaments { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual GuestUserModel GuestUser { get; set; }

    }
}