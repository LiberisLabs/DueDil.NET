using System;

namespace LiberisLabs.DueDil
{
    public class DueDilSettings : IDueDilSettings
    {
        public DueDilSettings(Uri baseUri, string apiKey, bool sandboxMode)
        {
            BaseUri = baseUri;
            ApiKey = apiKey;
            SandboxMode = sandboxMode;
        }

        public DueDilSettings(string apiKey)
            : this(apiKey, false)
        {
            
        }

        public DueDilSettings(string apiKey, bool sandboxMode)
            : this(DueDilBaseUris.ProApi, apiKey, sandboxMode)
        {

        }

        public Uri BaseUri { get; }

        public string ApiKey { get; }

        public bool SandboxMode { get; }
    }
}