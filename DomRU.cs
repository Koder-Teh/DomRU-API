using DomruAPI.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomruAPI
{
    public class DomRU
    {
        private HandlerHttp _handlerhttp;

        private GetModels _models;

        public DomRU()
        {
            _handlerhttp = new HandlerHttp();
            _models = new GetModels();
        }

        public GetModels getModels()
        {
            return _models;
        }

        public HandlerHttp getHttp()
        {
            return _handlerhttp;
        }
    }
}
