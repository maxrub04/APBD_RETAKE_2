using System.ComponentModel.DataAnnotations;

namespace apbd_R.DTOs;

public class AddItemsRequestDto
{
    [Required(ErrorMessage = "ItemIds array is required")]
    [MinLength(1, ErrorMessage = "At least one item id must be ")]
    public List<int> ItemIds { get; set; } = new();
}