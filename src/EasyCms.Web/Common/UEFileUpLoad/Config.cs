﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Web;
using EasyCms;

/// <summary>
/// Config 的摘要说明
/// </summary>
public static class Config
{
    private static bool noCache = true;
    private static JObject BuildItems()
    {
        var json = File.ReadAllText(HttpContext.Current.Server.MapPathCms("~/config.json"));
        return JObject.Parse(json);
    }

    public static JObject Items
    {
        get
        {
            
            if (noCache || _Items == null)
            {
                _Items = BuildItems();
                string virtualPath = HttpContext.Current.Request.ApplicationPath;
                if (virtualPath == "/")
                {
                    virtualPath = string.Empty;
                }
                _Items["imageUrlPrefix"] = virtualPath;
                _Items["scrawlUrlPrefix"] = virtualPath;
                _Items["snapscreenUrlPrefix"] = virtualPath;
                _Items["catcherUrlPrefix"] = virtualPath;
                _Items["videoUrlPrefix"] = virtualPath;
                _Items["fileUrlPrefix"] = virtualPath;
                _Items["imageManagerUrlPrefix"] = virtualPath;
                _Items["fileManagerUrlPrefix"] = virtualPath; 
            }
            return _Items;
        }
    }
    private static JObject _Items;


    public static T GetValue<T>(string key)
    {
        return Items[key].Value<T>();
    }

    public static String[] GetStringList(string key)
    {
        return Items[key].Select(x => x.Value<String>()).ToArray();
    }

    public static String GetString(string key)
    {
        return GetValue<String>(key);
    }

    public static int GetInt(string key)
    {
        return GetValue<int>(key);
    }
}