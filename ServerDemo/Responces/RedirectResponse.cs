﻿using ServerDemo.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDemo.Responces
{
    public class RedirectResponse : Response
    {
        public RedirectResponse(string _location) : base(StatusCode.Found)
        {

            this.Headers.Add(Header.Location, _location);

        }
    }
}
