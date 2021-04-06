using UnityEngine;
using DG.Tweening;

namespace LifeIsUnfair.Environment
{
    public class Door : Triggerable
    {
        #region Trigger Fields
        [SerializeField] private Vector3 _openPosition = new Vector3();
        [SerializeField] private Vector3 _closedPosition = new Vector3();
        [SerializeField] private float _moveTime = 0.25f;
        [SerializeField] private BoxCollider2D _collider = null;
        #endregion

        #region Public Methods
        public override void Trigger() => Trigger(true);

        public override void Trigger(bool boolValue)
        {
             _collider.enabled = !boolValue;
            transform.DOMove(boolValue ? _openPosition : _closedPosition, _moveTime);
        }
        #endregion
    }
}