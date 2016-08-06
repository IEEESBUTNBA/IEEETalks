using System;
using IEEETalks.Common;
using IEEETalks.Core.Entities;
using IEEETalks.CQRS.Queries;
using IEEETalks.Persistance;
using Moq;
using NUnit.Framework;
using Shouldly;

namespace IEEETalks.UnitTests.CQRS
{
    [TestFixture]
    public class GetEventHandlerTests
    {
        [Test]
        public void GetEvent_ShouldReturn_A_Valid_Event()
        {
            // Arrange
            var myEvent = new Event() {Id = Guid.NewGuid(), Name = "My Test"};

            var mockSession = new Mock<ISession>();
            mockSession.Setup(x => x.GetById<Event>(myEvent.Id)).Returns(myEvent);

            var mockGuard = new Mock<IGuard>();
            mockGuard.Setup(x => x.ForNull(myEvent, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));

            var command = new GetEvent(myEvent.Id);
            var handler = new GetEventHandler(mockSession.Object, mockGuard.Object);

            // Act
            var result = handler.Handle(command);

            // Assert
            mockSession.Verify(x => x.GetById<Event>(myEvent.Id), Times.Once);
            mockGuard.Verify(x => x.ForNull(myEvent, It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            result.ShouldNotBeNull();
            result.Id.ShouldBe(myEvent.Id);
        }
    }
}
