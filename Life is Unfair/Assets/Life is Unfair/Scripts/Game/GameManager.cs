using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
using EventSystem;

namespace LifeIsUnfair.Game
{
    [AddComponentMenu("Life is Unfair/Game/Game Manager")]
    [DisallowMultipleComponent]
    public class GameManager : MonoBehaviour
    {
        #region Fields
        private const float _animationTime = 0.25f;
        private static readonly Color _saveMessageShownColor = new Color(1, 1, 1);
        private static readonly Color _saveMessageHiddenColor = new Color(1, 1, 1, 0);

        [SerializeField] private EventSubscriber _eventSubscriber = null;
        [SerializeField] private Image _pauseWindowBackground = null;
        [SerializeField] private Transform _pauseWindow = null;
        [SerializeField] private TextMeshProUGUI _saveMessage = null;

        private GameSettings _settings = new GameSettings();
        private string _savedSettings = "";
        public static GameSaveData SaveData { get; private set; } = new GameSaveData();
        private string _savedGame = "";
        private bool _isPaused = false;
        private bool _pauseAnimationIsDone = false;
        #endregion

        #region Unity Events
        private void Awake()
        {
            _eventSubscriber.Subscribe("finish-load-area", (int entrance) =>
            {
                SaveData.CurrentArea = AreaManager.CurrentArea;
                SaveData.CurrentAreaEntrance = entrance;
                SaveGame();
                _eventSubscriber.Trigger("load-settings", _savedSettings);
                _eventSubscriber.Trigger("load-game", _savedGame);
            });
        }

        private void Start()
        {
            LoadSettings();
            LoadGame();
        }
        #endregion

        #region Public Methods
        public void Pause()
        {
            if (_isPaused) return;
            _isPaused = true;
            _pauseWindowBackground.gameObject.SetActive(true);
            _pauseWindow.gameObject.SetActive(true);
            _pauseWindowBackground.DOFade(0.25f, _animationTime).From(0);
            _pauseWindow.DOScale(1, _animationTime).From(0).OnComplete(() => _pauseAnimationIsDone = true);
            _eventSubscriber.Trigger("pause-game");
        }

        public void Resume()
        {
            if (!_isPaused || !_pauseAnimationIsDone) return;
            _pauseAnimationIsDone = false;
            _pauseWindowBackground.DOFade(0, _animationTime);
            _pauseWindow.DOScale(0, _animationTime).OnComplete(
                () =>
                {
                    _pauseWindowBackground.gameObject.SetActive(false);
                    _pauseWindow.gameObject.SetActive(false);
                    _isPaused = false;
                    _eventSubscriber.Trigger("resume-game");
                });
        }

        public void MainMenu()
        {
            SceneManager.LoadSceneAsync("Main Menu");
        }

        public void Reload()
        {
            if (AreaManager.IsLoading) return;
            _eventSubscriber.Trigger("load-area", $"{(int)AreaManager.CurrentArea}|{AreaManager.CurrentAreaEntrance}");
        }
        #endregion

        #region Private Methods
        private void LoadSettings()
        {
            if (PlayerPrefs.HasKey("Game Settings"))
            {
                _savedSettings = PlayerPrefs.GetString("Game Settings");
                _settings = JsonUtility.FromJson<GameSettings>(_savedSettings);
            }
            else
            {
                _settings = new GameSettings();
                _savedSettings = JsonUtility.ToJson(_settings);
            }

            _eventSubscriber.Trigger("load-settings", _savedSettings);
        }

        private void LoadGame()
        {
            if (PlayerPrefs.HasKey("Game Save"))
            {
                _savedGame = PlayerPrefs.GetString("Game Save");
                SaveData = JsonUtility.FromJson<GameSaveData>(_savedGame);
            }
            else
            {
                SaveData = new GameSaveData();
                _savedGame = JsonUtility.ToJson(SaveData);
            }

            _eventSubscriber.Trigger("initial-load-game", _savedGame);
        }

        private void SaveGame()
        {
            _savedGame = JsonUtility.ToJson(SaveData);
            PlayerPrefs.SetString("Game Save", _savedGame);
            PlayerPrefs.Save();
            _saveMessage.gameObject.SetActive(true);
            var saveMessageSequence = DOTween.Sequence();
            saveMessageSequence.Append(_saveMessage.DOColor(_saveMessageShownColor, _animationTime).From(_saveMessageHiddenColor));
            saveMessageSequence.AppendInterval(1);
            saveMessageSequence.Append(_saveMessage.DOColor(_saveMessageHiddenColor, _animationTime));
            saveMessageSequence.OnComplete(() => _saveMessage.gameObject.SetActive(false));
        }
        #endregion
    }
}