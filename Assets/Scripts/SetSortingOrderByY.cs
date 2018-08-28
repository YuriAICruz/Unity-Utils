using UnityEngine;

namespace Utils
{
	[RequireComponent(typeof(SpriteRenderer))]
	public class SetSortingOrderByY : MonoBehaviour
	{
		private SpriteRenderer _sprite;

		private void Awake()
		{
			_sprite = GetComponent<SpriteRenderer>();
		}

		void Update ()
		{
			_sprite.sortingOrder = (int)-transform.position.y;
		}
	}
}
