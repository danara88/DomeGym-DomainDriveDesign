using System.Reflection.Metadata;
using DomeGym.Domain;
using DomeGym.Domain.UnitTests.TestConstants;
using DomeGym.Domain.UnitTests.TestUtils.Participants;
using DomeGym.Domain.UnitTests.TestUtils.Services;
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
        var reserveParticipant1Result = session.ReserveSpot(participant1);
        var reserveParticipant2Result = session.ReserveSpot(participant2);

        // Assert
        // particiapant 2 reservation failed
        reserveParticipant1Result.IsError.Should().BeFalse();
        reserveParticipant2Result.FirstError.Should().Be(SessionErrors.CannotHaveMoreReservationsThanParticipants);
    }

    [Fact]
    public void CancelReservation_WhenCancellationIsTooCloseToSession_ShouldFailCancellation()
    {
        // Arrange
        // create a session
        var session = SessionFactory.CreateSession(
            maxParticipants: 10,
            date: Constants.Session.Date, // 01 01 2024
            startTime: Constants.Session.StartTime, // 16:00
            endTime: Constants.Session.EndTime); // 17:00
        // create a participant
        var participant = ParticipantFactory.CreateParticipant();

        // 01 01 2024 00:00:00
        DateTime cancellationDateTime = Constants.Session.Date.ToDateTime(TimeOnly.MinValue);

        // Act
        // reserve a spot for the participation in the session
        var reserveSpotResult = session.ReserveSpot(participant);
        // cancel the reservation less than 24 hours before the session
        var cancelReservationResult = session.CancelReservation(
            participant,
            new TestDateTimeProvider(fixedDateTime: cancellationDateTime)
        );

        // Assert
        reserveSpotResult.IsError.Should().BeFalse();
        // the cancellation fails
        cancelReservationResult.FirstError.Should().Be(SessionErrors.CannotCancelReservationTooCloseToSession);
    }
}
