#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Web.UI;
using Nalarium.Globalization;

namespace Nalarium.Web.Globalization
{
    /// <summary>
    /// Used to translate an entire ASP.NET control tree.
    /// </summary>
    public static class PageTranslator
    {
        //- $Dummy-//

        //- @Translate-//
        /// <summary>
        /// Translates an entire control tree to the currently set culture.
        /// </summary>
        /// <typeparam name="T">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <param name="control">Control at which to begin translation.  All descendants will be translated.</param>
        /// <param name="sourceLanguageCode">The language in which the controls are currently written.</param>
        public static void Translate<T>(Control control, String sourceLanguageCode) where T : Control, ITextControl
        {
            Translate<T, Dummy, Dummy, Dummy, Dummy>(control, sourceLanguageCode, Culture.TwoCharacterCultureCode);
        }

        /// <summary>
        /// Translates an entire control tree.
        /// </summary>
        /// <typeparam name="T">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <param name="control">Control at which to begin translation.  All descendants will be translated.</param>
        /// <param name="sourceLanguageCode">The language in which the controls are currently written.</param>
        /// <param name="targetLanguageCode">The language to which to translate.</param>
        public static void Translate<T>(Control control, String sourceLanguageCode, String targetLanguageCode) where T : Control, ITextControl
        {
            Translate<T, Dummy, Dummy, Dummy, Dummy>(control, sourceLanguageCode, targetLanguageCode);
        }

        /// <summary>
        /// Translates an entire control tree to the currently set culture.
        /// </summary>
        /// <typeparam name="T">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T2">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T3">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <param name="control">Control at which to begin translation.  All descendants will be translated.</param>
        /// <param name="sourceLanguageCode">The language in which the controls are currently written.</param>
        public static void Translate<T, T2>(Control control, String sourceLanguageCode)
            where T : Control, ITextControl
            where T2 : Control, ITextControl
        {
            Translate<T, T2, Dummy, Dummy, Dummy>(control, sourceLanguageCode, Culture.TwoCharacterCultureCode);
        }

        /// <summary>
        /// Translates an entire control tree.
        /// </summary>
        /// <typeparam name="T">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T2">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <param name="control">Control at which to begin translation.  All descendants will be translated.</param>
        /// <param name="sourceLanguageCode">The language in which the controls are currently written.</param>
        /// <param name="targetLanguageCode">The language to which to translate.</param>
        public static void Translate<T, T2>(Control control, String sourceLanguageCode, String targetLanguageCode)
            where T : Control, ITextControl
            where T2 : Control, ITextControl
        {
            Translate<T, T2, Dummy, Dummy, Dummy>(control, sourceLanguageCode, targetLanguageCode);
        }

        /// <summary>
        /// Translates an entire control tree to the currently set culture.
        /// </summary>
        /// <typeparam name="T">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T2">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T3">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <param name="control">Control at which to begin translation.  All descendants will be translated.</param>
        /// <param name="sourceLanguageCode">The language in which the controls are currently written.</param>
        public static void Translate<T, T2, T3>(Control control, String sourceLanguageCode)
            where T : Control, ITextControl
            where T2 : Control, ITextControl
            where T3 : Control, ITextControl
        {
            Translate<T, T2, T3, Dummy, Dummy>(control, sourceLanguageCode, Culture.TwoCharacterCultureCode);
        }

        /// <summary>
        /// Translates an entire control tree.
        /// </summary>
        /// <typeparam name="T">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T2">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T3">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <param name="control">Control at which to begin translation.  All descendants will be translated.</param>
        /// <param name="sourceLanguageCode">The language in which the controls are currently written.</param>
        /// <param name="targetLanguageCode">The language to which to translate.</param>
        public static void Translate<T, T2, T3>(Control control, String sourceLanguageCode, String targetLanguageCode)
            where T : Control, ITextControl
            where T2 : Control, ITextControl
            where T3 : Control, ITextControl
        {
            Translate<T, T2, T3, Dummy, Dummy>(control, sourceLanguageCode, targetLanguageCode);
        }

        /// <summary>
        /// Translates an entire control tree to the currently set culture.
        /// </summary>
        /// <typeparam name="T">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T2">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T3">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T4">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <param name="control">Control at which to begin translation.  All descendants will be translated.</param>
        /// <param name="sourceLanguageCode">The language in which the controls are currently written.</param>
        public static void Translate<T, T2, T3, T4>(Control control, String sourceLanguageCode)
            where T : Control, ITextControl
            where T2 : Control, ITextControl
            where T3 : Control, ITextControl
            where T4 : Control, ITextControl
        {
            Translate<T, T2, T3, T4, Dummy>(control, sourceLanguageCode, Culture.TwoCharacterCultureCode);
        }

        /// Translates an entire control tree.
        /// </summary>
        /// <typeparam name="T">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T2">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T3">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T4">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <param name="control">Control at which to begin translation.  All descendants will be translated.</param>
        /// <param name="sourceLanguageCode">The language in which the controls are currently written.</param>
        /// <param name="targetLanguageCode">The language to which to translate.</param>
        public static void Translate<T, T2, T3, T4>(Control control, String sourceLanguageCode, String targetLanguageCode)
            where T : Control, ITextControl
            where T2 : Control, ITextControl
            where T3 : Control, ITextControl
            where T4 : Control, ITextControl
        {
            Translate<T, T2, T3, T4, Dummy>(control, sourceLanguageCode, targetLanguageCode);
        }

        /// Translates an entire control tree to the currently set culture.
        /// </summary>
        /// <typeparam name="T">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T2">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T3">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T4">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T5">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <param name="control">Control at which to begin translation.  All descendants will be translated.</param>
        /// <param name="sourceLanguageCode">The language in which the controls are currently written.</param>
        public static void Translate<T, T2, T3, T4, T5>(Control control, String sourceLanguageCode)
            where T : Control, ITextControl
            where T2 : Control, ITextControl
            where T3 : Control, ITextControl
            where T4 : Control, ITextControl
            where T5 : Control, ITextControl
        {
            Translate<T, T2, T3, T4, Dummy>(control, sourceLanguageCode, Culture.TwoCharacterCultureCode);
        }

        /// <summary>
        /// Translates an entire control tree.
        /// </summary>
        /// <typeparam name="T">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T2">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T3">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T4">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <typeparam name="T5">Type of Control which to translate.  Must be an ITextControl.</typeparam>
        /// <param name="control">Control at which to begin translation.  All descendants will be translated.</param>
        /// <param name="sourceLanguageCode">The language in which the controls are currently written.</param>
        /// <param name="targetLanguageCode">The language to which to translate.</param>
        public static void Translate<T, T2, T3, T4, T5>(Control control, String sourceLanguageCode, String targetLanguageCode)
            where T : Control, ITextControl
            where T2 : Control, ITextControl
            where T3 : Control, ITextControl
            where T4 : Control, ITextControl
            where T5 : Control, ITextControl
        {
            if (control == null)
            {
                return;
            }
            foreach (Control childControl in control.Controls)
            {
                if (!TranslateSingleControl<T>(childControl, sourceLanguageCode, targetLanguageCode))
                {
                    Translate<T, T2, T3, T4, T5>(childControl, sourceLanguageCode, targetLanguageCode);
                }
                if (typeof(T2) != Dummy._type)
                {
                    if (!TranslateSingleControl<T2>(childControl, sourceLanguageCode, targetLanguageCode))
                    {
                        Translate<T, T2, T3, T4, T5>(childControl, sourceLanguageCode, targetLanguageCode);
                    }
                }
                if (typeof(T3) != Dummy._type)
                {
                    if (!TranslateSingleControl<T3>(childControl, sourceLanguageCode, targetLanguageCode))
                    {
                        Translate<T, T2, T3, T4, T5>(childControl, sourceLanguageCode, targetLanguageCode);
                    }
                }
                if (typeof(T4) != Dummy._type)
                {
                    if (!TranslateSingleControl<T4>(childControl, sourceLanguageCode, targetLanguageCode))
                    {
                        Translate<T, T2, T3, T4, T5>(childControl, sourceLanguageCode, targetLanguageCode);
                    }
                }
                if (typeof(T5) != Dummy._type)
                {
                    if (!TranslateSingleControl<T5>(childControl, sourceLanguageCode, targetLanguageCode))
                    {
                        Translate<T, T2, T3, T4, T5>(childControl, sourceLanguageCode, targetLanguageCode);
                    }
                }
            }
        }

        //- $TranslateSingleControl -//
        private static Boolean TranslateSingleControl<T>(Control childControl, String sourceLanguageCode, String targetLanguageCode) where T : Control, ITextControl
        {
            var literal = childControl as T;
            if (literal != null)
            {
                String translatedText;
                if (Translator.Translate(literal.Text, sourceLanguageCode, targetLanguageCode, out translatedText))
                {
                    literal.Text = translatedText;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Nested type: Dummy

        private class Dummy : Control, ITextControl
        {
            internal static readonly Type _type = typeof(Dummy);
            //+
            //- @Text -//

            #region ITextControl Members

            public string Text
            {
                get
                {
                    throw new NotImplementedException();
                }
                set
                {
                    throw new NotImplementedException();
                }
            }

            #endregion
        }

        #endregion
    }
}