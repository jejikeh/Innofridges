namespace Innogotchi.Domain;

public class InnoPet
{
    public Guid InnoPetId { get; set; }
    public string PetName { get; set; } = "Innogotchi";
    public DateTime BornDate { get; set; }
    public float Satiety { get; set; } = 100f;
    public float Thirsty { get; set; } = 100f;
    public int HappyDays { get; set; } = 0;
}