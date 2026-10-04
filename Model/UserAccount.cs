using DomruAPI.Entity.CameraAPI;
using DomruAPI.Entity.UserAccountAPI;
using DomruAPI.Interface;
using DomruAPI.Other.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace DomruAPI.Model
{
    public class UserAccount : IUserAccountInfoApi
    {
        public async Task<SubscriberPlacesResponse> getPlaces()
        {
            using (HttpResponseMessage response = await DomRU.getHttp().HGetAsync($"{Const.DOMAIN_PROD}{Const.RESTV3}subscriber-places"))
            {
                if (DomRU.isDebug)
                {
                    Console.WriteLine(response.StatusCode);
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    DomRU.getHttp()._request.Invoke();
                    DomRU.getAuthCrendential().Places = JsonSerializer.Deserialize<SubscriberPlacesResponse>(json, new JsonSerializerOptions() { IncludeFields = true })!;
                    return DomRU.getAuthCrendential().Places!;
                }
                else
                {
                    DomRU.getHttp()._request.Invoke();
                    return new SubscriberPlacesResponse();
                }
            }
        }

        public async Task<SubscriberPlacesResponse> getUsers(long placeId)
        {
            using (HttpResponseMessage response = await DomRU.getHttp().HGetAsync($"{Const.DOMAIN_PROD}{Const.RESTV1}subscriberplaces?placeId={placeId}"))
            {
                if (DomRU.isDebug)
                {
                    Console.WriteLine(response.StatusCode);
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    DomRU.getHttp()._request.Invoke();
                    DomRU.getAuthCrendential().Places = JsonSerializer.Deserialize<SubscriberPlacesResponse>(json, new JsonSerializerOptions() { IncludeFields = true })!;
                    return DomRU.getAuthCrendential().Places!;
                }
                else
                {
                    DomRU.getHttp()._request.Invoke();
                    return new SubscriberPlacesResponse();
                }
            }
        }
    }
}
