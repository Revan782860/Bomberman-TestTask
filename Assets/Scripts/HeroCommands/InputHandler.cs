using UnityEngine;

namespace HeroCommands
{
    public class InputHandler : MonoBehaviour
    {
        public Transform playerTransform;
        public static bool PlayerAlive = true;
        
        private Command _buttonW;
        private Command _buttonS;
        private Command _buttonA;
        private Command _buttonD;
        private Command _buttonSpace;
        
        public float playerSpeed;

        public GameObject bomb;
        
        
        void Awake()
        {
            _buttonW = gameObject.AddComponent<MovementUpCommand>();
            _buttonA = gameObject.AddComponent<MovementLeftCommand>();
            _buttonS = gameObject.AddComponent<MovementDownCommand>();
            _buttonD = gameObject.AddComponent<MovementRightCommand>();
            _buttonSpace = gameObject.AddComponent<ThrewBombCommand>();
            
            Command.MoveSpeed = playerSpeed;
        }
        
        private void HandleInput()
        {
            if (Input.GetKey(KeyCode.D))
            {
                _buttonD.Execute(playerTransform);
            }
            else if (Input.GetKey(KeyCode.W))
            {
                _buttonW.Execute(playerTransform);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                _buttonS.Execute(playerTransform);
            }
            else if (Input.GetKey(KeyCode.A))
            {
                _buttonA.Execute(playerTransform);
            }
            else if (Input.GetKey(KeyCode.Space))
            {
                _buttonSpace.Execute(playerTransform);
            }
        }
        
        private void FixedUpdate()
        {
            HandleInput();
        } 
    }  
}