using System.ComponentModel.DataAnnotations;

namespace AqualLifeStyle.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}