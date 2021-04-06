using UnityEngine;
using EventSystem;

namespace LifeIsUnfair.Environment
{
    [AddComponentMenu("Life is Unfair/Environment/Moving Platform")]
    [DisallowMultipleComponent]
    public class MovingPlatform : MonoBehaviour
    {
        [SerializeField] private EventSubscriber _eventSubscriber = null;

        #region Physics Fields
        [Header("Physics")]
        [SerializeField] private string _characterLayerName = "Character";
        [SerializeField] private string _movableBoxLayerName = "Movable Box";
        [SerializeField] private float _movementSpeed = 1;

        private int _characterLayer = 0;
        private int _movableBoxLayer = 0;
        private bool _isFrozen = false;
        #endregion

        #region Path Fields
        [Header("Path")]
        [SerializeField] private float _waitTime = 1;
        [SerializeField] private Vector3[] _waypoints = { };

        private int _currentWaypointIndex = 1;
        private float _waitTimer = 0;
        #endregion

        #region Unity Events
        private void Awake()
        {
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
            _movableBoxLayer = LayerMask.NameToLayer(_movableBoxLayerName);
            _eventSubscriber.Subscribe("pause-game", () => _isFrozen = true);
            _eventSubscriber.Subscribe("resume-game", () => _isFrozen = false);
        }

        private void Update()
        {
            if (_isFrozen) return;

            if (Mathf.Approximately(_waitTimer, 0))
            {
                Vector3 currentWaypoint = _waypoints[_currentWaypointIndex];
                transform.position = Vector3.MoveTowards(
                    transform.position, currentWaypoint, _movementSpeed * Time.deltaTime);

                if (Mathf.Approximately(transform.position.x, currentWaypoint.x)
                    && Mathf.Approximately(transform.position.y, currentWaypoint.y))
                {
                    _waitTimer = _waitTime;
                    _currentWaypointIndex++;

                    if (_currentWaypointIndex >= _waypoints.Length)
                    {
                        _currentWaypointIndex = 0;
                    }
                }
            }
            else _waitTimer = Mathf.Clamp(_waitTimer - Time.deltaTime, 0, _waitTime);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if ((collision.gameObject.layer == _characterLayer
                || collision.gameObject.layer == _movableBoxLayer)
                && collision.transform.position.y > transform.position.y + 0.1f)
            {
                collision.transform.SetParent(transform);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if ((collision.gameObject.layer == _characterLayer
                || collision.gameObject.layer == _movableBoxLayer)
                && collision.transform.parent == transform)
            {
                collision.transform.SetParent(null);
            }
        }
        #endregion
    }
}