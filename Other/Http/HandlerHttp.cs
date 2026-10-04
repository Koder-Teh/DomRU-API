using DomruAPI.Entity.AuthAPI;
using DomruAPI.Interface;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;

namespace DomruAPI.Other.Http
{
    public class HandlerHttp : HttpClient
    {
        internal delegate void _endWebRequest();

        internal _endWebRequest _request;

        private bool _firstRequest;

        private UserAgent _userAgent;

        public HandlerHttp(AuthCredential credential)
        {
            _request = this.endWebRequest;
            _firstRequest = true;
            _userAgent = new UserAgent();

            this.DefaultRequestHeaders.Add("User-Agent", _userAgent!.GenerateUserAgent(credential.Login, "null", "null"));
        }

        public HandlerHttp(AuthCredential credential, HttpClientHandler handler, bool disposeHandler) : base(handler, disposeHandler)
        {
            _request = this.endWebRequest;
            _firstRequest = true;
            _userAgent = new UserAgent();

            this.DefaultRequestHeaders.Add("User-Agent", _userAgent!.GenerateUserAgent(credential.Login, "null", "null"));
        }

        public async Task<HttpResponseMessage> HPostAsync(string? requestUri, HttpContent? content)
        {
            return await PostAsync(requestUri, content);
        }

        public async Task<HttpResponseMessage> HGetAsync(string? requestUri)
        {
            return await GetAsync(requestUri);
        }

        private void endWebRequest()
        {
            if(_firstRequest)
            {
                if (DomRU.getAuthCrendential().Token != null && !this.DefaultRequestHeaders.Contains("Authorization") && !this.DefaultRequestHeaders.Contains("Operator"))
                {
                    this.DefaultRequestHeaders.Add("Authorization", $"{DomRU.getAuthCrendential().Token.TokenType} {DomRU.getAuthCrendential().Token.AccessToken}");
                    this.DefaultRequestHeaders.Add("Operator", $"{DomRU.getAuthCrendential().Token.OperatorId}");
                }
                if (DomRU.getAuthCrendential().Places != null)
                {
                    this.DefaultRequestHeaders.Remove("User-Agent");
                    this.DefaultRequestHeaders.Add("User-Agent", _userAgent!.GenerateUserAgent(DomRU.getAuthCrendential().Login, DomRU.getAuthCrendential().Token.OperatorId.ToString(), DomRU.getAuthCrendential().Places.Data[0].Id.ToString()));
                    _firstRequest= false;
                }
            }
        }
    }
}
