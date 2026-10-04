using DomruAPI.Entity.UserAccountAPI;
using DomruAPI.Other.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomruAPI.Interface
{
    internal interface IUserAccountInfoApi
    {
        public Task<SubscriberPlacesResponse> getPlaces();

        public Task<SubscriberPlacesResponse> getUsers(long placeid);
    }
}
