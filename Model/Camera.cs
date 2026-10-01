using DomruAPI.Interface;
using DomruAPI.Other;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace DomruAPI.Model
{
    public class Camera : ICamerasApi
    {
        public async Task<ListCamera> getCameras(HandlerHttp http)
        {
            using (HttpResponseMessage response = await http.HGetAsync($"https://myhome.proptech.ru/rest/v1/forpost/cameras"))
            {
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    http._request.Invoke();
                    return JsonSerializer.Deserialize<ListCamera>(json, new JsonSerializerOptions() { IncludeFields = true })!;
                }
                else
                {
                    http._request.Invoke();
                    return new ListCamera();
                }
            }
        }
    }
}
