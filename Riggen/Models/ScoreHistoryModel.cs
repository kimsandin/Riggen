using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Riggen.Models
{
    public class ScoreHistoryModel
    {
        [Key]
        [Required]
        public int ScoreHistoryId { get; set; }

        public DateTime Year { get; set; }

        public decimal ScoreOfYear { get; set; }


        public virtual ICollection<TournamentResultModel> TournamentResults { get; set; }

        public virtual ICollection<ResultModel> Results { get; set; }
    }
}