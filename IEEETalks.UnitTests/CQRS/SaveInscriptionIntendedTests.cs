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
        public void SaveInscriptionIntended_Should_Throw_ValidationException()
        {
            // Arrange
            var myInscription = new InscriptionIntended()
            {
                FirstName = "",
                LastName = "",
                Email = "fergoail.com",
                EventId = Guid.NewGuid()

            };

            var command = new SaveInscriptionIntended(myInscription);
            var mockSession = new Mock<ISession>();
        
            mockSession.Setup(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended));
            mockSession.Setup(x => x.GetQueryable<Event>());

            var siiv = new SaveInscriptionIntendedValidator(mockSession.Object);
            var handler = new SaveInscriptionIntendedHandler(mockSession.Object);

            // Act
            var handleResult = handler.Handle(command);
            var validateResult = siiv.Validate(command);

            // Assert
            //Assert.That(() => handler.Handle(command), Throws.TypeOf<ValidationException>());
            mockSession.Verify(x => x.Store(command.InscriptionIntended.Id, command.InscriptionIntended), Times.Once);
            mockSession.Verify(x => x.GetQueryable<Event>(), Times.Once);

            //foreach (var validationFailure in validateResult.Errors)
            //{
                
            //}
            
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
