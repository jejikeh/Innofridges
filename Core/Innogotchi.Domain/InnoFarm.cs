namespace Innogotchi.Domain;

public class InnoFarm
{
    public Guid InnoFarmGuid { get; set; }
    public string FarmName { get; set; } = "Innofarm";
    public ICollection<InnoPet> InnoPets { get; set; }
}