namespace InnoGotchi.Domain.Pet;

public static class PetStatus
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