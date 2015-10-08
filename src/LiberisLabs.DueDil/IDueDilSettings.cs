using System;

namespace LiberisLabs.DueDil
{
    public interface IDueDilSettings
    {
        Uri BaseUri { get; }
        string ApiKey { get; }
        bool SandboxMode { get; }
    }
}