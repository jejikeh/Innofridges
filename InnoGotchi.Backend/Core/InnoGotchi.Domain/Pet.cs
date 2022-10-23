namespace InnoGotchi.Domain;

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
    
    /// <summary>
    /// Pet hunger level
    /// </summary>
    public PetLevel.Hunger Hunger { get; }
    
    /// <summary>
    /// Pet thirsty level
    /// </summary>
    public PetLevel.Thirsty Thirsty { get; }
    
    /// <summary>
    /// Days when pet was 
    /// </summary>
    public int HappienessDayCount { get; }
    
    private string CalculateAge()
    {
        var daysFromBorn = DateTime.Now.Subtract(BornDate);
        return daysFromBorn > TimeSpan.FromDays(7) ? (daysFromBorn.Days / 7).ToString() : "NEWBORN";
    }
}

/// <summary>
/// Stages of hunger and thirsty
/// </summary>
public static class PetLevel
{
    public enum Hunger
    {
        Full,
        Normal,
        Hunger,
        Dead
    }

    public enum Thirsty
    {
        Full,
        Normal,
        Thirsty,
        Dead
    }
}