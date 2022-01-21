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

        public const string ContentType = "ContentType";
        public const string ContentLength = "ContentLength";
        public const string ContentDisposition = "Content-Disposition";
        public const string Date = "Date";
        public const string Location = "Location";
        public const string Server = "Server";

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
