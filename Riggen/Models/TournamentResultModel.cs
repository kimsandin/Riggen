using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Riggen.Models
{
    public class TournamentResultModel
    {
        [Key]
        [Required]
        public int TournamentResultId { get; set; }

        public decimal UserScore { get; set; }

        public decimal UserLadder { get; set; }

        public decimal CurrentScore { get; set; }

        public decimal TotalScore { get; set; }

        public int TournamentPlacement { get; set; }


        public virtual ScoreHistoryModel ScoreHistory { get; set; }

        public virtual ICollection<TournamentModel> Tournaments { get; set; }

        public virtual ICollection<ResultModel> Results { get; set; }

        public virtual ICollection<GuestUserModel> GuestUsers { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}