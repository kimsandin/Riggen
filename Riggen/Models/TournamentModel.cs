using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Riggen.Models
{
    public class TournamentModel
    {
        [Key]
        [Required]
        public int TournamentId { get; set; }

        public DateTime TournamentDate { get; set; }

        public string TournamentName { get; set; }

        public string TournamentType { get; set; }
        
    }
}