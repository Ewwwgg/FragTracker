using System.ComponentModel.DataAnnotations;

namespace FragTracker.Models
{
    // [CYBER-ESPORTS-THEME] Entity definition for our digital gladiators
    public class ProPlayer
    {
        [Key]
        public int Id { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Nickname { get; set; } = string.Empty;
        
        public string Team { get; set; } = string.Empty;
        
        // CS2 or Dota2 strictly!
        public string Game { get; set; } = string.Empty;
        
        // ELO Rating
        public int Rating { get; set; }
    }
}
