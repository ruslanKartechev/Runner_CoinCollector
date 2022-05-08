using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace RunnerGame
{
#if UNITY_EDITOR
    [CustomEditor(typeof(CameraCinemachineFollower))]
    public class CameraCinemachineFollowerEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            CameraCinemachineFollower me = target as CameraCinemachineFollower;
            GUILayout.BeginHorizontal();
            if (GUILayout.Button("StartPos")) { me.SetStartOffset(); }
            if (GUILayout.Button("MainPos")) { me.SetMainOffset(); }
            if (GUILayout.Button("EndPos")) { me.SetFinishOffset(); }
            GUILayout.EndHorizontal();
        }
    }
#endif
}