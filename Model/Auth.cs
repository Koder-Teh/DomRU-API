using DomruAPI.Interface;
using DomruAPI.Other;
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
        public async Task<Token> authByPassword(HandlerHttp http, string login, string password)
        {
            DateTimeOffset _date = DateTimeOffset.UtcNow;

            using StringContent content = new StringContent(JsonSerializer.Serialize(new
            {
                login = login,
                timestamp = _date.ToString("yyyy-MM-dd'T'HH:mm:ss.fff'Z'"),
                hash1 = AuthDataFactory.hash1(password),
                hash2 = AuthDataFactory.hash2(login, password, _date.ToString("yyyyMMddHHmmss"))
            }), Encoding.UTF8, "application/json");

            using (HttpResponseMessage response = await http.HPostAsync($"https://myhome.proptech.ru/auth/v2/auth/{login}/password", content))
            {
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();
                    http._token = JsonSerializer.Deserialize<Token>(json, new JsonSerializerOptions() { IncludeFields = true });
                    http._request.Invoke();
                    return http._token!;
                }
                else
                {
                    http._request.Invoke();
                    return new Token();
                }
            }
        }
    }
}
