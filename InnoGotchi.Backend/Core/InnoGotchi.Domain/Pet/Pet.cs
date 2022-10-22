namespace InnoGotchi.Domain.Pet;

public class Pet
{
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Age => _petAge.Age;
    public PetStatus.Hunger Hunger { get; }
    public PetStatus.Thirsty Thirsty { get; }
    public int HappienessDayCount { get; }

    private PetAge _petAge = new PetAge();
}