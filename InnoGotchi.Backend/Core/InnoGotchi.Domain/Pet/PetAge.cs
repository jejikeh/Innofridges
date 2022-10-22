namespace InnoGotchi.Domain.Pet;

public class PetAge
{
    private readonly  DateTime _bornDate = DateTime.Now;
    public string Age { get => CalculateAge(); }

    private string CalculateAge()
    {
        var daysFromBorn = DateTime.Now.Subtract(_bornDate);
        return daysFromBorn > TimeSpan.FromDays(7) ? (daysFromBorn.Days / 7).ToString() : "NEWBORN";
    }
}