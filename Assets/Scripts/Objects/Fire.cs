using UnityEngine;

namespace TowerDungeon.Objects
{
    public class Fire : MonoBehaviour
    {
        private Rigidbody2D fireRb;
        float speed = 5;
        Vector2 direction;

        void Start()
        {
            fireRb = GetComponent<Rigidbody2D>();
        }

        void Update()
        {
            fireRb.velocity = direction * speed;
        }

        public void VerifyFirePosition(Vector2 _direction)
        {
            direction = _direction;
        }
    }
}
