using UnityEngine;

namespace Utils
{
    public class GlobalCoroutineManager : MonoBehaviour
    {
        private static GlobalCoroutineManager _instance;

        public static GlobalCoroutineManager Instance
        {
            get
            {
                if (_instance != null) return _instance;
                var tmp = new GameObject("GlobalCoroutineManager", typeof(GlobalCoroutineManager));
                return tmp.GetComponent<GlobalCoroutineManager>();
            }
        }


        private void Awake()
        {
            if (_instance == null)
            {
                _instance = this;
            }
            else
            {
                Destroy(this);
                return;
            }

            SceneManagement.SceneManager.AssignManager(this.gameObject);
        }
    }
}