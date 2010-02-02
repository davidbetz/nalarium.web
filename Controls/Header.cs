#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    public class Header : System.Web.UI.Control
    {
        private Int32 _level;

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
        public Header()
        {
        }
        public Header(Int32 level)
        {
            Level = level;
        }

        //- #Render -//
        protected override void Render(System.Web.UI.HtmlTextWriter writer)
        {
            String level = Level.ToString();
            System.Text.StringBuilder builder = new System.Text.StringBuilder("<h" + level);
            if (!String.IsNullOrEmpty(ClassName))
            {
                builder.Append(" class=\"" + ClassName + "\"");
            }
            builder.Append(">" + this.Text);
            builder.Append("</h" + level + ">");
            writer.Write(builder.ToString());
            //+
            base.Render(writer);
        }
    }
}