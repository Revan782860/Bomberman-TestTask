using HeroCommands;
using UnityEngine;

namespace WinLVL
{
    public class WinLvlScript : MonoBehaviour
    {
        private void OnTriggerEnter(Collider playerCollider)
        {
            if (playerCollider.gameObject.CompareTag("Player"))
            {
                Destroy(playerCollider.gameObject);
                InputHandler.PlayerAlive = false;
                Debug.Log("Вы выиграли!");
            }
        }
    }
}
