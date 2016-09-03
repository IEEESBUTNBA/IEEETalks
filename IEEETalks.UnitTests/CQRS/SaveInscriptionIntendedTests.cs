using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEEETalks.Core.Entities;
using IEEETalks.CQRS.Commands;
using IEEETalks.Persistance;
using Moq;
using NUnit.Framework;
using Shouldly;
using System.ComponentModel.DataAnnotations;
using IEEETalks.Common;
using IEEETalks.Core.Enums;

namespace IEEETalks.UnitTests.CQRS
{
    [TestFixture]
    class SaveInscriptionIntendedTests
    {
        [Test]
        public void SaveInscriptionIntended_Should_Success()
        {
            // Arrange
            var myInscription = new InscriptionIntended()
            {
                FirstName = "Fernando",
                LastName = "Gonzales",
                Email = "fergon@hotmail.com",
                EventId = Guid.NewGuid()

            };

            var command = new SaveInscriptionIntended(myInscription);
            var mockSession = new Mock<ISession>();
            mockSession.Setup(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended));

            var handler = new SaveInscriptionIntendedHandler(mockSession.Object);

            // Act
            var result = handler.Handle(command);

            // Assert
            mockSession.Verify(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended), Times.Once);
            result.ShouldNotBeNull();
        }

        [Test]
        public void SaveInscriptionIntended_Should_Throw_ValidationException_When_FirstName_Is_Empty()
        {
            // Arrange
            var activeRange = DateTimeRange.CreateOneWeekRange(DateTime.Today.AddDays(-5));

            var myEvent = new Event
            {
                Id = new Guid("20133f6d-5356-4ed2-b0fa-75dc73646499"),
                ActiveSinceDate = activeRange.Start,
                ActiveUntilDate = activeRange.End,
                EventState = EventState.Active
            };

            var mySecondEvent = new Event() { Id = Guid.NewGuid() };

            var myEvents = new List<Event>()
            {
                myEvent,
                mySecondEvent
            }.AsQueryable();

            var myInscription = new InscriptionIntended()
            {
                FirstName = "",
                LastName = "Rodriguez",
                Email = "fergoail@hotmail.com",
                EventId = Guid.Parse("20133f6d-5356-4ed2-b0fa-75dc73646499")

            };

            var command = new SaveInscriptionIntended(myInscription);
            var mockSession = new Mock<ISession>();

            mockSession.Setup(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended));
            mockSession.Setup(x => x.GetQueryable<Event>()).Returns(myEvents);

            var siiv = new SaveInscriptionIntendedValidator(mockSession.Object);
            var handler = new SaveInscriptionIntendedHandler(mockSession.Object);

            // Act
            var handleResult = handler.Handle(command);
            var validateResult = siiv.Validate(command);

            // Assert
            mockSession.Verify(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended), Times.Once);
            mockSession.Verify(x => x.GetQueryable<Event>(), Times.Once);

            validateResult.IsValid.ShouldBe(false);
            validateResult.Errors.Count.ShouldBe(1);
            validateResult.Errors[0].PropertyName.ShouldBe("FirstName");

            // Testear ambos Validator 
        }

        [Test]
        public void SaveInscriptionIntended_Should_Throw_ValidationException_When_LastName_IsEmpty()
        {
            // Arrange
            var activeRange = DateTimeRange.CreateOneWeekRange(DateTime.Today.AddDays(-5));

            var myEvent = new Event
            {
                Id = new Guid("20133f6d-5356-4ed2-b0fa-75dc73646499"),
                ActiveSinceDate = activeRange.Start,
                ActiveUntilDate = activeRange.End,
                EventState = EventState.Active
            };

            var mySecondEvent = new Event() { Id = Guid.NewGuid() };

            var myEvents = new List<Event>()
            {
                myEvent,
                mySecondEvent
            }.AsQueryable();

            var myInscription = new InscriptionIntended()
            {
                FirstName = "Hernan",
                LastName = "",
                Email = "fergoail@hotmail.com",
                EventId = Guid.Parse("20133f6d-5356-4ed2-b0fa-75dc73646499")

            };

            var command = new SaveInscriptionIntended(myInscription);
            var mockSession = new Mock<ISession>();

            mockSession.Setup(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended));
            mockSession.Setup(x => x.GetQueryable<Event>()).Returns(myEvents);

            var siiv = new SaveInscriptionIntendedValidator(mockSession.Object);
            var handler = new SaveInscriptionIntendedHandler(mockSession.Object);

            // Act
            var handleResult = handler.Handle(command);
            var validateResult = siiv.Validate(command);

            // Assert
            mockSession.Verify(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended), Times.Once);
            mockSession.Verify(x => x.GetQueryable<Event>(), Times.Once);

            validateResult.IsValid.ShouldBe(false);
            validateResult.Errors.Count.ShouldBe(1);
            validateResult.Errors[0].PropertyName.ShouldBe("LastName");
        }

        [Test]
        public void SaveInscriptionIntended_Should_Throw_ValidationException_When_Email_IsEmpty()
        {
            // Arrange
            var activeRange = DateTimeRange.CreateOneWeekRange(DateTime.Today.AddDays(-5));

            var myEvent = new Event
            {
                Id = new Guid("20133f6d-5356-4ed2-b0fa-75dc73646499"),
                ActiveSinceDate = activeRange.Start,
                ActiveUntilDate = activeRange.End,
                EventState = EventState.Active
            };

            var mySecondEvent = new Event() { Id = Guid.NewGuid() };

            var myEvents = new List<Event>()
            {
                myEvent,
                mySecondEvent
            }.AsQueryable();

            var myInscription = new InscriptionIntended()
            {
                FirstName = "Hernan",
                LastName = "Perez",
                Email = "",
                EventId = Guid.Parse("20133f6d-5356-4ed2-b0fa-75dc73646499")

            };

            var command = new SaveInscriptionIntended(myInscription);
            var mockSession = new Mock<ISession>();

            mockSession.Setup(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended));
            mockSession.Setup(x => x.GetQueryable<Event>()).Returns(myEvents);

            var siiv = new SaveInscriptionIntendedValidator(mockSession.Object);
            var handler = new SaveInscriptionIntendedHandler(mockSession.Object);

            // Act
            var handleResult = handler.Handle(command);
            var validateResult = siiv.Validate(command);

            // Assert
            mockSession.Verify(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended), Times.Once);
            mockSession.Verify(x => x.GetQueryable<Event>(), Times.Once);

            validateResult.IsValid.ShouldBe(false);
            validateResult.Errors.Count.ShouldBe(2);
            validateResult.Errors[0].PropertyName.ShouldBe("InscriptionIntended.Email");
        }

        [Test]
        public void SaveInscriptionIntended_Should_Throw_ValidationException_When_Email_IsInvalid()
        {
            // Arrange
            var activeRange = DateTimeRange.CreateOneWeekRange(DateTime.Today.AddDays(-5));

            var myEvent = new Event
            {
                Id = new Guid("20133f6d-5356-4ed2-b0fa-75dc73646499"),
                ActiveSinceDate = activeRange.Start,
                ActiveUntilDate = activeRange.End,
                EventState = EventState.Active
            };

            var mySecondEvent = new Event() { Id = Guid.NewGuid() };

            var myEvents = new List<Event>()
            {
                myEvent,
                mySecondEvent
            }.AsQueryable();

            var myInscription = new InscriptionIntended()
            {
                FirstName = "Hernan",
                LastName = "Gonzales",
                Email = "fergoailtmail.com",
                EventId = Guid.Parse("20133f6d-5356-4ed2-b0fa-75dc73646499")

            };

            var command = new SaveInscriptionIntended(myInscription);
            var mockSession = new Mock<ISession>();

            mockSession.Setup(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended));
            mockSession.Setup(x => x.GetQueryable<Event>()).Returns(myEvents);

            var siiv = new SaveInscriptionIntendedValidator(mockSession.Object);
            var handler = new SaveInscriptionIntendedHandler(mockSession.Object);

            // Act
            var handleResult = handler.Handle(command);
            var validateResult = siiv.Validate(command);

            // Assert
            mockSession.Verify(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended), Times.Once);
            mockSession.Verify(x => x.GetQueryable<Event>(), Times.Once);

            validateResult.IsValid.ShouldBe(false);
            validateResult.Errors.Count.ShouldBe(1);
            validateResult.Errors[0].PropertyName.ShouldBe("InscriptionIntended.Email");
            validateResult.Errors[0].ErrorMessage.ShouldBe("'Email' no es una dirección de correo electrónico válida.");
        }
    }
}

//public class InscriptionIntended
//{
//    public InscriptionIntended()
//    {
//        this.Id = Guid.NewGuid();
//    }

//    public Guid Id { get; set; }
//    public string FirstName { get; set; }
//    public string LastName { get; set; }
//    public string Email { get; set; }
//    public Guid EventId { get; set; }
//}
