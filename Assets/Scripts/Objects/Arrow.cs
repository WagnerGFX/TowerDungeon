using UnityEngine;

namespace TowerDungeon.Objects
{
    public class Arrow : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5;

        private Rigidbody2D arrowRb;
        private Vector2 direction;

        void Start()
        {
            arrowRb = GetComponent<Rigidbody2D>();
        }

        void FixedUpdate()
        {
            arrowRb.velocity = direction * speed;
        }

        public void VerifyArrowPosition(Vector2 _direction)
        {
            direction = _direction;
        }
    }
}