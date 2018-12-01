using UnityEngine;

namespace Graphene.Utils
{
    public class BillboardCamera : MonoBehaviour
    {
        private Transform _camera;

        private void Start()
        {
            _camera = Camera.main.transform;
        }

        private void Update()
        {
            transform.LookAt(_camera, Vector3.up);
        }
    }
}