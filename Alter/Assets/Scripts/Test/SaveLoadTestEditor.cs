using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SaveLoadTester))]
public class ObjectBuilderEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SaveLoadTester myScript = (SaveLoadTester)target;
        if (GUILayout.Button("Save"))
        {
            myScript.Save();
        }

        if (GUILayout.Button("Load"))
        {
            myScript.Load();
        }
    }
}