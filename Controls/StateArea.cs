#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Web.UI;

namespace Nalarium.Web.Controls
{
    public class StateArea : Control
    {
        //- #Render -//
        protected override void Render(HtmlTextWriter writer)
        {
            writer.Write(GetRenderData());
        }

        //- @GetRenderData -//
        public String GetRenderData()
        {
            return @"
<div id=""__nalariumStateContainer"">
<input id=""__THEMELIAMESSAGE"" name=""__THEMELIAMESSAGE"" type=""hidden"" value=""" + StateTracker.OutputMessage + @""" />
<input id=""__THEMELIASTATE"" name=""__THEMELIASTATE"" type=""hidden"" value=""" + StateTracker.Save() + @""" />
</div>
            ";
        }
    }
}