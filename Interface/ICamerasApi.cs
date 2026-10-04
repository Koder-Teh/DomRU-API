using DomruAPI.Entity.CameraAPI;
using DomruAPI.Other.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomruAPI.Interface
{
    internal interface ICamerasApi
    {
        public Task<ListCamera> getCameras();

        public Task<ServerTime> getVideoTime();

        public Task<TranslationUrlResponse> getTranslationUrl(int cameraId);
    }
}
