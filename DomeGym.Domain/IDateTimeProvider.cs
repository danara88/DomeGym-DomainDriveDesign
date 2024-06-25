namespace DomeGym.Domain;

public interface IDateTimeProvider
{
    public DateTime utcNow { get; }
}
