using System.ComponentModel.DataAnnotations;

namespace vcoresrobotics.website.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}