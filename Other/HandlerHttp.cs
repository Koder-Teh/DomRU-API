using DomruAPI.Interface;
using DomruAPI.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace DomruAPI.Other
{
    public class HandlerHttp : HttpClient
    {
        public Token? _token;

        public delegate void _endWebRequest();

        public _endWebRequest _request;

        private bool _firstRequest;

        public HandlerHttp()
        {
            initHeader();

            _token = null;
            _request = this.endWebRequest;
            _firstRequest = true;
        }

        public HandlerHttp(HttpClientHandler handler, bool disposeHandler) : base(handler, disposeHandler)
        {
            initHeader();

            _token = null;
            _request = this.endWebRequest;
            _firstRequest = true;
        }

        public async Task<HttpResponseMessage> HPostAsync(string? requestUri, HttpContent? content)
        {
            return await PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> HGetAsync(string? requestUri)
        {
            return await GetAsync(requestUri);
        }

        private void initHeader()
        {
            this.DefaultRequestHeaders.Add("User-Agent", "NovotelecomMyHome/1.0.0 (Android 13; Build/TP1A.220624.014)");
            this.DefaultRequestHeaders.Add("X-Platform", "Android");
        }

        private void endWebRequest()
        {
            if (_firstRequest && _token != null)
            {
                this.DefaultRequestHeaders.Add("Authorization", $"{_token.TokenType} {_token.AccessToken}");
                this.DefaultRequestHeaders.Add("Operator", $"{_token.OperatorId}");
                _firstRequest = false;
            }
        }
    }
}
