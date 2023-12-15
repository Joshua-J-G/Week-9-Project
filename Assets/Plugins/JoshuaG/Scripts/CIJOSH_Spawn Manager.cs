using System.Collections;
using System.Collections.Generic;

using UnityEngine;

using System;
using System.Linq;
#if UNITY_EDITOR
using UnityEditor.IMGUI.Controls;
using UnityEditor.UIElements;
using UnityEngine.UIElements;
using UnityEditor.PackageManager.UI;
using UnityEditor;
#endif
[Serializable]
public struct Prefabs
{
    public ISpawnable SpawnPrefab;
    public int SpawnWeight;
    public Texture2D image;
}


#if UNITY_EDITOR
[CustomEditor(typeof(JOSH_SpanwerManager))]
public class CIJOSH_SpawnManager : Editor
{


    #region Image
    string b64 = "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";
    byte[] image;
    Texture2D tex;
    #endregion
    private JOSH_SpanwerManager SM;

    private void OnEnable()
    {
        SM = target as JOSH_SpanwerManager;
        image = System.Convert.FromBase64String(b64);
        tex = new Texture2D(100, 100);
        tex.LoadImage(image);
        tex.Apply();

    }



    public override void OnInspectorGUI()
    {
        // base.OnInspectorGUI();
        SelectSpawnType();
        serializedObject.ApplyModifiedProperties();

    }
    GUIStyle style;
    private void SelectSpawnType()
    {
        style = new GUIStyle(GUI.skin.label) { alignment = TextAnchor.MiddleCenter };
        EditorGUILayout.LabelField("Spawner Manager Prefab",style);
        SM.spawnType = (SpawnType)EditorGUILayout.Popup((int)SM.spawnType, new string[] { "SpawnPoints", "RandomSpawn" });

        switch(SM.spawnType)
        {
            case SpawnType.SpawnPoints:
               // EditorGUILayout.LabelField("SpawnPoints");
                SpawnPoints();
                break;
            case SpawnType.RandomSpawn:

                RandomPoints();
                break;
        }
    }


    private void Enemiesthatcanspawn()
    {
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.LabelField("Enemy Prefabs Spawn", style);

        SM.maxAmountofEnimiesatonetime = EditorGUILayout.Toggle("Limit the Amount of Enimes Spawning",SM.maxAmountofEnimiesatonetime);
        if(SM.maxAmountofEnimiesatonetime)
        {
            SM.Amount = EditorGUILayout.IntField("How Many", SM.Amount);
        }


        EditorGUILayout.PropertyField(serializedObject.FindProperty("SpawnableEnemies"), new GUIContent("All Spawnable Enemies"), true);
        
        foreach (ISpawnable s in SM.SpawnableEnemies)
        {
            if (s != null)
            {


                GUILayout.BeginHorizontal();
                {
                    EditorGUILayout.LabelField(s.Name, style);
                    s.spawnWeight =  EditorGUILayout.IntField(s.spawnWeight);
                    s.completlydisable = EditorGUILayout.Toggle(s.completlydisable);
                   
                        Debug.Log(SM.SpawnableEnemies.Count);
                    // for (int i = 1; i <= SM.SpawnableEnemies.Count; i++)
                    // {
                    //  Debug.Log(i);
                    // if (s.EnemyFaceTexture != null)
                    // {
                    //    EditorGUI.DrawPreviewTexture(new Rect(60, 185 + 50 * i + SM.SpawnableEnemies.Count*5, 40, 40), s.EnemyFaceTexture);
                    // }
                    // else
                    // { 215
                    int i = 0;
                    foreach (ISpawnable s2 in SM.SpawnableEnemies)
                    {
                        if(s2.EnemyFaceTexture != null)
                        {
                            EditorGUI.DrawPreviewTexture(new Rect(60, (215 + (SM.SpawnableEnemies.Count - 1) * 20) + i * 46, 40, 40), s2.EnemyFaceTexture);

                        }else
                        {
                            EditorGUI.DrawPreviewTexture(new Rect(60, (215 + (SM.SpawnableEnemies.Count - 1) * 20) + i * 46, 40, 40), tex);
                        }
                        
                        i++;
                    }
                            
                          //  }
                        //}

                
                   
                   
                }
                GUILayout.EndHorizontal();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
                EditorGUILayout.Space();
            }
           
            }

        }


    private void SpawnPoints()
    {
        EditorGUILayout.PropertyField(serializedObject.FindProperty("SPinList"), new GUIContent("SpawnPoints"), true);
        SM.SPinList.RemoveAll(x => x == null);
        if (GUILayout.Button("Create New Spawnpoint"))
        {
            GameObject tmp = Instantiate(SM.SpawnPoints);
            tmp.transform.parent = SM.gameObject.transform;
            tmp.name = tmp.name + SM.SPinList.Count;
           
            SM.SPinList.Add(tmp.GetComponent<JOSH_Spawnpoint>());
            

        }
        Enemiesthatcanspawn();





    }

    private void RandomPoints()
    {
        SM.SpawnArea = EditorGUILayout.Vector3Field("Spawn Area", SM.SpawnArea);
        SM.DeadZone = EditorGUILayout.Vector3Field("Deadzone", SM.DeadZone);
        Enemiesthatcanspawn();

    }



    

}

#endif
