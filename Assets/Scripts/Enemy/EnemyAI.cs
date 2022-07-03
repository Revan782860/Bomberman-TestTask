using HeroCommands;
using UnityEngine;

namespace Enemy
{
    public class EnemyAI : MonoBehaviour
    {
        private float _speedEnemy;
        private Transform _playerTransform;

        private void Start()
        {
            _playerTransform = GameObject.Find("Player").GetComponent<Transform>();
            _speedEnemy = Command.MoveSpeed;
        }

        private void ChasePlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, _playerTransform.position, _speedEnemy * Time.deltaTime);
        }

        private void FixedUpdate()
        {
            if (InputHandler.PlayerAlive)
            {
                ChasePlayer();
            }
        }
    }
}