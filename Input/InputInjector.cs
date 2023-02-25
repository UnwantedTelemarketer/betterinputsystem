using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEditor;

public class InputInjector : MonoBehaviour
{

    [Header("Will be deleted on start.")]
    [Header("Used to dynamically update your actions at runtime.")]
    [Tooltip("this is only there so that header can show up. i know its jank")]
    public bool nothing;

    //This just reads from the file thats created when "Update Actions" was pressed, or tells you it doesnt exist.
    private void Start()
    {
        if (File.Exists(Application.persistentDataPath
                       + "/savedActions"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file =
                       File.Open(Application.persistentDataPath
                       + "/savedActions", FileMode.Open);

            ActionMap[] actions;
            try { actions = (ActionMap[])bf.Deserialize(file); }
            catch { Debug.LogError("Unable to find any saved actions."); return; }

            InputHandler.AddActions(actions);
            Debug.Log("Loaded saved actions");
        }
        else
        {
            Debug.LogError("Unable to find any saved actions.");
        }

        Destroy(gameObject);
    }
}