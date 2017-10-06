using UnityEngine;
using System.Collections;
using UnityEditor;

//Implemented by Andon
//Programatically create tabs. Work in progress. Does not do anything at the moment.
//Obtained from https://xinyustudio.wordpress.com/2014/12/27/unity3d-how-to-implement-tabbed-ui/https://xinyustudio.wordpress.com/2014/12/27/unity3d-how-to-implement-tabbed-ui/
public class InventoryJournalSwitcher : MonoBehaviour {

    private int iTabSelected = 0;
    public void OnGUI()
    {
        GUILayout.BeginVertical();
        {
            GUILayout.BeginHorizontal();
            {
                if (GUILayout.Toggle(iTabSelected == 0, "Tab1", EditorStyles.toolbarButton))
                    iTabSelected = 0;

                if (GUILayout.Toggle(iTabSelected == 1, "Tab2", EditorStyles.toolbarButton))
                    iTabSelected = 1;
            }
            GUILayout.EndHorizontal();
            //Draw different UI according to iTabSelected
            DoGUI(iTabSelected);
        }
        GUILayout.EndVertical();
    }

    private void DoGUI(int iTabSelected)
    {
        if (iTabSelected == 0)
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            {
                GUILayout.Button("Tab1.Button1");
                GUILayout.Button("Tab1.Button2");
            }
            GUILayout.EndVertical();
        }

        if (iTabSelected == 1)
        {
            GUILayout.Space(10);
            GUILayout.BeginVertical();
            {
                GUILayout.Label("Tab2.Label1");
                GUILayout.Label("Tab2.Label2");
            }
            GUILayout.EndVertical();
        }
    }
}
