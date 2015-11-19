using System;
using LuaInterface;

public class DebuggerWrap
{
	public static void Register(IntPtr L)
	{
		LuaMethod[] regs = new LuaMethod[]
		{
			new LuaMethod("Log", Log),
			new LuaMethod("LogWarning", LogWarning),
			new LuaMethod("LogError", LogError),
			new LuaMethod("New", _CreateDebugger),
			new LuaMethod("GetClassType", GetClassType),
		};

		LuaField[] fields = new LuaField[]
		{
			new LuaField("IsDebug", get_IsDebug, set_IsDebug),
		};

		LuaScriptMgr.RegisterLib(L, "Debugger", typeof(Debugger), regs, fields, null);
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int _CreateDebugger(IntPtr L)
	{
		LuaDLL.luaL_error(L, "Debugger class does not have a constructor function");
		return 0;
	}

	static Type classType = typeof(Debugger);

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int GetClassType(IntPtr L)
	{
		LuaScriptMgr.Push(L, classType);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int get_IsDebug(IntPtr L)
	{
		LuaScriptMgr.Push(L, Debugger.IsDebug);
		return 1;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int set_IsDebug(IntPtr L)
	{
		Debugger.IsDebug = LuaScriptMgr.GetBoolean(L, 3);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int Log(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
		Debugger.Log(arg0,objs1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogWarning(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
		Debugger.LogWarning(arg0,objs1);
		return 0;
	}

	[MonoPInvokeCallbackAttribute(typeof(LuaCSFunction))]
	static int LogError(IntPtr L)
	{
		int count = LuaDLL.lua_gettop(L);
		string arg0 = LuaScriptMgr.GetLuaString(L, 1);
		object[] objs1 = LuaScriptMgr.GetParamsObject(L, 2, count - 1);
		Debugger.LogError(arg0,objs1);
		return 0;
	}
}

