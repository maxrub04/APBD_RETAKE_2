using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_R.Models;

[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
[Table("Character_Title")]
public class CharacterTitle
{
    [ForeignKey(nameof(Character))] 
    public int CharacterId { get; set; }
    [ForeignKey(nameof(Title))]     
    public int TitleId     { get; set; }

    public DateTime AcquiredAt { get; set; }

    public Character Character { get; set; } = null!;
    public Title     Title     { get; set; } = null!;
}