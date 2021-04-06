using UnityEngine;
using Cinemachine;
using LifeIsUnfair.Input;

namespace LifeIsUnfair.Characters
{
    [AddComponentMenu("Life is Unfair/Characters/Player")]
    [DisallowMultipleComponent]
    public class Player : MonoBehaviour
    {
        #region Object References
        [SerializeField] private Character _character = null;
        [SerializeField] private CinemachineVirtualCamera _camera = null;

        private Controls _input = null;
        public Character Character => _character;
        #endregion

        #region Unity Events
        private void Awake()
        {
            _input = new Controls();
            _input.Enable();
            _camera.Follow = _character.transform;
        }

        private void Update()
        {
            if (!_character) return;
            _character.SetHorizontalInput(_input.Player.HorizontalMovement.ReadValue<float>());
            _character.SetVerticalInput(_input.Player.VerticalMovement.ReadValue<float>());
            _character.SetJumpInput(Mathf.Approximately(_input.Player.Jump.ReadValue<float>(), 1));
        }
        #endregion

        #region Public Methods
        public void Spawn(Vector3 position)
        {
            _character.transform.position = position;
            _camera.transform.position = position;
        }
        #endregion
    }
}