#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
using Nalarium.Reporting;
//+
namespace Nalarium.Web.Reporting
{
    public class HttpContextReportCreator : ReportCreator
    {
        //- @IsException -//
        public override Boolean IsException
        {
            get
            {
                return true;
            }
        }

        //+
        //- @CreateCore -//
        /// <summary>
        /// Generates the report.
        /// </summary>
        /// <param name="map">The map.</param>
        /// <returns></returns>
        protected override String CreateCore(Object content)
        {
            System.Web.HttpContext contextData = content as System.Web.HttpContext;
            if (contextData != null)
            {
                Exception exceptionData = contextData.Error;
                if (exceptionData != null)
                {
                    Write(exceptionData.Message, contextData);
                    //+
                    return this.Result.ToString();
                }
            }
            Object[] data = content as Object[];
            if (data != null)
            {
                this.Write("Information Report", FormatterType.MainHeading);
                //+
                String message;
                System.Web.HttpContext ctx;
                if (IsValid(data, out message, out ctx))
                {
                    Write(message, ctx);
                }
            }
            //+
            return this.Result.ToString();
        }

        //- $Write -//
        private void Write(String message, System.Web.HttpContext ctx)
        {
            Exception ex = ctx.Server.GetLastError();
            this.Write("Exception Report", FormatterType.MainHeading);
            this.Write("Time", FormatterType.Heading);
            this.Write(DateTime.Now.ToString(), FormatterType.Normal);
            this.Write(FormatterType.Break);
            this.Write("Type", FormatterType.Heading);
            this.Write(message, FormatterType.Normal);
            this.Write(FormatterType.Break);
            if (ctx != null)
            {
                if (ctx.Request != null)
                {
                    this.Write("IP Address", FormatterType.Heading);
                    this.Write(Http.IPAddress, FormatterType.Normal);
                    this.Write(FormatterType.Break);
                    this.Write("URL", FormatterType.Heading);
                    this.Write(Http.Uri.AbsoluteUri, FormatterType.Normal);
                    this.Write(FormatterType.Break);
                    this.Write("User Agent", FormatterType.Heading);
                    this.Write(ctx.Request.UserAgent, FormatterType.Normal);
                    this.Write(FormatterType.Break);
                }
                this.Write("Context Items", FormatterType.Heading);
                this.Write(FormatterType.DictionaryBegin);
                foreach (Object i in ctx.Items.Keys)
                {
                    this.Write(i.ToString(), FormatterType.DictionaryTerm);
                    this.Write(ctx.Items[i].ToString(), FormatterType.DictionaryDefinition);
                }
                this.Write(FormatterType.DictionaryEnd);
                this.Write(FormatterType.Break);
            }
            if (ex != null)
            {
                this.Write("Exception Information", FormatterType.Heading);
                this.Write("exception.Message", FormatterType.SubHeading);
                this.Write(ex.Message, FormatterType.Normal);
                this.Write(FormatterType.Break);
                this.Write("exception.StackTrace", FormatterType.SubHeading);
                this.Write(ex.StackTrace, FormatterType.Normal);
                this.Write(FormatterType.Break);
                Exception innerException = ex.InnerException;
                if (innerException != null)
                {
                    this.Write("InnerException Information", FormatterType.Heading);
                }
                while (innerException != null)
                {
                    this.Write("innerException.Message", FormatterType.SubHeading);
                    this.Write(innerException.Message, FormatterType.Normal);
                    this.Write(FormatterType.Break);
                    this.Write("innerException.StackTrace", FormatterType.SubHeading);
                    this.Write(innerException.StackTrace, FormatterType.Normal);
                    this.Write(FormatterType.Break);
                    innerException = innerException.InnerException;
                }
            }
        }
    }
}