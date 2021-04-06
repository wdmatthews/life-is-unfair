using UnityEngine;
using UnityEngine.Tilemaps;
using EventSystem;
using LifeIsUnfair.Characters;
using LifeIsUnfair.Game;

namespace LifeIsUnfair.Environment
{
    [AddComponentMenu("Life is Unfair/Environment/Area")]
    [DisallowMultipleComponent]
    public class Area : MonoBehaviour
    {
        #region Fields
        [SerializeField] private Exit[] _exits = { };
        [SerializeField] private Player _player = null;
        [SerializeField] private Character[] _characters = { };
        [SerializeField] private Tilemap _ground = null;
        [SerializeField] private SpriteRenderer[] _movingPlatforms = { };
        [SerializeField] private SpriteRenderer[] _movableBoxes = { };
        [SerializeField] private SpriteRenderer[] _bouncePads = { };
        [SerializeField] private SpriteRenderer[] _ladders = { };
        [SerializeField] private SpriteRenderer[] _buttons = { };
        [SerializeField] private SpriteRenderer[] _doors = { };
        [SerializeField] private EventSubscriber _eventSubscriber = null;
        #endregion

        #region Unity Events
        private void Awake()
        {
            _eventSubscriber.Subscribe("finish-load-area", (int entrance) =>
            {
                Exit exit = GetExit(entrance);
                if (!exit) return;
                exit.Spawn(_player);
            });

            _eventSubscriber.Subscribe("load-settings", LoadSettings);
            _eventSubscriber.Subscribe("load-game", LoadGameSave);
        }
        #endregion

        #region Public Methods
        public Exit GetExit(int index)
        {
            if (index < 0 || index >= _exits.Length) return null;
            return _exits[index];
        }
        #endregion

        #region Private Methods
        private void LoadSettings(string savedSettings)
        {
            GameSettings settings = JsonUtility.FromJson<GameSettings>(savedSettings);
            _ground.color = settings.TileColor;
            _player.Character.ToggleLabel(settings.ShowCharacterLabels);

            foreach (Character character in _characters)
            {
                character.ToggleLabel(settings.ShowCharacterLabels);
            }

            foreach (SpriteRenderer renderer in _movingPlatforms)
            {
                renderer.color = settings.MovingPlatformColor;
            }

            foreach (SpriteRenderer renderer in _movableBoxes)
            {
                renderer.color = settings.MovableBoxColor;
            }

            foreach (SpriteRenderer renderer in _bouncePads)
            {
                renderer.color = settings.BouncePadColor;
            }

            foreach (SpriteRenderer renderer in _ladders)
            {
                renderer.color = settings.LadderColor;
            }

            foreach (SpriteRenderer renderer in _buttons)
            {
                renderer.color = settings.ButtonColor;
            }

            foreach (SpriteRenderer renderer in _doors)
            {
                renderer.color = settings.DoorColor;
            }
        }

        private void LoadGameSave(string savedGame)
        {
            GameSaveData saveData = JsonUtility.FromJson<GameSaveData>(savedGame);
            _player.Character.SetAlpha(saveData.PlayerLight);

            foreach (Character character in _characters)
            {
                character.SetAlpha(saveData.CharacterLight[(int)character.Letter]);
            }
        }
        #endregion
    }
}