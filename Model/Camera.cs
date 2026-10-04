using DomruAPI.Entity.CameraAPI;
using DomruAPI.Interface;
using DomruAPI.Other.Http;
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
        public async Task<ListCamera> getCameras()
        {
            using (HttpResponseMessage response = await DomRU.getHttp().HGetAsync($"{Const.DOMAIN_PROD}{Const.RESTV1}forpost/cameras"))
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
                    return JsonSerializer.Deserialize<ListCamera>(json, new JsonSerializerOptions() { IncludeFields = true })!;
                }
                else
                {
                    DomRU.getHttp()._request.Invoke();
                    return new ListCamera();
                }
            }
        }

        public async Task<TranslationUrlResponse> getTranslationUrl(int cameraId)
        {
            using (HttpResponseMessage response = await DomRU.getHttp().HGetAsync($"{Const.DOMAIN_PROD}{Const.RESTV1}forpost/cameras/{cameraId}/video?LightStream=0&Format=H264"))
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
                    return JsonSerializer.Deserialize<TranslationUrlResponse>(json, new JsonSerializerOptions() { IncludeFields = true })!;
                }
                else
                {
                    DomRU.getHttp()._request.Invoke();
                    return new TranslationUrlResponse();
                }
            }
        }

        public async Task<ServerTime> getVideoTime()
        {
            using (HttpResponseMessage response = await DomRU.getHttp().HGetAsync($"{Const.DOMAIN_PROD}{Const.RESTV1}forpost/server-time"))
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
                    return JsonSerializer.Deserialize<ServerTime>(json, new JsonSerializerOptions() { IncludeFields = true })!;
                }
                else
                {
                    DomRU.getHttp()._request.Invoke();
                    return new ServerTime();
                }
            }
        }
    }
}
