using System;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;

[assembly: CLSCompliant(true)]
[assembly: AssemblyTitle("Nalarium Pro 3.0 - Web")]
[assembly: AssemblyDescription(".NET Development Platform")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("Jampad Technology, Inc.")]
[assembly: AssemblyProduct("Nalarium Pro 2.0 - Web")]
[assembly: AssemblyCopyright("Copyright © Jampad Technology, Inc. 2008-2010")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
//+

[assembly: ComVisible(false)]
//+

[assembly: Guid("19B9E4C6-CC80-4C5D-A167-ACDF7138F48E")]
//+

[assembly: AssemblyVersion("3.0.0.0")]
[assembly: AssemblyFileVersion("3.0.0.0")]
//[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("Nalarium.Web.Field, PublicKey=dc6429114df2bd49")]

[assembly: InternalsVisibleTo("Nalarium.Web.Processing, PublicKey=dc6429114df2bd49")]
//+

namespace Nalarium.Web.Properties
{
    [NotDocumented]
    public class AssemblyInfo
    {
        internal static Assembly _Assembly = typeof(AssemblyInfo).Assembly;

        //+
        public static String AssemblyName = _Assembly.FullName;
        public static Byte[] PublicKey = _Assembly.GetName().GetPublicKey();
        public static String PublicKeyString = Encoding.UTF8.GetString(PublicKey).ToLower();
    }
}