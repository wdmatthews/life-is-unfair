using UnityEngine;

namespace LifeIsUnfair.Environment
{
    [AddComponentMenu("Life is Unfair/Environment/Bounce Pad")]
    [DisallowMultipleComponent]
    public class BouncePad : MonoBehaviour
    {
        #region Physics Fields
        [SerializeField] float _bounceForce = 1;

        public float BounceForce => _bounceForce;
        #endregion
    }
}