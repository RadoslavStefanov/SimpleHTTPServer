﻿using ServerDemo.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDemo.HTTP
{
    public class Header
    {

        public const string ContentType = "Content-Type";
        public const string ContentLength = "Content-Length";
        public const string ContentDisposition = "Content-Disposition";
        public const string Cookie = "Cookie";
        public const string Date = "Date";
        public const string Location = "Location";
        public const string Server = "Server";
        public const string SetCookie = "Set-Cookie";

        public Header(string _name,string _value)
        {
            Guard.AgainstNull(_name,nameof(_name));
            Guard.AgainstNull(_value,nameof(_value));

            Name = _name;
            Value = _value;
        }

        public string Name { get; init; }
        public string Value { get; init; }

        public override string ToString()
        => $"{this.Name}: {this.Value}";

    }
}
