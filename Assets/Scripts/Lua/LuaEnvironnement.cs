using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using NLua;

public class LuaEnvironnement
{
    static private string intializeContextScript;
    Lua env;

    static public LuaEnvironnement CreateEnvironement()
    {
        LuaEnvironnement env = new LuaEnvironnement();
        return env;
    }

    LuaEnvironnement()
    {
        env = new Lua();
        env.LoadCLRPackage();
        env["this"] = this;
    }

    public void doString(string iaScript, string name = "chunk")
    {
        try
        {
            env.DoString(iaScript, name);
        }
        catch (NLua.Exceptions.LuaException e)
        {
            Debug.LogError(FormatException(e));
        }
    }

    public System.Object[] call(string function, params System.Object[] args)
    {
        System.Object[] result = new System.Object[0];
        if (env == null) return result;
        LuaFunction lf = env.GetFunction(function);
        if (lf == null) return result;
        try
        {
            // Note: calling a function that does not
            // exist does not throw an exception.
            if (args != null)
            {
                result = lf.Call(args);
            }
            else
            {
                result = lf.Call();
            }
        }
        catch (NLua.Exceptions.LuaException e)
        {
            Debug.LogError(FormatException(e));
        }
        return result;
    }

    public System.Object[] call(string function)
    {
        return call(function, null);
    }

    public static string FormatException(NLua.Exceptions.LuaException e)
    {
        string source = (string.IsNullOrEmpty(e.Source)) ? "<no source>" : e.Source.Substring(0, e.Source.Length - 2);
        return string.Format("{0}\nLua (at {2})", e.Message, string.Empty, source);
    }
}
