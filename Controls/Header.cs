#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Text;
using System.Web.UI;

namespace Nalarium.Web.Controls
{
    public class Header : Control
    {
        private Int32 _level;

        public Header()
        {
        }

        public Header(Int32 level)
        {
            Level = level;
        }

        //+
        //- @Level -//
        public Int32 Level
        {
            get
            {
                if (_level == 0)
                {
                    return 1;
                }
                //+
                return _level;
            }
            set
            {
                if (value > 6)
                {
                    throw new InvalidOperationException("Level may only be 1, 2, 3, 4, 5, or 6.");
                }
                _level = value;
            }
        }

        //- @Text -//
        public String Text { get; set; }

        //- @ClassName -//
        public String ClassName { get; set; }

        //+
        //- @Ctor -//

        //- #Render -//
        protected override void Render(HtmlTextWriter writer)
        {
            String level = Level.ToString();
            var builder = new StringBuilder("<h" + level);
            if (!String.IsNullOrEmpty(ClassName))
            {
                builder.Append(" class=\"" + ClassName + "\"");
            }
            builder.Append(">" + Text);
            builder.Append("</h" + level + ">");
            writer.Write(builder.ToString());
            //+
            base.Render(writer);
        }
    }
}