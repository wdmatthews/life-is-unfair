using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

namespace LifeIsUnfair.Game
{
    [AddComponentMenu("Life is Unfair/Game/Main Menu")]
    [DisallowMultipleComponent]
    public class MainMenu : MonoBehaviour
    {
        #region UI Fields
        private const float _animationTime = 0.15f;

        [SerializeField] private Button _continueButton = null;
        [SerializeField] private Image _windowBackground = null;
        [SerializeField] private Transform _settingsWindow = null;
        [SerializeField] private Transform _creditsWindow = null;
        [SerializeField] private Slider _volumeSlider = null;
        [SerializeField] private Toggle _characterLabelsToggle = null;
        [SerializeField] private TMP_InputField _tileR = null;
        [SerializeField] private TMP_InputField _tileG = null;
        [SerializeField] private TMP_InputField _tileB = null;
        [SerializeField] private Image _tilePreview = null;
        [SerializeField] private TMP_InputField _movingPlatformR = null;
        [SerializeField] private TMP_InputField _movingPlatformG = null;
        [SerializeField] private TMP_InputField _movingPlatformB = null;
        [SerializeField] private Image _movingPlatformPreview = null;
        [SerializeField] private TMP_InputField _movableBoxR = null;
        [SerializeField] private TMP_InputField _movableBoxG = null;
        [SerializeField] private TMP_InputField _movableBoxB = null;
        [SerializeField] private Image _movableBoxPreview = null;
        [SerializeField] private TMP_InputField _bouncePadR = null;
        [SerializeField] private TMP_InputField _bouncePadG = null;
        [SerializeField] private TMP_InputField _bouncePadB = null;
        [SerializeField] private Image _bouncePadPreview = null;
        [SerializeField] private TMP_InputField _ladderR = null;
        [SerializeField] private TMP_InputField _ladderG = null;
        [SerializeField] private TMP_InputField _ladderB = null;
        [SerializeField] private Image _ladderPreview = null;
        [SerializeField] private TMP_InputField _buttonR = null;
        [SerializeField] private TMP_InputField _buttonG = null;
        [SerializeField] private TMP_InputField _buttonB = null;
        [SerializeField] private Image _buttonPreview = null;
        [SerializeField] private TMP_InputField _doorR = null;
        [SerializeField] private TMP_InputField _doorG = null;
        [SerializeField] private TMP_InputField _doorB = null;
        [SerializeField] private Image _doorPreview = null;

        private GameSettings _settings = new GameSettings();
        #endregion

        #region Unity Events
        private void Awake()
        {
            _continueButton.interactable = PlayerPrefs.HasKey("Game Save");

            if (PlayerPrefs.HasKey("Game Settings"))
            {
                _settings = JsonUtility.FromJson<GameSettings>(PlayerPrefs.GetString("Game Settings"));
                _volumeSlider.value = _settings.Volume;
                _characterLabelsToggle.isOn = _settings.ShowCharacterLabels;
                _tileR.text = ColorComponentToString(_settings.TileColor.r);
                _tileG.text = ColorComponentToString(_settings.TileColor.g);
                _tileB.text = ColorComponentToString(_settings.TileColor.b);
                _movingPlatformR.text = ColorComponentToString(_settings.MovingPlatformColor.r);
                _movingPlatformG.text = ColorComponentToString(_settings.MovingPlatformColor.g);
                _movingPlatformB.text = ColorComponentToString(_settings.MovingPlatformColor.b);
                _movableBoxR.text = ColorComponentToString(_settings.MovableBoxColor.r);
                _movableBoxG.text = ColorComponentToString(_settings.MovableBoxColor.g);
                _movableBoxB.text = ColorComponentToString(_settings.MovableBoxColor.b);
                _bouncePadR.text = ColorComponentToString(_settings.BouncePadColor.r);
                _bouncePadG.text = ColorComponentToString(_settings.BouncePadColor.g);
                _bouncePadB.text = ColorComponentToString(_settings.BouncePadColor.b);
                _ladderR.text = ColorComponentToString(_settings.LadderColor.r);
                _ladderG.text = ColorComponentToString(_settings.LadderColor.g);
                _ladderB.text = ColorComponentToString(_settings.LadderColor.b);
                _buttonR.text = ColorComponentToString(_settings.ButtonColor.r);
                _buttonG.text = ColorComponentToString(_settings.ButtonColor.g);
                _buttonB.text = ColorComponentToString(_settings.ButtonColor.b);
                _doorR.text = ColorComponentToString(_settings.DoorColor.r);
                _doorG.text = ColorComponentToString(_settings.DoorColor.g);
                _doorB.text = ColorComponentToString(_settings.DoorColor.b);
                UpdateColorPreview();
            }
        }
        #endregion

        #region Public Methods
        public void Continue() => SceneManager.LoadSceneAsync("Game");

        public void NewGame()
        {
            PlayerPrefs.SetString("Game Save", JsonUtility.ToJson(new GameSaveData()));
            PlayerPrefs.Save();
            Continue();
        }

        public void Settings()
        {
            _settingsWindow.gameObject.SetActive(true);
            _windowBackground.gameObject.SetActive(true);
            _settingsWindow.DOScale(1, _animationTime).From(0);
            _windowBackground.DOFade(0.25f, _animationTime).From(0);
        }

        public void Credits()
        {
            _creditsWindow.gameObject.SetActive(true);
            _windowBackground.gameObject.SetActive(true);
            _creditsWindow.DOScale(1, _animationTime).From(0);
            _windowBackground.DOFade(0.25f, _animationTime).From(0);
        }

        public void SaveSettings()
        {
            _settings.Volume = _volumeSlider.value;
            _settings.ShowCharacterLabels = _characterLabelsToggle.isOn;
            _settings.TileColor = TextToColor(_tileR.text, _tileG.text, _tileB.text);
            _settings.MovingPlatformColor = TextToColor(_movingPlatformR.text, _movingPlatformG.text, _movingPlatformB.text);
            _settings.MovableBoxColor = TextToColor(_movableBoxR.text, _movableBoxG.text, _movableBoxB.text);
            _settings.BouncePadColor = TextToColor(_bouncePadR.text, _bouncePadG.text, _bouncePadB.text);
            _settings.LadderColor = TextToColor(_ladderR.text, _ladderG.text, _ladderB.text);
            _settings.ButtonColor = TextToColor(_buttonR.text, _buttonG.text, _buttonB.text);
            _settings.DoorColor = TextToColor(_doorR.text, _doorG.text, _doorB.text);

            PlayerPrefs.SetString("Game Settings", JsonUtility.ToJson(_settings));
            PlayerPrefs.Save();
            _settingsWindow.DOScale(0, _animationTime).From(1).OnComplete(
                () => _settingsWindow.gameObject.SetActive(false));
            _windowBackground.DOFade(0, _animationTime).From(0.25f).OnComplete(
                () => _windowBackground.gameObject.SetActive(false));
        }

        public void CloseCredits()
        {
            _creditsWindow.DOScale(0, _animationTime).From(1).OnComplete(
                () => _creditsWindow.gameObject.SetActive(false));
            _windowBackground.DOFade(0, _animationTime).From(0.25f).OnComplete(
                () => _windowBackground.gameObject.SetActive(false));
        }

        public void UpdateColorPreview()
        {
            UpdateTileColorPreview();
            UpdateMovingPlatformColorPreview();
            UpdateMovableBoxColorPreview();
            UpdateBouncePadColorPreview();
            UpdateLadderColorPreview();
            UpdateButtonColorPreview();
            UpdateDoorColorPreview();
        }

        public void UpdateTileColorPreview()
        {
            _tilePreview.color = TextToColor(_tileR.text, _tileG.text, _tileB.text);
        }

        public void UpdateMovingPlatformColorPreview()
        {
            _movingPlatformPreview.color = TextToColor(_movingPlatformR.text, _movingPlatformG.text, _movingPlatformB.text);
        }

        public void UpdateMovableBoxColorPreview()
        {
            _movableBoxPreview.color = TextToColor(_movableBoxR.text, _movableBoxG.text, _movableBoxB.text);
        }

        public void UpdateBouncePadColorPreview()
        {
            _bouncePadPreview.color = TextToColor(_bouncePadR.text, _bouncePadG.text, _bouncePadB.text);
        }

        public void UpdateLadderColorPreview()
        {
            _ladderPreview.color = TextToColor(_ladderR.text, _ladderG.text, _ladderB.text);
        }

        public void UpdateButtonColorPreview()
        {
            _buttonPreview.color = TextToColor(_buttonR.text, _buttonG.text, _buttonB.text);
        }

        public void UpdateDoorColorPreview()
        {
            _doorPreview.color = TextToColor(_doorR.text, _doorG.text, _doorB.text);
        }
        #endregion

        #region Private Methods
        private Color TextToColor(string r, string g, string b)
        {
            if (r.Length == 0) r = "0";
            if (g.Length == 0) g = "0";
            if (b.Length == 0) b = "0";
            return new Color(float.Parse(r) / 255f, float.Parse(g) / 255f, float.Parse(b) / 255f);
        }

        private string ColorComponentToString(float c)
        {
            return Mathf.RoundToInt(255f * c).ToString();
        }
        #endregion
    }
}