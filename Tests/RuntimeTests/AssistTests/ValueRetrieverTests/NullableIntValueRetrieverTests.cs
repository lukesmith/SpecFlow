﻿using Moq;
using NUnit.Framework;
using Should;
using TechTalk.SpecFlow.Assist.ValueRetrievers;

namespace TechTalk.SpecFlow.RuntimeTests.AssistTests.ValueRetrieverTests
{
    public class NullableIntValueRetrieverTests
    {
        [Test]
        public void Returns_null_when_the_value_is_null()
        {
            var retriever = new NullableIntValueRetriever(new Mock<IntValueRetriever>().Object);
            retriever.GetValue(null).ShouldBeNull();
        }

        [Test]
        public void Returns_value_from_IntValueRetriever_when_passed_not_empty_string()
        {
            var mock = new Mock<IntValueRetriever>();
            mock.Setup(x => x.GetValue("test value")).Returns(123);
            mock.Setup(x => x.GetValue("another test value")).Returns(456);

            var retriever = new NullableIntValueRetriever(mock.Object);
            retriever.GetValue("test value").ShouldEqual(123);
            retriever.GetValue("another test value").ShouldEqual(456);
        }

        [Test]
        public void Returns_null_when_passed_empty_string()
        {
            var retriever = new NullableIntValueRetriever(new Mock<IntValueRetriever>().Object);
            retriever.GetValue(string.Empty).ShouldBeNull();
        }

    }
}