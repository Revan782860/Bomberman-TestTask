using HeroCommands;
using UnityEngine;

namespace Enemy
{
    public class SpawnEnemy : MonoBehaviour
    {
        [SerializeField] private GameObject enemy;
        [SerializeField] private float cooldown;
        private float _timer;
        private void Start()
        {
            enemy.transform.position = transform.position;
        }

        private void Spawn()
        {
            Instantiate(enemy);
        }

        private void CooldownToNextSpawn(float cooldownSpawn)
        {
            _timer += Time.deltaTime;
            if (_timer >= cooldownSpawn)
            {
                Spawn();
                _timer = 0;
            }
        }

        private void FixedUpdate()
        {
            if (InputHandler.PlayerAlive) CooldownToNextSpawn(cooldown);
        }
    }
}
