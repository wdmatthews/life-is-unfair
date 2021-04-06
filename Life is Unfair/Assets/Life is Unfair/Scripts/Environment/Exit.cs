using UnityEngine;
using EventSystem;
using LifeIsUnfair.Characters;

namespace LifeIsUnfair.Environment
{
    [AddComponentMenu("Life is Unfair/Environment/Exit")]
    [DisallowMultipleComponent]
    public class Exit : MonoBehaviour
    {
        #region Travel Fields
        [SerializeField] private AreaEnum _targetArea = AreaEnum.StartingArea;
        [SerializeField] private int _targetEntrance = 0;
        [SerializeField] private string _characterLayerName = "Character";
        [SerializeField] private Vector3 _spawnOffset = new Vector3();
        [SerializeField] private EventSubscriber _eventSubscriber = null;

        private int _characterLayer = 0;
        #endregion

        #region Unity Events
        private void Awake()
        {
            _characterLayer = LayerMask.NameToLayer(_characterLayerName);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == _characterLayer)
            {
                Character character = collision.GetComponent<Character>();
                if (!character.IsPlayer) return;
                _eventSubscriber.Trigger("load-area", $"{(int)_targetArea}|{_targetEntrance}");
            }
        }
        #endregion

        #region Public Methods
        public void Spawn(Player player)
        {
            player.Spawn(transform.position + _spawnOffset);
        }
        #endregion
    }
}