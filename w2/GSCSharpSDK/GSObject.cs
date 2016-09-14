/*
 * Copyright (C) 2011 Gigya, Inc.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace Gigya.Socialize.SDK
{
    /// <summary>  
    /// Used for passing parameters when issueing requests e.g. GSRequest.send
    /// As well as returning response data e.g. GSResponse.getData
    /// The dictionary can hold the following types: string, boolean, int, long, Array of GSObjects, GSObject    
    /// </summary>
    /// <remarks>Author: Tamir Korem. Updated by: Yaron Thurm</remarks>
    [Serializable]
    public class GSObject
    {
        // Using StringComparer.Ordinal to ensure alphabetic order of keys (Important when calculating base string for OAuth1 signatures)
        private JSONObject _map = new JSONObject(StringComparer.Ordinal);

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public GSObject() { }

        /// <summary>
        /// Construct a GSObject from json string.
        /// Throws exception if unable to parse json
        /// </summary>
        /// <param name="json">the json formatted string</param>        
        public GSObject(string json) : this(new JSONObject(json)) { }

        /// <summary>
        /// Construct a GSObject from a JSONObject - used internally.
        /// throws exception if unable to parse json
        /// </summary>
        /// <param name="jsonObj">the json object to parse</param>
        internal GSObject(JSONObject jsonObj)
        {
            string key;
            object value;
            foreach (KeyValuePair<string, object> kvp in jsonObj)
            {
                key = kvp.Key;
                value = kvp.Value;

                if (value == null)
                    this.Put(key, value); // null values are allowed
                else if (value is decimal)
                    this.Put(key, (double)(decimal)value);
                else if (value.GetType().IsPrimitive || value is string)
                    this.Put(key, value);
                else if (value is JSONObject) // value itself is a json object
                {
                    // Create a new GSObject to put as the value of the current key. the source for this child is the current value
                    GSObject child = new GSObject((JSONObject)value);
                    this.Put(key, child);
                }
                else if (value is JSONArray) // value is an array
                {
                    GSArray childArray = new GSArray((JSONArray)value);
                    this.Put(key, childArray);
                }
            }
        }
        #endregion


        #region - PUTS -
        /// <summary>
        ///  Associates the specified value with the specified key in this dictionary. 
        ///  If the dictionary previously contained a mapping for the key, the old value is replaced by the specified value.
        /// </summary>
        /// <param name="key">key with which the specified value is to be associated</param>
        /// <param name="value">a string value to be associated with the specified key</param>
        public GSObject Put(string key, string value)
        {
            if (key != null)
                this._map[key] = value;

            return this;
        }

        /// <summary>
        ///  Associates the specified value with the specified key in this dictionary. 
        ///  If the dictionary previously contained a mapping for the key, the old value is replaced by the specified value.
        /// </summary>
        /// <param name="key">key with which the specified value is to be associated</param>
        /// <param name="value">an int value to be associated with the specified key </param>
        public GSObject Put(string key, int value)
        {
            if (key != null)
                this._map[key] = value;

            return this;
        }

        /// <summary>
        /// Associates the specified value with the specified key in this dictionary.
        /// If the dictionary previously contained a mapping for the key, the old value is replaced by the specified value.
        /// </summary>
        /// <param name="key">key with which the specified value is to be associated</param>
        /// <param name="value">a long value to be associated with the specified key </param>
        public GSObject Put(string key, long value)
        {
            if (key != null)
                this._map[key] = value;
            return this;
        }

        /// <summary>
        /// Associates the specified value with the specified key in this dictionary.
        /// If the dictionary previously contained a mapping for the key, the old value is replaced by the specified value.
        /// </summary>
        /// <param name="key">key with which the specified value is to be associated</param>
        /// <param name="value">a bool value to be associated with the specified key</param>
        public GSObject Put(string key, bool value)
        {
            if (key != null)
                this._map[key] = value;
            return this;
        }

        /// <summary>
        /// Associates the specified value with the specified key in this dictionary.
        /// If the dictionary previously contained a mapping for the key, the old value is replaced by the specified value.
        /// </summary>
        /// <param name="key">key with which the specified value is to be associated</param>
        /// <param name="value">a double value to be associated with the specified key</param>
        public GSObject Put(string key, double value)
        {
            if (key != null)
                this._map[key] = value;
            return this;
        }

        /// <summary>
        /// Associates the specified value with the specified key in this dictionary. 
        /// If the dictionary previously contained a mapping for the key, the old value is replaced by the specified value.
        /// </summary>
        /// <param name="key">key with which the specified value is to be associated</param>
        /// <param name="value">a GSObject value to be associated with the specified key </param>
        public GSObject Put(string key, GSObject value)
        {
            if (key != null)
                this._map[key] = value;
            return this;
        }

        /// <summary>
        /// Associates the specified value with the specified key in this dictionary. 
        /// If the dictionary previously contained a mapping for the key, the old value is replaced by the specified value.
        /// </summary>
        /// <param name="key">key with which the specified value is to be associated</param>
        /// <param name="value">a GSObject[] value to be associated with the specified key</param>
        public GSObject Put(string key, GSArray value)
        {
            if (key != null)
                this._map[key] = value;
            return this;
        }

        #endregion


        #region - GETS -
        /* GET BOOL */
        /// <summary>
        /// Returns the bool value to which the specified key is mapped, or the 
        /// defaultValue if this dictionary contains no mapping for the key.
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <param name="defaultValue">the bool value to be returned if this dictionary doesn't contain the specified key.</param>
        /// <returns>the bool value to which the specified key is mapped, or the defaultValue if 
        /// this dictionary contains no mapping for the key.</returns>
        public bool GetBool(string key, bool defaultValue)
        {
            bool retVal = defaultValue;
            try { retVal = this.GetTypedObject(key, defaultValue, true); }
            catch { }

            return retVal;
        }
        public bool? GetBool(string key, bool? defaultValue)
        {
            bool? retVal = defaultValue;
            try
            {
                retVal = this.GetTypedObject(key, defaultValue, true);
            }
            catch { }

            return retVal;
        }

        /// <summary>
        /// Returns the bool value to which the specified key is mapped. 
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <returns>the bool value to which the specified key is mapped.</returns>
        /// <exception cref="Gigya.Socialize.SDK.GSKeyNotFoundException">thrown if the key is not found</exception>
        /// <exception cref="System.FormatException">thrown if the value cannot be parsed as bool</exception>
        public bool GetBool(string key)
        {
            bool retVal = this.GetTypedObject(key, default(bool), false);
            return retVal;
        }


        /* GET INTEGER */
        /// <summary>
        /// Returns the int value to which the specified key is mapped, or the 
        /// defaultValue if this dictionary contains no mapping for the key.
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <param name="defaultValue">the int value to be returned if this dictionary doesn't contain the specified key.</param>
        /// <returns>the int value to which the specified key is mapped, or the defaultValue if 
        /// this dictionary contains no mapping for the key.</returns>
        public int GetInt(string key, int defaultValue)
        {
            int retVal = defaultValue;
            try { retVal = this.GetTypedObject(key, defaultValue, true); }
            catch { }

            return retVal;
        }
        public int? GetInt(string key, int? defaultValue)
        {
            int? retVal = defaultValue;
            try
            {
                retVal = this.GetTypedObject(key, defaultValue, true);
            }
            catch { }

            return retVal;
        }
        /// <summary>
        /// Returns the int value to which the specified key is mapped. 
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <returns>the int value to which the specified key is mapped.</returns>
        /// <exception cref="Gigya.Socialize.SDK.GSKeyNotFoundException">thrown if the key is not found</exception>
        /// <exception cref="System.FormatException">thrown if the value cannot be parsed as int</exception>
        public int GetInt(string key)
        {
            int retVal = this.GetTypedObject(key, default(int), false);
            return retVal;
        }


        /* GET LONG */
        /// <summary>
        /// Returns the long value to which the specified key is mapped, or the defaultValue
        /// if this dictionary contains no mapping for the key.
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <param name="defaultValue">the long value to be returned if this dictionary doesn't contain the specified key.</param>
        /// <returns>the long value to which the specified key is mapped, or the defaultValue if this 
        /// dictionary contains no mapping for the key</returns>       
        public long GetLong(string key, long defaultValue)
        {
            long retVal = defaultValue;
            try { retVal = this.GetTypedObject(key, defaultValue, true); }
            catch { }

            return retVal;
        }
        public long? GetLong(string key, long? defaultvalue)
        {
            long? retVal = defaultvalue;
            try { retVal = this.GetTypedObject(key, defaultvalue, true); }
            catch { }

            return retVal;
        }

        /// <summary>
        /// Returns the long value to which the specified key is mapped. 
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <returns>the long value to which the specified key is mapped.</returns>
        /// <exception cref="Gigya.Socialize.SDK.GSKeyNotFoundException">thrown if the key is not found</exception>
        /// <exception cref="System.FormatException">thrown if the value cannot be parsed as long</exception>
        public long GetLong(string key)
        {
            long retVal = this.GetTypedObject(key, default(long), false);
            return retVal;
        }


        /* GET DOUBLE */
        /// <summary>
        /// Returns the double value to which the specified key is mapped, or the defaultValue
        /// if this dictionary contains no mapping for the key.
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <param name="defaultValue">the double value to be returned if this dictionary doesn't contain the specified key.</param>
        /// <returns>the double value to which the specified key is mapped, or the defaultValue if this 
        /// dictionary contains no mapping for the key</returns>       
        public double GetDouble(string key, double defaultValue)
        {
            double retVal = defaultValue;
            try { retVal = this.GetTypedObject(key, defaultValue, true); }
            catch { }

            return retVal;
        }
        public double? GetDouble(string key, double? defaultValue)
        {
            double? retVal = defaultValue;
            try { retVal = this.GetTypedObject(key, defaultValue, true); }
            catch { }

            return retVal;
        }
        /// <summary>
        /// Returns the double value to which the specified key is mapped. 
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <returns>the double value to which the specified key is mapped.</returns>
        /// <exception cref="Gigya.Socialize.SDK.GSKeyNotFoundException">thrown if the key is not found</exception>
        /// <exception cref="System.FormatException">thrown if the value cannot be parsed as long</exception>
        public double GetDouble(string key)
        {
            double retVal = this.GetTypedObject(key, default(double), false);
            return retVal;
        }


        /* GET STRING */
        /// <summary>
        /// Returns the string value to which the specified key is mapped, or the defaultValue
        /// if this dictionary contains no mapping for the key.
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <param name="defaultValue">the string value to be returned if this dictionary doesn't contain the specified key.</param>
        /// <returns>the string value to which the specified key is mapped, or the defaultValue if this 
        /// dictionary contains no mapping for the key</returns>
        public string GetString(string key, string defaultValue)
        {
            string retVal = defaultValue;
            try { retVal = this.GetTypedObject(key, defaultValue, true); }
            catch { }

            return retVal;
        }
        /// <summary>
        /// Returns the string value to which the specified key is mapped. 
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <returns>the string value to which the specified key is mapped.</returns>
        /// <exception cref="Gigya.Socialize.SDK.GSKeyNotFoundException">thrown if the key is not found</exception>
        public string GetString(string key)
        {
            string retVal = this.GetTypedObject<string>(key, null, false);
            return retVal;
        }


        /* GET GSOBJECT */
        /// <summary>
        /// Returns the GSObject value to which the specified key is mapped, or the defaultValue
        /// if this dictionary contains no mapping for the key.
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <param name="defaultValue">the GSObject value to be returned if this dictionary doesn't contain the specified key.</param>
        /// <returns>the GSObject value to which the specified key is mapped, or the defaultValue if this 
        /// dictionary contains no mapping for the key</returns>
        public GSObject GetObject(string key, GSObject defaultValue)
        {
            GSObject retVal = defaultValue;
            try { retVal = this.GetTypedObject(key, defaultValue, true); }
            catch { }

            return retVal;
        }
        /// <summary>
        /// Returns the GSObject value to which the specified key is mapped. 
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <returns>the GSObject value to which the specified key is mapped.</returns>
        /// <exception cref="Gigya.Socialize.SDK.GSKeyNotFoundException">thrown if the key is not found</exception>
        /// <exception cref="System.InvalidCastException">thrown if the value cannot be cast to GSObject</exception>
        public GSObject GetObject(string key)
        {
            GSObject retVal = this.GetTypedObject<GSObject>(key, null, false);
            return retVal;
        }


        /* GET GSOBJECT[] */
        /// <summary>
        /// Returns the GSObject[] value to which the specified key is mapped, or the defaultValue
        /// if this dictionary contains no mapping for the key.
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <param name="defaultValue">the GSObject[] value to be returned if this dictionary doesn't contain the specified key.</param>
        /// <returns>the GSObject[] value to which the specified key is mapped, or the defaultValue if this 
        /// dictionary contains no mapping for the key</returns>
        public GSArray GetArray(string key, GSArray defaultValue)
        {
            GSArray retVal = defaultValue;
            try { retVal = this.GetTypedObject(key, defaultValue, true); }
            catch { }

            return retVal;
        }
        /// <summary>
        /// Returns the GSObject[] value to which the specified key is mapped. 
        /// </summary>
        /// <param name="key">the key whose associated value is to be returned</param>
        /// <returns>the GSObject[] value to which the specified key is mapped.</returns>
        /// <exception cref="Gigya.Socialize.SDK.GSKeyNotFoundException">thrown if the key is not found</exception>
        /// <exception cref="System.InvalidCastException">thrown if the value cannot be cast to GSObject[]</exception>
        public GSArray GetArray(string key)
        {
            GSArray retVal = this.GetTypedObject<GSArray>(key, null, false);
            return retVal;
        }

        #endregion


        #region Other public methods
        /// <summary>
        /// Returns true if this dictionary contains a mapping for the specified key.
        /// </summary>
        /// <param name="key">key whose presence in this map is to be tested</param>
        /// <returns>true if this map contains a mapping for the specified key</returns>
        public bool ContainsKey(string key)
        {
            return this._map.ContainsKey(key);
        }

        /// <summary>
        /// Parse parameters from URL into the dictionary
        /// </summary>
        /// <param name="url">the URL string to parse</param>
        public void ParseURL(string url)
        {
            try
            {
                Uri u = new Uri(url);

                // Parse the query string part of the uri
                this.ParseQuerystring(u.Query);

                // Parse the fragment part of the uri
                this.ParseQuerystring(u.Fragment);
            }
            catch (UriFormatException) { }
        }

        /// <summary>
        /// Parse parameters from query string
        /// </summary>
        /// <param name="qs">The query string to parse</param>
        public void ParseQuerystring(string qs)
        {
            if (qs == null) return;

            if (qs.StartsWith("?")) qs = qs.Remove(0, "?".Length); // Remove QuestionMark before query string
            if (qs.StartsWith("#")) qs = qs.Remove(0, "#".Length); // Remove Pound sign before fragment part

            string[] array = qs.Split('&');
            foreach (string parameter in array)
            {
                int indexOf = parameter.IndexOf("=");
                if (indexOf == -1) continue;
                string key = parameter.Substring(0, indexOf);
                string value = parameter.Substring(indexOf + 1);
                try
                {
                    this.Put(key, HttpUtility.UrlDecode(value, Encoding.UTF8));
                }
                catch (Exception) { }
            }
        }

        /// <summary>
        /// Removes the key (and its corresponding value) from this dictionary. 
        /// This method does nothing if the key is not in this dictionary.  
        /// </summary>
        /// <param name="key">the key that needs to be removed.</param>
        public void Remove(string key)
        {
            this._map.Remove(key);
        }

        /// <summary>
        /// Removes all of the entries from this dictionary. The dictionary will be empty after this call returns. 
        /// </summary>
        public void Clear()
        {
            this._map.Clear();
        }

        /// <summary>
        /// Returns a String array containing the keys in this dictionary. 
        /// </summary>
        /// <returns>a KeyCollection of the keys in this dictionary.</returns>
        public SortedDictionary<string, object>.KeyCollection GetKeys()
        {
            return this._map.Keys;
        }

        /// <summary>
        /// Returns the dictionary's content as a JSON string. 
        /// </summary>
        /// <returns>the dictionary's content as a JSON string.</returns>
        public override string ToString()
        {
            return this.ToJsonObject().ToString();
        }

        /// <summary>
        /// Returns the dictionary's content as a JSON string. 
        /// </summary>
        /// <returns>the dictionary's content as a JSON string.</returns>
        public string ToJsonString()
        {
            return this.ToString();
        }

        /// <summary>
        /// Returns a deep clone of the current instance
        /// </summary>
        /// <returns></returns>
        public GSObject Clone()
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formater = null;
            System.IO.MemoryStream stream = null;
            GSObject ret = null;
            try
            {
                // Serialize object
                formater = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                stream = new System.IO.MemoryStream();
                formater.Serialize(stream, this);

                // Deserialize it
                stream.Position = 0;
                ret = (GSObject)formater.Deserialize(stream);
            }
            catch (Exception)
            {
                if (stream != null)
                    stream.Close();
            }

            return ret;
        }
        #endregion

        
        #region Private Methods

        /// <summary>
        /// Associates the specified value with the specified key in this dictionary. 
        /// If the dictionary previously contained a mapping for the key, the old value is replaced by the specified value.
        /// Only for private use by this class
        /// </summary>
        /// <param name="key">key with which the specified value is to be associated</param>
        /// <param name="value">an object value to be associated with the specified key</param>      
        private void Put(string key, object value)
        {
            if (key == null) return;
            this._map[key] = value;
        }

        /// <summary>
        /// Returns the value for a given key. 
        /// If the key is not found then:
        /// If the useDefaultValue is true, then the defaultValue is return, otherwise a key not found exception is thrown.
        /// If the key is found then:
        /// If the object value can be parsed according to the type requested, it is returned after parsing.
        /// If parsing fails, then a FormatException exception is thrown
        /// </summary>
        /// <param name="key">the key to search for</param>
        /// <param name="defaultValue">value to return if key is not found</param>
        /// <param name="useDefaultValue">whether or not to use the defaultValue if key is not found</param>
        /// <returns></returns>                
        private T GetTypedObject<T>(string key, T defaultValue, bool useDefaultValue)
        {
            object val;
            // Search for the key
            if (this._map.TryGetValue(key, out val) /* key was found */)
            {
                if (val == null) return (T)val;

                Type t = typeof(T);
                if (t == typeof(string))
                    val = val.ToString();
                else if (val.GetType() == typeof(string))
                {
                    string st = val as string;
                    if (t == typeof(int))
                        val = int.Parse(st);
                    else if (t == typeof(long))
                        val = long.Parse(st);
                    else if (t == typeof(bool))
                        val = bool.Parse(st);
                    else if (t == typeof(double))
                        val = double.Parse(st);
                    else if (t == typeof(decimal))
                        val = decimal.Parse(st);
                }

                return (T)val;
            }
            else /* key couldn't be found */
            {
                if (useDefaultValue)
                    return defaultValue;
                else
                    throw new GSKeyNotFoundException("GSObject does not contain a value for key " + key);
            }
        }

        internal JSONObject ToJsonObject()
        {
            JSONObject ret = new JSONObject();
            foreach (var obj in this._map)
            {
                string key = obj.Key;
                object val = obj.Value;
                if (val is GSObject)
                {
                    ret[key] = ((GSObject)val).ToJsonObject();
                }
                else if (val is GSArray)
                {
                    ret[key] = ((GSArray)val).ToJsonArray();
                }
                else
                {
                    ret[key] = val;
                }
            }
            return ret;
        }

        protected SortedDictionary<string, object> Map { get { return _map.ToSortedDictionary(); } }


        internal IEnumerable<T> Get<T>(string[] path, int pos, bool attempt_conversion) {
            object value;
            if (_map.TryGetValue(path[pos], out value))
                return Get<T>(path, pos, value, attempt_conversion);
            else return Enumerable.Empty<T>();
        }


        static internal IEnumerable<T> Get<T>(string[] path, int pos, object value, bool attempt_conversion) {
            // End of the path -- return a value
            if (pos == path.Length - 1) {

                // value matches the requested type; return it. Note that nullables are also matched, i.e. int == int?
                if (value is T)
                    yield return (T)value;

                // if the value is null and the requested data type is a non-value, return null
                else if (value == null && default(T) == null)
                    yield return default(T);

                // if the type requested is a string and conversions are allowed, then serialize the value
                else if (attempt_conversion && typeof(T) == typeof(string))
                    yield return (T)(object)value.ToString();

                // if both the value and requested type are primitives (or nullable primitives) and conversions are allowed, try a conversion
                else if (attempt_conversion && value is IConvertible) {
                    Type base_type = Nullable.GetUnderlyingType(typeof(T));

                    if ((base_type ?? typeof(T)).GetInterfaces().Contains(typeof(IConvertible))) {
                        object converted = null;
                        try { converted = Convert.ChangeType(value, base_type ?? typeof(T)); }
                        catch {}
                        if (converted != null)
                            yield return (T)converted;
                    }
                }

            }

            // More elements in the path and the current element is an object; pass the rest of the path to that object
            else if (value is GSObject)
                foreach (var result in ((GSObject)value).Get<T>(path, pos + 1, attempt_conversion))
                    yield return result;

            // More elements in the path and the current element is an array; pass the rest of the path to that array
            else if (value is GSArray)
                foreach (var result in ((GSArray)value).Get<T>(path, pos + 1, attempt_conversion))
                    yield return result;
        }

        #endregion
    }


    [Serializable]
    internal class JSONObject : SortedDictionary<string, object>
    {
        public JSONObject() { }

        public JSONObject(StringComparer comparer) : base(comparer) { }

        public JSONObject(string json) : this(Deserialize(json)) { }

        public JSONObject(Dictionary<string, object> jsonObj)
        {
            if (jsonObj != null)
            {
                foreach (var obj in jsonObj)
                {
                    if (obj.Value is Dictionary<string, object>)
                    {
                        this[obj.Key] = new JSONObject((Dictionary<string, object>)obj.Value);
                    }
                    else if (obj.Value is object[])
                    {
                        this[obj.Key] = new JSONArray((object[])obj.Value);
                    }
                    else
                        this[obj.Key] = obj.Value;
                }
            }
        }

        static Dictionary<string, object> Deserialize(string json) {
            JavaScriptSerializer ds = new JavaScriptSerializer();
            ds.MaxJsonLength = 50 * 1024 * 1024;
            return (Dictionary<string, object>)ds.DeserializeObject(json);
        }

        internal SortedDictionary<string, object> ToSortedDictionary()
        {
            SortedDictionary<string, object> ret = new SortedDictionary<string, object>();
            foreach (var obj in this)
            {
                string key = obj.Key;
                object val = obj.Value;
                if (val is JSONObject)
                {
                    ret[key] = ((JSONObject)val).ToSortedDictionary();
                }
                else if (val is JSONArray)
                {
                    ret[key] = ((JSONArray)val).ToObjectArray();
                }
                else
                {
                    ret[key] = val;
                }
            }
            return ret;
        }

        public override string ToString()
        {
            SortedDictionary<string, object> obj = this.ToSortedDictionary();
            string ret = new JavaScriptSerializer().Serialize(obj);
            return ret;
        }
    }
}