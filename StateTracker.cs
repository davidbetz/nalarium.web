#region Copyright
//+ Nalarium Pro 3.0 - Web Module
//+ Copyright © Jampad Technology, Inc. 2008-2010
#endregion
using System;
//+
namespace Nalarium.Web
{
    /// <summary>
    /// Used to interact with Nalarium state.
    /// </summary>
    public static class StateTracker
    {
        public static class Info
        {
            public const String Scope = "__$State$";
            public const String StateData = "StateData";
        }

        //+ field
        private static Object _lock = new Object();
        private static StringKeyValueMap _blankStringKeyValueMap = new StringKeyValueMap();

        //- @OriginalState -//
        /// <summary>
        /// Original state before any modifications.
        /// </summary>
        internal static StateData StateData
        {
            get
            {
                StateData data = HttpData.GetScopedItem<StateData>(Info.Scope, Info.StateData);
                if (data == null)
                {
                    data = new StateData();
                    HttpData.SetScopedItem<StateData>(Info.Scope, Info.StateData, data);
                }
                //+
                return data;
            }
        }

        //- $ValueData -//
        private static Nalarium.Data.Base64StorableMap ValueData
        {
            get
            {
                return StateData.ValueData;
            }
            set
            {
                StateData.ValueData = value;
            }
        }

        //- $ControlData -//
        private static Nalarium.Data.Base64StorableMap ControlData
        {
            get
            {
                return StateData.ControlData;
            }
            set
            {
                StateData.ControlData = value;
            }
        }

        //+
        //- @PostedMessage -//
        /// <summary>
        /// Message posted to the system.
        /// </summary>
        public static String PostedMessage
        {
            get
            {
                return StateData.PostedMessage;
            }
            internal set
            {
                StateData.PostedMessage = value;
            }
        }

        //- @PostedMessageParameterArray -//
        /// <summary>
        /// Array of message parameters posted to the system.  These are the portions after and separated by a # character.
        /// </summary>
        public static String[] PostedMessageParameterArray
        {
            get
            {
                return StateData.PostedMessageParameterArray;
            }
            internal set
            {
                StateData.PostedMessageParameterArray = value;
            }
        }

        //- @Message -//
        /// <summary>
        /// Current message in the system.
        /// </summary>
        public static String Message
        {
            get
            {
                return StateData.Message;
            }
            set
            {
                StateData.Message = value;
            }
        }

        //- @OutputMessage -//
        /// <summary>
        /// Message to be sent to the web browser.
        /// </summary>
        public static String OutputMessage
        {
            get
            {
                return StateData.OutputMessage;
            }
            set
            {
                StateData.OutputMessage = value;
            }
        }

        //- @OriginalState -//
        /// <summary>
        /// Original state before any modifications.
        /// </summary>
        public static StringKeyValueMap OriginalState
        {
            get
            {
                if (Http.Method == HttpVerbs.Post)
                {
                    return StateData.StateMap;
                }
                //+
                return _blankStringKeyValueMap;
            }
            internal set
            {
                StateData.StateMap = value;
            }
        }

        //+
        //- @GetPostedMessageParameter -//
        /// <summary>
        /// Gets a posted message parameter by position
        /// </summary>
        /// <param name="position">Position of the parameter to obtain.</param>
        /// <returns>Parameter or blank if not found.</returns>
        public static String GetPostedMessageParameter(Position position)
        {
            return Collection.GetArrayPart<String>(StateData.PostedMessageParameterArray, position) ?? String.Empty;
        }
        /// <summary>
        /// Gets a posted message parameter by position
        /// </summary>
        /// <param name="position">Position of the parameter to obtain.</param>
        /// <returns>Parameter or blank if not found.</returns>
        public static String GetPostedMessageParameter(Int32 position)
        {
            String[] partArray = StateData.PostedMessageParameterArray;
            if (partArray.Length >= position)
            {
                return partArray[partArray.Length - position - 1];
            }
            //+
            return String.Empty;
        }

        //- @Get -//
        /// <summary>
        /// Gets a value from state.
        /// </summary>
        /// <param name="entryType">Type of entry (either a control or value).</param>
        /// <param name="key">State key to the data.</param>
        /// <returns>Value of the entry.</returns>
        public static String Get(StateEntryType entryType, String key)
        {
            if (String.IsNullOrEmpty(key))
            {
                return String.Empty;
            }
            if (entryType == StateEntryType.ControlId)
            {
                lock (_lock)
                {
                    if (ControlData.ContainsKey(key))
                    {
                        return ControlData[key];
                    }
                }
            }
            else if (entryType == StateEntryType.Value)
            {
                lock (_lock)
                {
                    if (ValueData.ContainsKey(key))
                    {
                        return ValueData[key];
                    }
                }
            }
            //+
            return String.Empty;
        }

        //- @Set -//
        /// <summary>
        /// Set a value in state.
        /// </summary>
        /// <param name="entryType">Type of entry (either a control or value).</param>
        /// <param name="key">State key to the data.</param>
        /// <param name="data">Value of the entry.</param>
        public static void Set(StateEntryType entryType, String key, String data)
        {
            if (String.IsNullOrEmpty(key))
            {
                return;
            }
            if (entryType == StateEntryType.ControlId)
            {
                lock (_lock)
                {
                    if (ControlData.ContainsKey(key))
                    {
                        ControlData[key] = data;
                    }
                    else
                    {
                        ControlData.Add(key, data);
                    }
                }
            }
            else if (entryType == StateEntryType.Value)
            {
                lock (_lock)
                {
                    if (ValueData.ContainsKey(key))
                    {
                        ValueData[key] = data;
                    }
                    else
                    {
                        ValueData.Add(key, data);
                    }
                }
            }
        }

        //- @GetOriginalValue -//
        /// <summary>
        /// Obtains the original value from state before any modifications.
        /// </summary>
        /// <param name="key">State key to the data.</param>
        /// <returns>Value or blank if not found.</returns>
        public static String GetOriginalValue(String key)
        {
            StringKeyValue stringKeyValue = OriginalState[key];
            if (stringKeyValue != null)
            {
                return stringKeyValue.Value;
            }
            //+
            return String.Empty;
        }

        //- @GetControlId -//
        /// <summary>
        /// Obtains the ID of a control by state key.
        /// </summary>
        /// <param name="key"></param>
        /// <param name="key">State key to the data.</param>
        /// <returns>ID or blank if not found.</returns>
        public static String GetControlId(String key)
        {
            StringKeyValue stringKeyValue = OriginalState[key];
            if (stringKeyValue != null)
            {
                return stringKeyValue.Key;
            }
            //+
            return String.Empty;
        }

        //- @MessageIn -//
        /// <summary>
        /// Tests to see if the posted messages is in the array.
        /// </summary>
        /// <param name="commandArray">String array of messages.</param>
        /// <returns>True if message is in array; otherwise false.</returns>
        public static Boolean PostedMessageIn(params String[] commandArray)
        {
            foreach (String command in commandArray)
            {
                if (PostedMessage == command)
                {
                    return true;
                }
            }
            //+
            return false;
        }

        //- @Save -//
        /// <summary>
        /// Returned the current state as a base64 string.
        /// </summary>
        /// <returns>Base64 string of the current state.</returns>
        public static String Save()
        {
            lock (_lock)
            {
                if (ControlData.Count > 0 && ValueData.Count > 0)
                {
                    return String.Format("C" + ControlData.Save() + ":V" + ValueData.Save());
                }
                else if (ControlData.Count > 0)
                {
                    return "C" + ControlData.Save();
                }
                else if (ValueData.Count > 0)
                {
                    return "V" + ValueData.Save();
                }
            }
            //+
            return null;
        }

        //- @OnInitProcessorExecute -//
        public static void EnsureState()
        {
        }
    }
}