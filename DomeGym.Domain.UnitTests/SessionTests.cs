using DomeGym.Domain.UnitTests.TestUtils.Participants;
using DomeGym.Domain.UnitTests.TestUtils.Sessions;
using FluentAssertions;
using Xunit;

namespace DomeGyme.Domain.UnitTests;

public class SessionTests
{
    [Fact]
    public void ReserveSpot_WhenNoMoreRoom_ShouldFailReservation()
    {
        // Arrange
        // create a session
        var session = SessionFactory.CreateSession(maxParticipants: 1);
        // create 2 participants
        var participant1 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid(), userId: Guid.NewGuid());
        var participant2 = ParticipantFactory.CreateParticipant(id: Guid.NewGuid(), userId: Guid.NewGuid());

        // Act
        // add participant 1 and participant 2
        session.ReserveSpot(participant1);
        Action action = () => session.ReserveSpot(participant2);

        // Assert
        // particiapant 2 reservation failed
        action.Should().ThrowExactly<Exception>();
    }
}
