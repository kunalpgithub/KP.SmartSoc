using System.ComponentModel.DataAnnotations;

namespace KP.SmartSoc.Users.Dto
{
    public class ChangeUserLanguageDto
    {
        [Required]
        public string LanguageName { get; set; }
    }
}