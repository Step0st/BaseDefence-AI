using System;
using System.Linq;
using UnityEngine;

namespace Game
{
    public class BaseDefence : MonoBehaviour
    {
        public bool _gameOver;
        
        private void OnCollisionEnter(Collision collision)
        {
            var attacker = collision.gameObject.GetComponentInParent<ZombieComponent>();
            if(attacker != null)
            {
                if (attacker.IsAlive == true)
                {
                    _gameOver = true;
                }
            }
        }
    }
}