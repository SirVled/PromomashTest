using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PromomashTest.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }
        [Required, EmailAddress]
        public string Email { get; set; }
        [Required]
        public string PasswordHash { get; set; }
        [Required]
        public int CountryId { get; set; }
        public Country Country { get; set; }
        [Required]
        public int ProvinceId { get; set; }
        public Province Province { get; set; }
    }
}
