using System.ComponentModel.DataAnnotations;

namespace apbd_R.DTOs;

public class CharacterResponseDto
{
    [Required, MaxLength(50)]
    public string FirstName     { get; set; } = null!;
    [Required, MaxLength(120)]
    public string LastName      { get; set; } = null!;
    public int    CurrentWeight { get; set; }
    public int    MaxWeight     { get; set; }

    public List<BackpackItemDto> BackpackItems { get; set; } = new();
    public List<TitleDto>        Titles        { get; set; } = new();
}