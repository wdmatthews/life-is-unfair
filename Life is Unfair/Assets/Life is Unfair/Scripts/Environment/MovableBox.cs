using UnityEngine;
using EventSystem;

namespace LifeIsUnfair.Environment
{
    [AddComponentMenu("Life is Unfair/Environment/Movable Box")]
    [DisallowMultipleComponent]
    public class MovableBox : MonoBehaviour
    {
        #region Fields
        [SerializeField] private EventSubscriber _eventSubscriber = null;
        [SerializeField] private Rigidbody2D _rigidbody = null;

        private float _gravity = 2.5f;
        private Vector2 _velocityBeforeFreeze = new Vector2();
        #endregion

        #region Unity Events
        private void Awake()
        {
            _gravity = _rigidbody.gravityScale;
            _eventSubscriber.Subscribe("pause-game", Freeze);
            _eventSubscriber.Subscribe("resume-game", Unfreeze);
        }
        #endregion

        #region Private Methods
        private void Freeze()
        {
            _velocityBeforeFreeze = _rigidbody.velocity;
            _rigidbody.velocity = new Vector2();
            _rigidbody.gravityScale = 0;
        }

        private void Unfreeze()
        {
            _rigidbody.velocity = _velocityBeforeFreeze;
            _rigidbody.gravityScale = _gravity;
        }
        #endregion
    }
}