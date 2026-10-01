using DomruAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DomruAPI.Other
{
    public class GetModels
    {
        public Auth Auth { get; set; }

        public Camera Camera { get; set; }

        public GetModels()
        {
            Auth = new Auth();
            Camera = new Camera();
        }
    }
}
