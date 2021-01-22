using DevTraining.Core.Models;
using FluentAssertions;
using System;
using Xunit;

namespace DevTraining.UnitTests
{
    public class Tests
    {
        [Fact]
        public void InActivateMethod()
        {
            var contact = new Contact();

            contact.IsActive.Should().Be(true);
            contact.InActivatedDate.Should().BeNull();

            contact.InActivate();

            contact.IsActive.Should().Be(false);
            contact.InActivatedDate.Should().NotBeNull();
        }
    }
}
