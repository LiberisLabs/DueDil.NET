using System;

namespace LiberisLabs.DueDil
{
    public class DueDilSettings
    {
        public DueDilSettings(Uri baseUri, string apiKey, bool sandboxMode)
        {
            BaseUri = baseUri;
            ApiKey = apiKey;
            SandboxMode = sandboxMode;
        }

        public Uri BaseUri { get; }

        public string ApiKey { get; }

        public bool SandboxMode { get; }
    }
}