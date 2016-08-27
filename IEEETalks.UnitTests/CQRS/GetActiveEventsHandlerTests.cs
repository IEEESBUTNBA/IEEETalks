using System;
using System.Collections.Generic;
using System.Linq;
using IEEETalks.Persistance;
using Moq;
using NUnit.Framework;
using IEEETalks.Core.Entities;
using IEEETalks.CQRS.Queries;
using Shouldly;

namespace IEEETalks.UnitTests.CQRS
{
    [TestFixture]
    class GetActiveEventsHandlerTests
    {
        [Test]
        public void GetActiveEvents_Should_Return_2_Events()
        { 
            // Arrange
            var skip = 2;
            var limit = 2;

            var myActiveEvents = new List<Event>()
            {
                new Event() {Id = Guid.NewGuid()},
                new Event() {Id = Guid.NewGuid()},
            };

            var command = new GetActiveEvents(skip, limit);

            var mockSession = new Mock<ISession>();

            mockSession.Setup(x => x.GetQueryable<Event>()).Returns(myActiveEvents.AsQueryable());
            
            var handler = new GetActiveEventsHandler(mockSession.Object);
          
            // Act
            var result = handler.Handle(command);

            // Assert
            mockSession.Verify(x => x.GetQueryable<Event>(), Times.Exactly(2));
            result.Items.ShouldNotBeNull();
            
            var testPass = false;
            
            foreach (var @event in result.Items)
            {
                foreach (var @activeEvent in myActiveEvents)
                {
                    if (@event.Id == @activeEvent.Id)
                    {
                            testPass = true;
                    }
                }

                if (testPass==false)
                {
                    Assert.Fail();
                }

                testPass = false;
            }
        }
    }
}
