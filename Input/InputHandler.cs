using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class InputHandler
{
    //Store a dictionary where the key is the action name and we have a list of key names
    //private static Dictionary<string, List<string>> inputList = new Dictionary<string, List<string>>();

    //Store another dictionary where the key is the action name and we have a list of key codes
    private static Dictionary<string, List<UnityEngine.KeyCode>> keycodeList = new Dictionary<string, List<UnityEngine.KeyCode>>();

    /// <summary>
    /// Takes the name of the action as a string, returns true if it's being pressed. Not case sensitive.
    /// </summary>
    public static bool ActionPressed(string action, [CallerLineNumber] int lineNumber = 0, [CallerFilePath] string callFilePath = "")
    {
        //Its not case sensitive (maybe it should be?)
        string newAction = action.ToLower();
        try
        {
            for (int i = 0; i < keycodeList[newAction].Count; i++) 
            {
                //Check the list in our dictionary under this action and see if any of those keys are being pressed
                if (Input.GetKeyDown(keycodeList[newAction][i])) { return true; }
            }
        }
        catch { Debug.LogWarning($" Action '{action}' does not exist and will never be pressed.\n Line {lineNumber} in file {callFilePath}"); }
        return false;
    }

    //Add the keycode to the proper action, or create a list if it doesnt exist.
    private static void AddToAction(string action, KeyCode[] inputs)
    {
        if (!keycodeList.TryGetValue(action, out _)) 
        { 
            keycodeList.Add(action, new List<UnityEngine.KeyCode>()); 
        }

        foreach (var input in inputs)
        {
            keycodeList[action].Add(input);
        }
    }
    /// <summary>
    /// Add a list of keys with a name to the input handler.
    /// </summary>
    public static void AddActions(ActionMap[] maps)
    {
        foreach (var item in maps)
        {
            string actionLowered = item.action.ToLower();
            AddToAction(actionLowered, item.keycode);
        }
    }

    //Clear the list.
    public static void ClearActions()
    {
        keycodeList.Clear();
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


