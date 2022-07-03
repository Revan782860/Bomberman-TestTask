using HeroCommands;
using UnityEngine;

namespace Weapons.Bomb
{
    public class FireControl : MonoBehaviour
    {
        [SerializeField] private double cooldownMaxTimer;
        private double _cooldownTimer;
    
        private void CooldownToDestroyFires(double timer)
        {
            _cooldownTimer += Time.deltaTime;
            if (_cooldownTimer >= timer)
            {
                _cooldownTimer = 0.0d;
                Destroy(gameObject);
            }
        }


        private void OnTriggerEnter(Collider gameObjectCollider)
        {
            if (gameObjectCollider.gameObject.CompareTag("Player"))
            {
                Destroy(gameObjectCollider.gameObject);
                InputHandler.PlayerAlive = false;
            }   
            else if (gameObjectCollider.gameObject.CompareTag("Enemy"))
            {
                Destroy(gameObjectCollider.gameObject);
            }
            else if (gameObjectCollider.gameObject.CompareTag("HardObject"))
            {
                Destroy(gameObject);
            }
        }
    
        private void FixedUpdate()
        {
            CooldownToDestroyFires(cooldownMaxTimer);
        }
    }
}
