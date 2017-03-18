using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Riggen.Models
{
    public class ContactRequest
    {

        [Required(ErrorMessage = "Skriv in ditt namn")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Skriv in din e-postadress")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Skriv in en giltig e-postadress")]
        public string Email { get; set; }
                
        [Required(ErrorMessage = "Skriv in ditt meddelande")]
        public string SupportRequest { get; set; }


    }
}