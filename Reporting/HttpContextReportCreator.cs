#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Web;
using Nalarium.Reporting;
//+
using Nalarium.Reporting.ReportCreator;
using Nalarium.Reporting.ReportCreator.Formatter;

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
            var contextData = content as HttpContext;
            if (contextData != null)
            {
                Exception exceptionData = contextData.Error;
                if (exceptionData != null)
                {
                    Write(exceptionData.Message, contextData);
                    //+
                    return Result.ToString();
                }
            }
            var data = content as Object[];
            if (data != null)
            {
                Write("Information Report", FormatterType.MainHeading);
                //+
                String message;
                HttpContext ctx;
                if (IsValid(data, out message, out ctx))
                {
                    Write(message, ctx);
                }
            }
            //+
            return Result.ToString();
        }

        //- $Write -//
        private void Write(String message, HttpContext ctx)
        {
            Exception ex = ctx.Server.GetLastError();
            Write("Exception Report", FormatterType.MainHeading);
            Write("Time", FormatterType.Heading);
            Write(DateTime.Now.ToString(), FormatterType.Normal);
            Write(FormatterType.Break);
            Write("Type", FormatterType.Heading);
            Write(message, FormatterType.Normal);
            Write(FormatterType.Break);
            if (ctx != null)
            {
                if (ctx.Request != null)
                {
                    Write("IP Address", FormatterType.Heading);
                    Write(Http.IPAddress, FormatterType.Normal);
                    Write(FormatterType.Break);
                    Write("URL", FormatterType.Heading);
                    Write(Http.Uri.AbsoluteUri, FormatterType.Normal);
                    Write(FormatterType.Break);
                    Write("User Agent", FormatterType.Heading);
                    Write(ctx.Request.UserAgent, FormatterType.Normal);
                    Write(FormatterType.Break);
                }
                Write("Context Items", FormatterType.Heading);
                Write(FormatterType.DictionaryBegin);
                foreach (Object i in ctx.Items.Keys)
                {
                    Write(i.ToString(), FormatterType.DictionaryTerm);
                    Write(ctx.Items[i].ToString(), FormatterType.DictionaryDefinition);
                }
                Write(FormatterType.DictionaryEnd);
                Write(FormatterType.Break);
            }
            if (ex != null)
            {
                Write("Exception Information", FormatterType.Heading);
                Write("exception.Message", FormatterType.SubHeading);
                Write(ex.Message, FormatterType.Normal);
                Write(FormatterType.Break);
                Write("exception.StackTrace", FormatterType.SubHeading);
                Write(ex.StackTrace, FormatterType.Normal);
                Write(FormatterType.Break);
                Exception innerException = ex.InnerException;
                if (innerException != null)
                {
                    Write("InnerException Information", FormatterType.Heading);
                }
                while (innerException != null)
                {
                    Write("innerException.Message", FormatterType.SubHeading);
                    Write(innerException.Message, FormatterType.Normal);
                    Write(FormatterType.Break);
                    Write("innerException.StackTrace", FormatterType.SubHeading);
                    Write(innerException.StackTrace, FormatterType.Normal);
                    Write(FormatterType.Break);
                    innerException = innerException.InnerException;
                }
            }
        }
    }
}