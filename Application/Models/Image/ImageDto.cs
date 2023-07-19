using Application.Models.Property;

namespace Application.Models.Image;

public class ImageDto
{
    public int Id { get; set; }
    public int PropertyId { get; set; }
    public string Name { get; set; }
    public string Path { get; set; }
    public bool IsUploaded { get; set; }

    public PropertyDto Property { get; set; }
}
