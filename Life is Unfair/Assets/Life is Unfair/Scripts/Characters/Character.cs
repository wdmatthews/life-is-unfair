using UnityEngine;
using TMPro;
using EventSystem;
using LifeIsUnfair.Environment;

namespace LifeIsUnfair.Characters
{
    [AddComponentMenu("Life is Unfair/Characters/Character")]
    [DisallowMultipleComponent]
    public class Character : MonoBehaviour
    {
        #region Fields
        [SerializeField] private bool _isPlayer = false;
        [SerializeField] private CharacterLetter _letter = CharacterLetter.A;
        [SerializeField] private EventSubscriber _eventSubscriber = null;

        public bool IsPlayer => _isPlayer;
        public CharacterLetter Letter => _letter;
        private bool _isFrozen = false;
        #endregion

        #region Input Fields
        private float _horizontalInput = 0;
        private float _verticalInput = 0;
        private bool _jumpInput = false;
        private bool _previousJumpInput = false;
        #endregion

        #region Physics Fields
        [Header("Physics")]
        [SerializeField] private Rigidbody2D _rigidbody = null;
        [SerializeField] private float _movementSpeed = 1;
        [SerializeField] private float _gravity = 1;
        [SerializeField] private float _jumpSpeed = 1;
        [SerializeField] private float _jumpCancelPercent = 0.5f;
        [SerializeField] private Vector2 _groundCheckSize = new Vector2(0.5f, 0.1f);
        [SerializeField] private LayerMask _groundLayer = new LayerMask();
        [SerializeField] private LayerMask _bounceLayer = new LayerMask();
        [SerializeField] private LayerMask _ladderLayer = new LayerMask();

        private bool _isGrounded = false;
        private bool _isJumping = false;
        private bool _isBouncing = false;
        private bool _isOnLadder = false;
        private Vector2 _velocityBeforeFreeze = new Vector2();
        #endregion

        #region Style Fields
        [Space]
        [Header("Style")]
        [SerializeField] private SpriteRenderer _renderer = null;
        [SerializeField] private SpriteRenderer _outlineRenderer = null;
        [SerializeField] private TextMeshPro _label = null;
        #endregion

        #region Unity Events
        private void Awake()
        {
            _rigidbody.gravityScale = _gravity;
            _eventSubscriber.Subscribe("pause-game", Freeze);
            _eventSubscriber.Subscribe("resume-game", Unfreeze);
        }

        private void FixedUpdate()
        {
            if (_isFrozen) return;

            Collider2D groundCollider = Physics2D.OverlapBox(transform.position, _groundCheckSize, 0, _groundLayer);
            Collider2D bounceCollider = groundCollider
                ? Physics2D.OverlapBox(transform.position, _groundCheckSize, 0, _bounceLayer)
                : null;
            Collider2D ladderCollider = Physics2D.OverlapBox(transform.position, _groundCheckSize, 0, _ladderLayer);
            bool wasGrounded = _isGrounded;
            _isGrounded = groundCollider;
            bool wasOnLadder = _isOnLadder;
            _isOnLadder = ladderCollider;

            if (wasOnLadder != _isOnLadder)
            {
                _rigidbody.gravityScale = _isOnLadder ? 0 : _gravity;
            }

            Vector2 velocity = _rigidbody.velocity;
            velocity.x = _horizontalInput * _movementSpeed;

            if (!_previousJumpInput && _jumpInput && _isGrounded && !_isJumping && !_isBouncing && !_isOnLadder)
            {
                if (bounceCollider)
                {
                    BouncePad bouncePad = bounceCollider.GetComponent<BouncePad>();
                    velocity.y = bouncePad.BounceForce;
                    _isBouncing = true;
                }
                else
                {
                    _isJumping = true;
                    velocity.y = _jumpSpeed;
                }
            }

            _previousJumpInput = _jumpInput;

            if (_isOnLadder) velocity.y = _verticalInput * _movementSpeed;

            if (_isGrounded && Mathf.Approximately(velocity.y, 0)
                || !wasGrounded && _isGrounded)
            {
                _isJumping = false;
                _isBouncing = false;

                if (!wasGrounded && _isGrounded && bounceCollider)
                {
                    BouncePad bouncePad = bounceCollider.GetComponent<BouncePad>();
                    velocity.y = bouncePad.BounceForce;
                    _isBouncing = true;
                }
            }

            _rigidbody.velocity = velocity;
        }
        #endregion

        #region Public Methods
        public void SetHorizontalInput(float horizontalInput)
        {
            _horizontalInput = horizontalInput;
        }

        public void SetVerticalInput(float verticalInput)
        {
            _verticalInput = verticalInput;
        }

        public void SetJumpInput(bool jumpInput)
        {
            if (!_isFrozen && _isJumping && _jumpInput && !jumpInput && _rigidbody.velocity.y > 0)
            {
                Vector2 velocity = _rigidbody.velocity;
                velocity.y *= _jumpCancelPercent;
                _rigidbody.velocity = velocity;
            }

            _jumpInput = jumpInput;
        }

        public void SetColor(Color newColor)
        {
            _renderer.color = new Color(newColor.r, newColor.g, newColor.b, _renderer.color.a);
            _outlineRenderer.color = new Color(newColor.r, newColor.g, newColor.b, _outlineRenderer.color.a);
        }

        public void SetAlpha(float newAlpha)
        {
            Color color = _renderer.color;
            color.a = newAlpha;
            _renderer.color = color;
        }

        public void SetLabelColor(Color newColor)
        {
            _label.color = new Color(newColor.r, newColor.g, newColor.b, _label.color.a);
        }

        public void ToggleLabel(bool isShown)
        {
            _label.gameObject.SetActive(isShown);
        }
        #endregion

        #region Private Methods
        private void Freeze()
        {
            _velocityBeforeFreeze = _rigidbody.velocity;
            _rigidbody.velocity = new Vector2();
            _rigidbody.gravityScale = 0;
            _isFrozen = true;
        }

        private void Unfreeze()
        {
            _rigidbody.velocity = _velocityBeforeFreeze;
            _rigidbody.gravityScale = _gravity;
            _isFrozen = false;
        }
        #endregion
    }
}