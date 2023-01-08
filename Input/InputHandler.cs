using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
public static class InputHandler
{

    private static Dictionary<string, List<string>> inputList = new Dictionary<string, List<string>>();
    private static Dictionary<string, List<UnityEngine.KeyCode>> keycodeList = new Dictionary<string, List<UnityEngine.KeyCode>>();

    ///<summary>
    /// Returns true if any of the keys from that action were pressed.
    ///</summary>
    public static bool ActionPressed(string action, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string callFilePath = "")
    {
        string newAction = action.ToLower();
        try
        {
            for (int i = 0; i < inputList[newAction].Count; i++)
            {
                if (Input.GetKeyDown(inputList[newAction][i])) return true;
            }
            for (int i = 0; i < keycodeList[newAction].Count; i++)
            {
                if (Input.GetKeyDown(keycodeList[newAction][i])) return true;
            }
        }
        catch { Debug.LogWarning($" Action '{action}' does not exist and will never be pressed.\n Line {lineNumber} in file {callFilePath}"); }
        return false;
    }

    private static void AddToAction(string action, string input)
    {
        if (!inputList.TryGetValue(action, out _)) { inputList.Add(action, new List<string>()); keycodeList.Add(action, new List<UnityEngine.KeyCode>()); }
        inputList[action].Add(input);
    }

    private static void AddToAction(string action, KeyCode[] inputs)
    {
        if (!keycodeList.TryGetValue(action, out _)) { inputList.Add(action, new List<string>()); keycodeList.Add(action, new List<UnityEngine.KeyCode>()); }
        foreach (var input in inputs)
        {
            keycodeList[action].Add(input);
        }
    }

    public static void AddActions(ActionMap[] maps)
    {
        foreach (var item in maps)
        {
            AddToAction(item.action, item.keycode);
        }
    }
}


[System.Serializable]
public struct ActionMap
{
    public string action;
    public KeyCode[] keycode;

    public ActionMap(string ac, KeyCode[] key)
    {
        action = ac;
        keycode = key;
    }
}


