using DomruAPI.Entity.AuthAPI;
using DomruAPI.Other.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomruAPI.Interface
{
    internal interface IMyHomeAuthApi
    {
        public Task<Token> authByPassword();
    }
}
