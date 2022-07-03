using System;
using UnityEngine;

namespace HeroCommands
{
    public class ThrewBombCommand : Command
    {
        private GameObject _bomb;
        public static bool BombOnTheSceneReady = true;
        private Vector3 _bombPosition;

        private void Start()
        {
            _bomb = GetComponent<InputHandler>().bomb;
        }

        public override void Execute(Transform player)
        {
            if(BombOnTheSceneReady) InstantiateBomb(player);
        }

        private void InstantiateBomb(Transform playerTransform)
        {
            var positionPlayer = playerTransform.position;
            BombOnTheSceneReady = false;
            _bombPosition = positionPlayer;
            _bombPosition = new Vector3(MathF.Ceiling(positionPlayer.x)- 0.5f,0.5f,MathF.Ceiling(positionPlayer.z)- 0.5f);
            _bomb.transform.position = _bombPosition;
            Instantiate(_bomb);  
        }
    }
}
