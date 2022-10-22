namespace InnoGotchi.Domain.Pet;

public class Pet
{
    /// <summary>
    /// Id of the user who owns this pet
    /// </summary>
    public Guid UserId { get; set; }
    public Guid Id { get; set; }
    
    /// <summary>
    /// Pet name
    /// </summary>
    public string Name { get; set; }
    
    /// <summary>
    /// Creation time
    /// </summary>
    public DateTime BornDate { get; set; }
    
    /// <summary>
    /// Pet age
    /// </summary>
    public string Age => CalculateAge(); 
    public PetStatus.Hunger Hunger { get; }
    public PetStatus.Thirsty Thirsty { get; }
    public int HappienessDayCount { get; }
    
    private string CalculateAge()
    {
        var daysFromBorn = DateTime.Now.Subtract(BornDate);
        return daysFromBorn > TimeSpan.FromDays(7) ? (daysFromBorn.Days / 7).ToString() : "NEWBORN";
    }
}