using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_R.Models;


[Table("Item")]
public class Item
{
    [Key] public int ItemId { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = null!;

    [Range(1, int.MaxValue)]
    public int Weight { get; set; }
    
    public ICollection<Backpack> Backpacks { get; set; } = new List<Backpack>();
}