using DomruAPI.Other;
using DomruAPI.Other.Http;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace DomruAPI
{
    public class DomRU
    {
        private static HandlerHttp _handlerhttp = null!;

        private static AuthCredential _authCrendential = null!;

        private GetModels _models;

        public static bool isDebug = false;

        public DomRU(AuthCredential credential)
        {
            _authCrendential = credential;
            _handlerhttp = new HandlerHttp(credential);
            _models = new GetModels();
        }

        public DomRU(AuthCredential credential, HttpClientHandler handler, bool disposeHandler)
        {
            _authCrendential = credential;
            _handlerhttp = new HandlerHttp(credential, handler, disposeHandler);
            _models = new GetModels();
        }

        public async Task<bool> fullauth()
        {
            if (await this.getModels().Auth.authByPassword() != null)
            {
                await Task.Delay(1000);
                if(await this.getModels().User.getPlaces() != null)
                {
                    return true;
                }
            }

            return false;
        }

        public GetModels getModels()
        {
            return _models;
        }

        internal static HandlerHttp getHttp()
        {
            return _handlerhttp;
        }

        internal static AuthCredential getAuthCrendential()
        {
            return _authCrendential;
        }
    }
}
