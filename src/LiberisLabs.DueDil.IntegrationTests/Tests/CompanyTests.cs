using System;
using NUnit.Framework;

namespace LiberisLabs.DueDil.IntegrationTests.Tests
{
    public abstract class CompanyTests
    {
        protected IDueDilClient Client;

        [TestFixtureSetUp]
        public void GivenADueDilClient()
        {
            var settings = new DueDilSettings(Environment.GetEnvironmentVariable("DueDilApiKey"), true);

            var factory = new DueDilClientFactory(settings);

            Client = factory.CreateClient();
        }
    }
}