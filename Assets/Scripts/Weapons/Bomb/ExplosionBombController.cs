using System;
using HeroCommands;
using UnityEngine;
using Quaternion = UnityEngine.Quaternion;
using Vector3 = UnityEngine.Vector3;

namespace Weapons.Bomb
{
    public class ExplosionBombController : Weapon
    {

        [SerializeField] private GameObject fire;
        [SerializeField] private double maxTimer;
        private double _currentTimer;
        private Vector3 _bombPosition;
        [SerializeField] private TestRayCast testRayCast;

        public bool fireInUp;
        public bool fireInDown;
        public bool fireInLeft;
        public bool fireInRight;
        
        private void Start()
        {
            _bombPosition = gameObject.transform.position;
        }

        private void TimerBeforeExplosion()
        {
            _currentTimer += Time.deltaTime;
            
            if (_currentTimer >= maxTimer)
            {
                Explosion(rangeOfWeapon);
                _currentTimer = 0.0d;
                Destroy(gameObject);
                ThrewBombCommand.BombOnTheSceneReady = true;
            }
        }
        

        private void Explosion(int maxFires)
        {
            _bombPosition = new Vector3(MathF.Ceiling(_bombPosition.x)- 0.5f,0.5f,MathF.Ceiling(_bombPosition.z)- 0.5f);
            
            Instantiate(fire.gameObject, _bombPosition, Quaternion.identity);
            for (int i = 1; i <= maxFires; i++)
            {
                FireInstantiateUp(i);
                FireInstantiateDown(i);
                FireInstantiateRight(i);
                FireInstantiateLeft(i);
            }

            fireInUp = false;
            fireInDown = false;
            fireInLeft = false;
            fireInRight = false;
        }


        private void FireInstantiateUp(float countFires)
        {
            testRayCast.CheckHardObjectInUp(countFires);
            if(fireInUp == false) Instantiate(fire.gameObject, _bombPosition + new Vector3(countFires, 0, 0), Quaternion.identity);
        }

        private void FireInstantiateDown(float countFires)
        {
            testRayCast.CheckHardObjectInDown(countFires);
            if(fireInDown == false) Instantiate(fire.gameObject, _bombPosition + new Vector3(-countFires, 0, 0), Quaternion.identity);
        }

        private void FireInstantiateRight(float countFires)
        {
            testRayCast.CheckHardObjectInRight(countFires);
            if(fireInRight == false) Instantiate(fire.gameObject, _bombPosition + new Vector3(0, 0,countFires), Quaternion.identity);
        }

        private void FireInstantiateLeft(float countFires)
        {
            testRayCast.CheckHardObjectInLeft(countFires);
            if(fireInLeft == false) Instantiate(fire.gameObject, _bombPosition + new Vector3(0, 0,-countFires), Quaternion.identity);    
        }

        private void Update()
        {
            TimerBeforeExplosion();
        }
    }
}