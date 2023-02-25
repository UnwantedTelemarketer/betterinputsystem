using System;
using UnityEngine;
using UnityEditor;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class Actions : EditorWindow
{

    public ActionMap[] actions;

    [MenuItem("Input Handler/Action Editor")]
    public static void ShowWindow()
    {
        GetWindow<Actions>("Action Editor");
    }

    void OnGUI()
    {
        ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);
        SerializedProperty actionsList = so.FindProperty("actions");

        EditorGUILayout.PropertyField(actionsList, true);
        so.ApplyModifiedProperties();

        if(GUILayout.Button("Update Actions"))
        {
            UpdateActions();
        }
    }

    void UpdateActions()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath
                     + "/savedActions");
        bf.Serialize(file, actions);
        file.Close();

        GameObject prevObj = GameObject.Find("InputInjector");

        if (prevObj != null) { return; }

        GameObject inj = new GameObject();
        inj.AddComponent<InputInjector>();
        inj.name = "InputInjector";
    }
}
