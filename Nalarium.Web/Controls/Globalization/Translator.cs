#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

using System;
using System.Web;
using System.Web.Caching;
using Nalarium.Globalization;
using Nalarium.Net;

namespace Nalarium.Web.Globalization
{
    public static class Translator
    {
        //- @Translate -//
        /// <summary>
        /// Tranlates text from one language to another.
        /// </summary>
        /// <param name="text">The text to translate.</param>
        /// <param name="sourceLanguage">The language from which to translate.</param>
        /// <param name="translatedText">The translated text.</param>
        /// <returns>True is successful, false if not.</returns>
        public static Boolean Translate(String text, String sourceLanguage, out String translatedText)
        {
            return Translate(text, sourceLanguage, Culture.TwoCharacterCultureCode, TimeSpan.FromDays(5), out translatedText);
        }

        /// <summary>
        /// Tranlates text from one language to another.
        /// </summary>
        /// <param name="text">The text to translate.</param>
        /// <param name="sourceLanguage">The language from which to translate.</param>
        /// <param name="targetLanguage">The language to which to translate.</param>
        /// <param name="translatedText">The translated text.</param>
        /// <returns>True is successful, false if not.</returns>
        public static Boolean Translate(String text, String sourceLanguage, String targetLanguage, out String translatedText)
        {
            return Translate(text, sourceLanguage, targetLanguage, TimeSpan.FromDays(5), out translatedText);
        }

        /// <summary>
        /// Tranlates text from one language to another.
        /// </summary>
        /// <param name="text">The text to translate.</param>
        /// <param name="sourceLanguage">The language from which to translate.</param>
        /// <param name="targetLanguage">The language to which to translate.</param>
        /// <param name="cacheExpiration">TimeSpan representing how long the translation should remain in cache.</param>
        /// <param name="translatedText">The translated text.</param>
        /// <returns>True is successful, false if not.</returns>
        public static Boolean Translate(String text, String sourceLanguage, String targetLanguage, TimeSpan cacheExpiration, out String translatedText)
        {
            String key = text + sourceLanguage + targetLanguage;
            Cache cache = HttpContext.Current.Cache;
            if (cache[key] == null)
            {
                //{"responseData": {"translatedText":"Gracias."}, "responseDetails": null, "responseStatus": 200}
                //{"responseData": null, "responseDetails": "invalid translation language pair", "responseStatus": 400}
                String url = String.Format("http://ajax.googleapis.com/ajax/services/language/translate?v=1.0&q={0}&langpair={1}|{2}", text, sourceLanguage, targetLanguage);
                String result = HttpAbstractor.GetWebText(new Uri(url));
                if (result.IndexOf("\"responseStatus\": 200") == -1)
                {
                    translatedText = String.Empty;
                    return false;
                }
                Int32 translatedTextIndex = result.IndexOf("translatedText");
                if (translatedTextIndex == -1)
                {
                    translatedText = String.Empty;
                    return false;
                }
                Int32 endIndex = result.IndexOf("}", translatedTextIndex);
                if (endIndex == -1)
                {
                    translatedText = String.Empty;
                    return false;
                }
                String data = result.Substring(translatedTextIndex, endIndex - translatedTextIndex);
                String[] dataPartArray = data.Split(':');
                //+
                String value = dataPartArray[1].Replace("\"", String.Empty);
                cache.Insert(key, value, null, DateTime.MaxValue, cacheExpiration);
            }
            if (cache[key] != null)
            {
                translatedText = cache[key] as String;
                return true;
            }
            //+
            translatedText = String.Empty;
            return false;
        }
    }
}