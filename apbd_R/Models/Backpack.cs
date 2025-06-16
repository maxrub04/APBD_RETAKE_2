using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_R.Models;

[Table("Backpack")]
[PrimaryKey(nameof(CharacterId), nameof(ItemId))] 
public class Backpack
{
    [ForeignKey(nameof(Character))] 
    public int CharacterId { get; set; }
    [ForeignKey(nameof(Item))]      
    public int ItemId      { get; set; }

    [Range(1, int.MaxValue)]
    public int Amount { get; set; }

    public Character Character { get; set; } = null!;
    public Item      Item      { get; set; } = null!;
}