using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(GarbageSpawn))]
public class GarbageSpawnGUI : Editor
{
    float minVal = 1;
    float minLimit = 0.1f;
    float maxVal = 10;
    float maxLimit = 60;

    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        GarbageSpawn script = (GarbageSpawn)target;

        script.minSpawnInterval = minVal;
        script.maxSpawnInterval = maxVal;

        EditorGUILayout.LabelField("Minimum spawn interval:", minVal.ToString());
        EditorGUILayout.LabelField("Maximum spawn interval:", maxVal.ToString());
        EditorGUILayout.MinMaxSlider(ref minVal, ref maxVal, minLimit, maxLimit);
    }
}
