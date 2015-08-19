using System;
using Liberis.DueDil.Sdk.Requests.SearchCompanies;
using Liberis.DueDil.Sdk.UriBuilders;
using NUnit.Framework;
using Moq;

namespace Liberis.DueDil.Sdk.Tests.UriBuilders
{
    [TestFixture]
    public class SandboxSearchCompaniesUriBuilderDecoratorTests
    {
        private Uri _actualUri;

        [SetUp]
        public void GivenSandboxSearchCompaniesUriBuilderDecorator_WhenBuildingAUri()
        {
            var uri = new Uri("wibble://liberis.co.uk/v20/cust?query=2&bla=true");

            var searchCompaniesUriBuilder = new Mock<ISearchCompaniesUriBuilder>();
            searchCompaniesUriBuilder.Setup(x => x.BuildUri(It.IsAny<Terms>())).Returns(uri);
            
            var sandboxSearchCompaniesUriBuilderDecorator = new SandboxSearchCompaniesUriBuilderDecorator(searchCompaniesUriBuilder.Object);

            _actualUri = sandboxSearchCompaniesUriBuilderDecorator.BuildUri(new Terms());
        }

        [Test]
        public void ThenThePathIsSuffixedWithSandbox()
        {
            Assert.That(_actualUri.AbsoluteUri, Is.EqualTo("wibble://liberis.co.uk/sandbox/v20/cust?query=2&bla=true"));   
        }

    }
}
