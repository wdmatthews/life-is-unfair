using UnityEngine;
using EventSystem;
using LifeIsUnfair.Characters;
using LifeIsUnfair.Environment;
using LifeIsUnfair.Game;

namespace LifeIsUnfair.Areas
{
    [AddComponentMenu("Life is Unfair/Areas/Beneficial Fall")]
    [DisallowMultipleComponent]
    public class BeneficialFall : MonoBehaviour
    {
        #region Fields
        [SerializeField] private EventSubscriber _eventSubscriber = null;
        [SerializeField] private Character _characterA = null;
        [SerializeField] private MovableBox _movableBox = null;
        [SerializeField] private Exit _lowerExit = null;
        #endregion

        #region Unity Events
        private void Awake()
        {
            _eventSubscriber.Subscribe("load-area", (string data) =>
            {
                if ((AreaEnum)int.Parse(data.Split('|')[0]) == AreaManager.CurrentArea) return;
                float currentAlpha = GameManager.SaveData.CharacterLight[(int)_characterA.Letter];
                if (Mathf.Approximately(currentAlpha, 0)) return;
                bool increaseScore = _movableBox.transform.position.y < -18f;
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
            _characterA.SetHorizontalInput(
                (_movableBox.transform.position.y < -18 || characterX > -5.5f)
                && characterX < _lowerExit.transform.position.x - 0.25f ? 1 : 0);
        }
        #endregion
    }
}