using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;

public class GUI_Leave : MonoBehaviour
{
    // Start is called before the first frame update
    void OnGUI()
    {

        if (GUILayout.Button("Leave"))
        {
            Application.Quit();
        }
    }
}