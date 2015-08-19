using System.Net;
using System.Text;

namespace Liberis.DueDil.Sdk.FunctionalTests.MockApi
{
    public class MockResource
    {
        public ResourceIdentifier Identifier { get; private set; }
        private int _statusCode = 200;
        private string _responseBody;
        private bool _wasHandled;

        public MockResource(ResourceIdentifier identifier)
        {
            Identifier = identifier;
        }

        public MockResource ReturnsStatusCode(int statusCode)
        {
            _statusCode = statusCode;
            return this;
        }

        public MockResource ReturnsBody(string body)
        {
            _responseBody = body;
            return this;
        }

        public void Handle(HttpListenerContext context)
        {
            _wasHandled = true;

            context.Response.AddHeader("Content-Type", "application/json");
            context.Response.StatusCode = _statusCode;

            context.Response.Close(Encoding.UTF8.GetBytes(_responseBody), false);
        }

        public bool Verify()
        {
            return _wasHandled;
        }
    }
}
