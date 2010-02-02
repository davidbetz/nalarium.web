#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web.Controls
{
    public class MessageButton : System.Web.UI.WebControls.Button
    {
        //- @Message -//
        public String Message { get; set; }

        //+
        //- #OnLoad -//
        protected override void OnInit(EventArgs e)
        {
            OnClientClick = "if(document.getElementById('__THEMELIAMESSAGE')) document.getElementById('__THEMELIAMESSAGE').value = '" + Message + @"';";
            //+
            base.OnInit(e);
        }

        //- @AddOnClientClick -//
        /// <summary>
        /// Appends JavaScript to the client click event.
        /// </summary>
        /// <param name="data">The JavaScript to append.</param>
        public void AddOnClientClick(String data)
        {
            OnClientClick += data;
        }
    }
}