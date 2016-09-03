using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEEETalks.CQRS.Commands;
using IEEETalks.Persistance;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace IEEETalks.UnitTests.CQRS
{
    class InscriptionIntendedValidatorTests
    {
        private InscriptionIntendedValidator inscriptionIntendedValidator;

        [Test]
        public void ConfigureValidation_Should_Throw_ValidationException_When_FirstName_Is_Empty()
        {
            var mockSession = new Mock<ISession>();
            //mockSession.Setup(x => x.)

            inscriptionIntendedValidator = new InscriptionIntendedValidator(mockSession.Object);
            //inscriptionIntendedValidator.Validate();
        }
    }
}
