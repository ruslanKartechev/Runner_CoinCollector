using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RunnerGame
{
    public class CharachterComponents : MonoBehaviour
    {
        [Header("Scripts")]
        public CharachterMoverBase _MoveManager;
        public CharachterRotatorBase _RotationManager;
        public CharachterAnimationManager _AnimManager;
        public CharachterCollisionManager _collisionManager;

        [Header("Components")]
        public Animator CharacterAnimator;

        [Header("Settings")]
        public CharachterMovementSettings _MoverSettings;
        public CharachterAnimationSettings _AnimationSettings;
    }
}