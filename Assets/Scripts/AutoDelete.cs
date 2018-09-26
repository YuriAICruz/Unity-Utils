using UnityEngine;

namespace Graphene.Utils
{
    public class AutoDelete : MonoBehaviour
    {
        public float Timeout;

        void Start()
        {
            Invoke(nameof(DestroySelf), Timeout);
        }

        void DestroySelf()
        {
            Destroy(this.gameObject);
        }
    }
}