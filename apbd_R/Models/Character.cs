using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_R.Models;

[Table("Character")]
public class Character
{
    
    [Key] 
    public int CharacterId { get; set; }

    [Required, MaxLength(50)]  
    public string FirstName  { get; set; } = null!;
    [Required, MaxLength(120)] 
    public string LastName   { get; set; } = null!;

    [Range(0, int.MaxValue)] 
    public int CurrentWeight { get; set; }
    [Range(1, int.MaxValue)] 
    public int MaxWeight     { get; set; }
    
    public ICollection<Backpack>       Backpacks       { get; set; } = new List<Backpack>();
    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new List<CharacterTitle>();
    
}