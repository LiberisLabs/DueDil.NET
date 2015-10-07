using System;

namespace LiberisLabs.DueDil
{
    public class DueDilSettings
    {
        private readonly string _apiKey;
        private readonly Uri _baseUri;
        private readonly bool _sandboxMode;

        public DueDilSettings(Uri baseUri, string apiKey, bool sandboxMode)
        {
            _baseUri = baseUri;
            _apiKey = apiKey;
            _sandboxMode = sandboxMode;
        }

        public Uri BaseUri
        {
            get { return _baseUri; }
        }

        public string ApiKey
        {
            get { return _apiKey; }
        }

        public bool SandboxMode
        {
            get { return _sandboxMode; }
        }
    }
}