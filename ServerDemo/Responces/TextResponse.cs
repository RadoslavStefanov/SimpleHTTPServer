using ServerDemo.HTTP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerDemo.Responces
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string text) : base(text,ContentType.PlainText)
        {
        }
    }
}
