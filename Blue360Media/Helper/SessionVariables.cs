using Blue360Media.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace Blue360Media.Helper
{
    [Serializable()]
    public static class SessionExtensions
    {
        public static void Set(this ISession session, string key, string value)
        {
            session.SetString(key, Convert.ToString(value));
        }
        public static string Get(this ISession session, string key)
        {
            return session.GetString(key);
        }
        public static void SetObjectAsJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObjectFromJson<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class SessionVariables: Register
    {
        //public string LoggedInUserFullName
        //{
        //    get
        //    {
        //        string LoggedInUserFullName = string.Empty;

        //        if (HttpContext.Session.GetString("LoggedInUserFullName") != null)
        //        {
        //            LoggedInUserFullName = Convert.ToString(HttpContext.Session.GetString("LoggedInUserFullName"));
        //        }
        //        return LoggedInUserFullName;
        //    }
        //    set
        //    {
        //        HttpContext.Session.SetString("LoggedInUserFullName", value);
        //    }
        //}

        public bool IsSystemAdministrator { get; set; }
        public bool IsEditor { get; set; }
        public bool IsViewer { get; set; }
    }
}
