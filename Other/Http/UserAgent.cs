using System;
using System.Collections.Generic;
using System.Text;

namespace DomruAPI.Other.Http
{
    public class UserAgent
    {
        public Guid _uuid;

        private Random _random;

        private string _modelDevice;

        public UserAgent()
        {
            _uuid = Guid.NewGuid();
            _random = new Random();
            _modelDevice = GenerateModel();
        }

        public string GenerateModel()
        {
            StringBuilder builder = new StringBuilder();
            for(int i = 0; i < 10; i++)
            {
                builder.Append(Const.ALL_CHARS[_random.Next(0, Const.ALL_CHARS.Length)]);
            }

            return builder.ToString();
        }

        public string GenerateUserAgent(string login, string operatorId, string placeId)
        {
            return $"Xiaomi {_modelDevice} | Android 16 | ntk | {Const.VERSION_NOVOTEL_API} | {login} | {operatorId} | {_uuid.ToString()} | {placeId}";
        }
    }
}
