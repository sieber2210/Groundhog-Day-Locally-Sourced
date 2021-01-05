using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestHitPlayer))]
public class TestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        TestHitPlayer hitPlayer = (TestHitPlayer)target;
        if(GUILayout.Button("Test Damage Player"))
        {
            hitPlayer.TestHitToPlayer();
        }
    }
}
