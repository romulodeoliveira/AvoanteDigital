namespace AvoanteDigital.Api.Models.Campaign;

public class CreateEbookModel
{
    public string Name { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; } = true;
    public byte[] PDF { get; set; }
}