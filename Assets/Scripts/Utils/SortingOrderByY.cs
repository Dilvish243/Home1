using UnityEngine;

namespace Utils
{
    [ExecuteInEditMode]
    public class SortingOrderByY : MonoBehaviour
    {
        [SerializeField]
        public SpriteRenderer _spriteRenderer;


        private void Update()
        {
            var sortingOrder = -(int)(transform.position.y * 10);

            _spriteRenderer.sortingOrder = sortingOrder;
        }
    }
}