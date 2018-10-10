using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Graphene.Utils
{
	public class AutoRotate : MonoBehaviour
	{
		public float Speed;
		
		void Update()
		{
			transform.Rotate(Vector3.up, Time.deltaTime*Speed, Space.World);
		}
	}
}
