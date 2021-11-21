using UnityEngine;

namespace Game
{
    public class ZombieController : MonoBehaviour
    {
        public ZombieInput ZombieInput;

        public Rigidbody Rigidbody;
        
        [Header("Gameplay")] 
        public float Speed = 5f;
        
        private void Update()
        {
            if (ZombieInput == null)
                return;

            var (moveDirection, viewDirection, shoot) = ZombieInput.CurrentInput();
            Rigidbody.velocity = moveDirection.normalized * Speed;
            transform.rotation = viewDirection;
        }
    }
}