using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IEEETalks.Core.Entities;
using IEEETalks.Persistance;
using Moq;
using NUnit.Framework.Internal;
using NUnit.Framework;

namespace IEEETalks.UnitTests.CQRS
{
    [TestFixture]
    public class InMemorySessionTests
    {
        private InMemorySession _myInMemorySession;
        private Event _myEvent;

        [Test]
        public void Test_Store_And_GetById()
        {
            // Arrange
            _myEvent = new Event() { Id = Guid.NewGuid() };
            _myInMemorySession = new InMemorySession();

            // Act
            _myInMemorySession.Store(_myEvent.Id, _myEvent);
            var result = _myInMemorySession.GetById<Event>(_myEvent.Id);

            // Assert
            Assert.AreEqual(_myEvent.Id, result.Id);
        }

        [Test]
        public void Test_Remove()
        {
            // Arrange
            _myEvent = new Event() { Id = Guid.NewGuid() };
            _myInMemorySession = new InMemorySession();
            _myInMemorySession.Store(_myEvent.Id, _myEvent);

            // Act
            _myInMemorySession.Remove<Event>(_myEvent.Id.ToString()); /* Problema con Remove */

            // Assert
            var result = _myInMemorySession.GetById<Event>(_myEvent.Id);
            Assert.IsNull(result);
        }

        [Test]
        public void Test_GetQueryable()
        {
            // Arrange
            _myEvent = new Event() { Id = Guid.NewGuid() };
            var mySecondEvent = new Event() { Id = Guid.NewGuid() };
            _myInMemorySession = new InMemorySession();

            var myEvents = new List<Event>()
            {
                _myEvent,
                mySecondEvent
            }.AsQueryable();

            _myInMemorySession.Store(_myEvent.Id, _myEvent);
            _myInMemorySession.Store(mySecondEvent.Id, mySecondEvent);

            // Act
            var result = _myInMemorySession.GetQueryable<Event>();

            // Assert
            Assert.AreEqual(myEvents, result);
        }
    }
}
