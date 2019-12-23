using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace OrchardCore.DisplayManagement
{
    public class HtmlContentStringWriter : TextWriter, IHtmlContent
    {
        private List<string> _fragments = new List<string>();

        public override Encoding Encoding => UTF8Encoding.UTF8;

        // Invoked when used as TextWriter to intercept what is supposed to be written
        public override void Write(String value)
        {
            _fragments.Add(value);
        }

        // Invoked by IHtmlContent when rendered on the final output
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            foreach(var fragment in _fragments)
            {
                writer.Write(fragment, encoder);
            }
        }
    }
}
