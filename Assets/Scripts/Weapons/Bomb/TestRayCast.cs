using UnityEngine;

namespace Weapons.Bomb
{
    public class TestRayCast : MonoBehaviour
    {
        [SerializeField] private ExplosionBombController checkStone;
        private RaycastHit _hitUp;
        private RaycastHit _hitDown;
        private RaycastHit _hitLeft;
        private RaycastHit _hitRight;
        public void CheckHardObjectInUp(float countFires)
        {
            Ray ray = new Ray(transform.position, Vector3.right);

            if (Physics.Raycast(ray, out _hitUp, countFires)) 
            {
                if (_hitUp.collider.CompareTag("HardObject"))
                {
                    checkStone.fireInUp = true;
                }
            }
        }
    
        public void CheckHardObjectInDown(float countFires)
        {
            Ray ray = new Ray(transform.position, -Vector3.right);

            if (Physics.Raycast(ray, out _hitDown, countFires))
            {
                if (_hitDown.collider.CompareTag("HardObject"))
                {
                    checkStone.fireInDown = true;
                }
            }
        }
    
        public void CheckHardObjectInLeft(float countFires)
        {
            Ray ray = new Ray(transform.position, -Vector3.forward);

            if (Physics.Raycast(ray, out _hitLeft, countFires))
            {
                if (_hitLeft.collider.CompareTag("HardObject"))
                {
                    checkStone.fireInLeft = true;
                }
            }
        }
    
        public void CheckHardObjectInRight(float countFires)
        {
            Ray ray = new Ray(transform.position, Vector3.forward);

            if (Physics.Raycast(ray, out _hitRight, countFires))
            {
                if (_hitRight.collider.CompareTag("HardObject"))
                {
                    checkStone.fireInRight = true;
                }
            }
        }
    }
}
