namespace InnoGotchi.Persistence;
public class DbInitializer
{
    public static void Initialize(PetsDbContext context)
    {
        context.Database.EnsureCreated();
    }
}