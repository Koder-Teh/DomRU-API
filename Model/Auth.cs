using DomruAPI.Entity.AuthAPI;
using DomruAPI.Interface;
using DomruAPI.Other.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DomruAPI.Model
{
    public class Auth : IMyHomeAuthApi
    {
        /// <summary>
        /// Самая стандартная авторизация через пароль.
        /// Схема запроса:
        /// Login - Номер договора
        /// Timestamp - Мировое время (формат: "yyyy-MM-dd'T'HH:mm:ss.fff'Z'")
        /// Hash1 - Хэш SHA-1
        /// Hash2 - Хэш MD5
        /// </summary>
        /// <param name="login">Номер Договора</param>
        /// <param name="password">Пароль от Аккаунта</param>
        public async Task<Token> authByPassword()
        {
            AuthCredential credential = DomRU.getAuthCrendential();

            DateTimeOffset _date = DateTimeOffset.UtcNow;

            using StringContent content = new StringContent(JsonSerializer.Serialize(new
            {
                login = credential.Login,
                timestamp = _date.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                hash1 = AuthDataFactory.hash1(credential.Password),
                hash2 = AuthDataFactory.hash2(credential.Login, credential.Password, _date.ToString("yyyyMMddHHmmss"))
            }), Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await DomRU.getHttp().HPostAsync($"{Const.DOMAIN_PROD}{Const.AUTHV2}auth/{credential.Login}/password", content))
            {
                if (DomRU.isDebug)
                {
                    Console.WriteLine(response.StatusCode);
                    Console.WriteLine(await response.Content.ReadAsStringAsync());
                }
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    DomRU.getAuthCrendential().Token = JsonSerializer.Deserialize<Token>(json, new JsonSerializerOptions() { IncludeFields = true })!;
                    DomRU.getHttp()._request.Invoke();
                    return DomRU.getAuthCrendential().Token!;
                }
                else
                {
                    DomRU.getHttp()._request.Invoke();
                    return new Token();
                }
            }
        }
    }
}
