using System.Collections.Generic;
using UnityEngine;

public class Actions : MonoBehaviour
{

    public ActionMap[] actions;

    void Start()
    {
        InputHandler.AddActions(actions);

        //Comment this Destroy out if you want to edit it midgame I guess?.
        Destroy(this);
    }
}
