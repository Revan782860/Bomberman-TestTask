using UnityEngine;

namespace Game_Over
{
    public class GameOverScript : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        private void OnCollisionEnter(Collision other)
        {
            if (other.gameObject == enemy.gameObject)
            {
                Destroy(gameObject);
                Debug.Log("Вы проиграли!");
            }
        }
    }
}
