using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CharachterCollisionManager : MonoBehaviour
    {
        private CharachterController _controller;
        public void Init(CharachterController controller)
        {
            _controller = controller;
        }
        private void OnTriggerEnter(Collider other)
        {
            switch (other.tag)
            {
                case Tags.Coin:
                    ICollectable collectable = other.GetComponent<ICollectable>();
                    _controller.HandleCollision(CollisionMessages.Coin, collectable);
                    break;
                case Tags.Finish:
                    ICheckPoint c = other.GetComponent<ICheckPoint>();
                    _controller.HandleCollision(CollisionMessages.Finish , c);
                    break;

            }
        }
    }
}