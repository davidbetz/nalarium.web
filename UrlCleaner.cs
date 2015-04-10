#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;

namespace Nalarium.Web
{
    /// <summary>
    /// Cleans a URL.
    /// </summary>
    [Obsolete("Use Nalarium.UrlCleaner")]
    public static class UrlCleaner
    {
        //- @Merge -//
        /// <summary>
        /// Cleanly merges two paths.
        /// </summary>
        /// <param name="path1">The first path.</param>
        /// <param name="path2">The second path.</param>
        /// <returns>The merged path.</returns>
        [Obsolete("Use Join")]
        public static String Merge(String path1, String path2)
        {
            return Join(path1, path2);
        }

        //- @Join -//
        /// <summary>
        /// Cleanly joins two paths.
        /// </summary>
        /// <param name="path1">The first path.</param>
        /// <param name="path2">The second path.</param>
        /// <returns>The merged path.</returns>
        public static String Join(String path1, String path2)
        {
            return CleanWebPath(path1) + "/" + CleanWebPath(path2);
        }

        //- @FixWebPath -//
        /// <summary>
        /// Removes slashes from the beginning and end of a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The fixed path.</returns>
        public static String CleanWebPath(String path)
        {
            return CleanWebPathHead(CleanWebPathTail(path));
        }

        //- @FixWebPathHead -//
        /// <summary>
        /// Removes slashes from the beginning of a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The fixed path.</returns>
        public static String CleanWebPathHead(String path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return String.Empty;
            }
            if (path.StartsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(1, path.Length - 1);
            }
            //+
            return path;
        }

        //- @FixWebPathTail -//
        /// <summary>
        /// Removes slashes from the end of a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>The fixed path.</returns>
        public static String CleanWebPathTail(String path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return String.Empty;
            }
            if (path.EndsWith("/", StringComparison.OrdinalIgnoreCase))
            {
                path = path.Substring(0, path.Length - 1);
            }
            //+
            return path;
        }

        //- @RemoveEndingQuestionMark -//
        /// <summary>
        /// Removes the ending question mark of a path.
        /// </summary>
        /// <param name="path">The path.</param>
        /// <returns>Path without question mark.</returns>
        public static String RemoveEndingQuestionMark(String path)
        {
            if (String.IsNullOrEmpty(path))
            {
                return String.Empty;
            }
            Int32 index = path.IndexOf("?");
            if (index > -1)
            {
                path = path.Substring(0, index);
            }
            //+
            return path;
        }
    }
}