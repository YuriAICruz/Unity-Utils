using UnityEngine;
using UnityEngine.SceneManagement;

namespace Graphene.Utils
{
    public class AutoLoadLevel : MonoBehaviour
    {
        public float Delay;
        public int Index;

        private void Awake()
        {
            Invoke(nameof(LoadScene), Delay);
        }

        void LoadScene()
        {
            SceneManager.LoadSceneAsync(Index);
        }
    }
}