﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;

namespace LiberisLabs.DueDil.FunctionalTests.MockApi
{
    public class Api : IDisposable
    {
        private readonly HttpListener _listener;
        private readonly Dictionary<ResourceIdentifier, MockResource> _resources = new Dictionary<ResourceIdentifier, MockResource>();

        public Uri Uri
        {
            get { return new Uri(_listener.Prefixes.First()); }
        }

        public Api()
        {
            _listener = CreateListener();
        }

        public void Start()
        {
            _listener.BeginGetContext(Handle, null);
        }

        public void RegisterResource(MockResource resource)
        {
            _resources[resource.Identifier] = resource;
        }

        public void Handle(IAsyncResult result)
        {
            try
            {
                if (!_listener.IsListening)
                    return;

                var httpListenerContext = _listener.EndGetContext(result);

                var identifier = new ResourceIdentifier(httpListenerContext.Request.HttpMethod,
                    httpListenerContext.Request.Url.AbsolutePath, Uri.UnescapeDataString(httpListenerContext.Request.Url.Query));

                if (_resources.ContainsKey(identifier))
                {
                    _resources[identifier].Handle(httpListenerContext);
                }
                else
                {
                    Debug.WriteLine("Could not handle request: {0} {1}", httpListenerContext.Request.HttpMethod, httpListenerContext.Request.Url);
                    httpListenerContext.Response.StatusCode = 500;

                    httpListenerContext.Response.Close(Encoding.UTF8.GetBytes("unknown mocked resource"), false);
                }
            }
            catch { }
            finally
            {
                try
                {
                    _listener.BeginGetContext(Handle, null);
                }
                catch
                { }
            }
        }

        public void Stop()
        {
            Dispose();
        }

        public void Dispose()
        {
            try
            {
                _listener.Stop();
            }
            catch (ObjectDisposedException)
            { }
        }

        static readonly Random Generator = new Random();

        private static HttpListener CreateListener()
        {
            var attempts = 0;
            HttpListener listener = null;

            while (attempts < 10)
            {
                listener = new HttpListener();
                var port = Generator.Next(IPEndPoint.MinPort, IPEndPoint.MaxPort);

                listener.Prefixes.Add(string.Format("http://localhost:{0}/", port));

                try
                {
                    listener.Start();
                }
                catch
                {
                    attempts++;
                    continue;
                }

                break;
            }

            return listener;
        }
    }
}
