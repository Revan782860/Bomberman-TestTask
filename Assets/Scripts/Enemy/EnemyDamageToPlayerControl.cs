using HeroCommands;
using UnityEngine;

namespace Enemy
{
    public class EnemyDamageToPlayerControl : MonoBehaviour
    {
        private void OnCollisionEnter(Collision playerCollider)
        {
            if (playerCollider.gameObject.CompareTag("Player"))
            {
                Destroy(playerCollider.gameObject);
                InputHandler.PlayerAlive = false;
                Debug.Log("Вы проиграли!");
            }
        }
    }
}
