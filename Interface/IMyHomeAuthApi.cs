using DomruAPI.Model;
using DomruAPI.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomruAPI.Interface
{
    internal interface IMyHomeAuthApi
    {
        public Task<Token> authByPassword(HandlerHttp http, string login, string password);
    }
}
