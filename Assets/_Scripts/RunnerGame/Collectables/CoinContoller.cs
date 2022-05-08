using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace RunnerGame
{
    public class CoinContoller : MonoBehaviour
    {
        public CoinCollisionManager _collisions;
        public CoinParticlesBase _particles;
        public CoinAnimatorBase _animator;
        public ViewManagerBase _coinView;
        [Space(15)]
        public float InactiveTimeDelay = 2f;

        private void Awake()
        {
            _collisions.CollisionNotifier = OnCollected;
            _collisions.Enable();
            _animator.OnStart();
            _coinView.Show();
        }

        public void OnCollected()
        {
            _animator.OnCollected();
            _particles.PlayParticles();
            _collisions.Disable();
            _coinView.Hide();
            StartCoroutine(DisableCountdown());
        }
        private IEnumerator DisableCountdown()
        {
            yield return new WaitForSeconds(InactiveTimeDelay);
            gameObject.SetActive(false);
        }

    }
}