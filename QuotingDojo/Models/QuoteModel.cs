using System;
using System.ComponentModel.DataAnnotations;

namespace QuotingDojo
{
    public class Quote
    {
        [Required]
        [MinLength(5)]
        [MaxLength(255)]
        public string Message{get; set;}

        [Required]
        [MinLength(2)]
        [MaxLength(24)]
        public string User{get; set;}

    }
}