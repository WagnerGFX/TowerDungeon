using UnityEditor;

namespace TowerDungeon
{
    [CustomEditor(typeof(SceneDataSO))]
    public class SceneDataSOEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            DrawDefaultInspector();

            SceneDataSO myScript = (SceneDataSO)target;

            if (EditorGUILayout.LinkButton("Update Scene Name"))
            {
                myScript.OnValidate();
            }
        }
    }
}
