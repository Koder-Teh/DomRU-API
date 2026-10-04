using DomruAPI.Entity.AuthAPI;
using DomruAPI.Entity.UserAccountAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomruAPI.Other.Http
{
    public class AuthCredential
    {
        public required string Login { get; set; }

        public required string Password { get; set; }

        public Token? Token { get; set; }

        public SubscriberPlacesResponse? Places { get; set; }
    }
}
