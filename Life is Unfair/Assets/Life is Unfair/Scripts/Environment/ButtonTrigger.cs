using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace LifeIsUnfair.Environment
{
    [AddComponentMenu("Life is Unfair/Environment/Button Trigger")]
    [DisallowMultipleComponent]
    public class ButtonTrigger : MonoBehaviour
    {
        #region Trigger Fields
        [SerializeField] private string _characterLayerName = "Character";
        [SerializeField] private string _movableBoxLayerName = "Movable Box";
        [SerializeField] private Triggerable _target = null;
        [SerializeField] private float _pressAnimationTime = 0.1f;
        [SerializeField] private float _pressedScale = 0.1f;

        private int _characterLayer = 0;
        private int _movableBoxLayer = 0;
        private List<Transform> _transformsPressingButton = new List<Transform>();
        #endregion

        #region Unity Events
        private void Awake()
        {
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
            _movableBoxLayer = LayerMask.NameToLayer(_movableBoxLayerName);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _characterLayer
                || collision.gameObject.layer == _movableBoxLayer)
            {
                TryPressButton(collision.transform);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _characterLayer
                || collision.gameObject.layer == _movableBoxLayer)
            {
                TryReleaseButton(collision.transform);
            }
        }
        #endregion

        #region Private Methods
        private void TryPressButton(Transform t)
        {
            if (_transformsPressingButton.Contains(t)) return;
            if (_transformsPressingButton.Count == 0)
            {
                _target.Trigger(true);
                transform.DOScaleY(_pressedScale, _pressAnimationTime);
            }

            _transformsPressingButton.Add(t);
        }

        private void TryReleaseButton(Transform t)
        {
            if (!_transformsPressingButton.Contains(t)) return;
            _transformsPressingButton.Remove(t);

            if (_transformsPressingButton.Count == 0)
            {
                _target.Trigger(false);
                transform.DOScaleY(1, _pressAnimationTime);
            }
        }
        #endregion
    }
}