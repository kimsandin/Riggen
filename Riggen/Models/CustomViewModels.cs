using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Riggen.Models
{
    public class CustomViewModels
    {
    }

    public class MemberViewModel
    {
        public IList<ApplicationUser> ApplicationUsers { get; set; }
        public IEnumerable<System.Web.Mvc.SelectListItem> Members { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "E-post")]
        public string Email { get; set; }
    }
    public class ProfileViewModel
    {
        [Display(Name = "Förnamn")]
        public string FirstName { get; set; }
        [Display(Name = "Efternamn")]
        public string LastName { get; set; }
        [Display(Name = "E-post")]
        public string Email { get; set; }
        [Display(Name = "Profilbild")]
        public string ProfilePicture { get; set; }
        [Display(Name = "Telefon")]
        public string Phone { get; set; }
    }

    public class ResultViewModel
    {
        public int ResultId { get; set; }
        [Display(Name = "Datum")]
        public DateTime Date { get; set; }
        [Display(Name = "Senaste resultat")]
        public decimal NewScore { get; set; }
        [Display(Name = "Tidigare resultat")]
        public decimal ResultHistory { get; set; }
        [Display(Name = "Totalresultat")]
        public decimal TotalScore { get; set; }
        public decimal ScoreHistory { get; set; }
        public ICollection<TournamentModel> Tournaments { get; set; }
        public string ApplicationUser { get; set; }
        public string GuestUser { get; set; }
    }


}