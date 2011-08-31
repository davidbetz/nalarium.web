#region Copyright

//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010

#endregion

//+
using System;
using Nalarium.Data;

namespace Nalarium.Web
{
    internal class StateData
    {
        public StateData()
        {
            ValueData = new Base64StorableMap();
            ControlData = new Base64StorableMap();
            StateMap = new StringKeyValueMap();
        }

        internal Base64StorableMap ValueData { get; set; }
        internal Base64StorableMap ControlData { get; set; }
        internal StringKeyValueMap StateMap { get; set; }
        internal String PostedMessage { get; set; }
        internal String OutputMessage { get; set; }
        internal String[] PostedMessageParameterArray { get; set; }
        internal String Message { get; set; }

        public void Init()
        {
            //PostedMessage = String.Empty;
            //Message = String.Empty;
            //OutputMessage = String.Empty;
            //ValueData = new Nalarium.Data.Base64StorableMap();
            //ControlData = new Nalarium.Data.Base64StorableMap();
            //+
            if (Http.Method != HttpVerbs.Post)
            {
                return;
            }
            //+ message
            String message = Http.Form.Get("__THEMELIAMESSAGE");
            if (!String.IsNullOrEmpty(message))
            {
                Int32 hashPosition = message.IndexOf("#");
                if (hashPosition > -1)
                {
                    String messageParameterSeries = message.Substring(hashPosition + 1, message.Length - hashPosition - 1);
                    PostedMessageParameterArray = messageParameterSeries.Split('#');
                    message = message.Substring(0, hashPosition);
                }
                PostedMessage = message.Replace("@", "::");
                Message = PostedMessage;
            }
            //+ state
            var stringKeyValueMap = new StringKeyValueMap();
            String state = Http.Form.Get("__THEMELIASTATE");
            if (!String.IsNullOrEmpty(state))
            {
                String[] partArray = GetStatePartArray(state);
                LoadControlData(stringKeyValueMap, partArray[0]);
                LoadValueData(stringKeyValueMap, partArray[1]);
            }
            StateMap = stringKeyValueMap;
        }

        //- $LoadControlData -//
        private static void LoadControlData(StringKeyValueMap stringKeyValueMap, String blogState)
        {
            var map = new Base64StorableMap(blogState);
            map.GetKeyList().ForEach((controlKey) =>
                                     {
                                         String controlId = map[controlKey];
                                         String value = Http.Form.Get(controlId);
                                         //+ re-register
                                         StateTracker.Set(StateEntryType.ControlId, controlKey, controlId);
                                         //+ load
                                         if (!String.IsNullOrEmpty(value))
                                         {
                                             stringKeyValueMap.Add(controlKey, new StringKeyValue
                                                                               {
                                                                                   Key = controlId,
                                                                                   Value = value
                                                                               });
                                         }
                                         else
                                         {
                                             stringKeyValueMap.Add(controlKey, new StringKeyValue
                                                                               {
                                                                                   Key = controlId,
                                                                                   Value = null
                                                                               });
                                         }
                                     });
        }

        //- $LoadControlData -//
        private static void LoadValueData(StringKeyValueMap stringKeyValueMap, String blogState)
        {
            var map = new Base64StorableMap(blogState);
            map.GetKeyList().ForEach((key) => StateTracker.Set(StateEntryType.Value, key, map[key]));
        }

        //- $GetStatePartArray -//
        private static String[] GetStatePartArray(String state)
        {
            String controlIdPart = String.Empty;
            String valuePart = String.Empty;
            Int32 splitterLocation = state.IndexOf(":");
            if (splitterLocation > -1)
            {
                controlIdPart = state.Substring(1, splitterLocation - 1);
                valuePart = state.Substring(splitterLocation + 2, state.Length - splitterLocation - 2);
            }
            else
            {
                if (state[0] == 'C')
                {
                    controlIdPart = state.Substring(1, state.Length - 1);
                }
                else if (state[0] == 'V')
                {
                    valuePart = state.Substring(1, state.Length - 1);
                }
            }
            //+
            return new String[2]
                   {
                       controlIdPart, valuePart
                   };
        }
    }
}