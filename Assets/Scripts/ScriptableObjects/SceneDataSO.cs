using UnityEngine;

namespace TowerDungeon
{
    [CreateAssetMenu(fileName = "Scene", menuName = "Tower Dungeon/Scene Data", order = 1)]
    public class SceneDataSO : ScriptableObject
    {
        [SerializeField]
        private string sceneName;

        public string SceneName { get {return sceneName; } }

#if UNITY_EDITOR
        [SerializeField]
        private Object Scene;

        public void OnValidate()
        {
            if (Scene != null)
            {
                sceneName = Scene.name;
                //Debug.Log(sceneName);
            }
        }
#endif
    }
}