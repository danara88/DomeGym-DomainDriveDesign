namespace DomeGym.Domain.UnitTests.TestConstants;

public static partial class Constants
{
    public static class Session
    {
        public static readonly Guid Id = Guid.NewGuid();

        public static readonly int MaxParticipants = 10;

        public static readonly DateOnly Date = new DateOnly(day: 1, month: 1, year: 2024);

        public static readonly TimeOnly StartTime = new TimeOnly(hour: 16, minute: 0, second: 0);

        public static readonly TimeOnly EndTime = new TimeOnly(hour: 17, minute: 0, second: 0);
    }
}
