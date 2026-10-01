using DomruAPI.Model;
using DomruAPI.Other;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomruAPI.Interface
{
    internal interface ICamerasApi
    {
        public Task<ListCamera> getCameras(HandlerHttp http);
    }
}
