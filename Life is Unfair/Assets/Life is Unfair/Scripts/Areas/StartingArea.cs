using UnityEngine;
using EventSystem;
using LifeIsUnfair.Characters;
using LifeIsUnfair.Environment;
using LifeIsUnfair.Game;

namespace LifeIsUnfair.Areas
{
    [AddComponentMenu("Life is Unfair/Areas/Starting Area")]
    [DisallowMultipleComponent]
    public class StartingArea : MonoBehaviour
    {
        #region Fields
        [SerializeField] private EventSubscriber _eventSubscriber = null;
        [SerializeField] private Character _characterA = null;
        [SerializeField] private Door _exitDoor = null;
        #endregion

        #region Unity Events
        private void Awake()
        {
            _eventSubscriber.Subscribe("load-area", (string data) =>
            {
                // If the area to load is this room, ignore.
                if ((AreaEnum)int.Parse(data.Split('|')[0]) == AreaManager.CurrentArea) return;
                // Calculate if the character left successfully.
                float currentAlpha = GameManager.SaveData.CharacterLight[(int)_characterA.Letter];
                if (Mathf.Approximately(currentAlpha, 0)) return;
                bool increaseScore = _characterA.transform.position.x > _exitDoor.transform.position.x + 1.9f;
                float newAlpha = Mathf.Clamp(currentAlpha + (increaseScore ? 0.2f : -0.2f), 0, 1);

                GameManager.SaveData.CharacterLight[(int)_characterA.Letter] = newAlpha;
                currentAlpha = GameManager.SaveData.PlayerLight;
                newAlpha = Mathf.Clamp(currentAlpha + (increaseScore ? 0.2f : -0.2f), 0, 1);
                GameManager.SaveData.PlayerLight = newAlpha;
                if (Mathf.Approximately(newAlpha, 0)) AreaManager.PlayerIsDead = true;
            });
        }

        private void Update()
        {
            float characterX = _characterA.transform.position.x;
            float doorX = _exitDoor.transform.position.x;
            _characterA.SetHorizontalInput((_exitDoor.IsOpen || characterX > doorX + 0.5f) && characterX < doorX + 2f ? 1 : 0);
        }
        #endregion
    }
}