using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using EventSystem;
using DG.Tweening;
using LifeIsUnfair.Environment;

namespace LifeIsUnfair.Game
{
    [AddComponentMenu("Life is Unfair/Game/Area Manager")]
    [DisallowMultipleComponent]
    public class AreaManager : MonoBehaviour
    {
        #region Travel Fields
        private const float _areaTransitionTime = 0.25f;

        [SerializeField] private EventSubscriber _eventSubscriber = null;
        [SerializeField] private Canvas _areaTransitionCanvas = null;
        [SerializeField] private Image _areaTransition = null;

        public static AreaEnum CurrentArea { get; private set; } = AreaEnum.StartingArea;
        private AreaEnum _areaToLoad = AreaEnum.StartingArea;
        public static int CurrentAreaEntrance { get; private set; } = 0;
        private int _areaToLoadEntrance = 0;
        public static bool IsLoading { get; private set; } = false;
        #endregion

        #region Unity Events
        private void Awake()
        {
            _eventSubscriber.Subscribe("load-area", (string data) =>
            {
                IsLoading = true;
                string[] dataParts = data.Split('|');
                _areaToLoad = (AreaEnum)int.Parse(dataParts[0]);
                _areaToLoadEntrance = int.Parse(dataParts[1]);
                _areaTransitionCanvas.enabled = true;
                _areaTransition.DOFade(1, _areaTransitionTime).From(0).OnComplete(StartLoadArea);
            });

            _eventSubscriber.Subscribe("initial-load-game", (string savedGame) =>
            {
                GameSaveData saveData = JsonUtility.FromJson<GameSaveData>(savedGame);
                _eventSubscriber.Trigger("load-area", $"{(int)saveData.CurrentArea}|{saveData.CurrentAreaEntrance}");
            });
        }
        #endregion

        #region Private Methods
        private void StartLoadArea()
        {
            Scene currentArea = SceneManager.GetSceneByName(CurrentArea.ToString());

            if (currentArea.IsValid())
            {
                SceneManager.UnloadSceneAsync(CurrentArea.ToString()).completed +=
                    (AsyncOperation operation) => LoadArea();
            }
            else LoadArea();
        }

        private void LoadArea()
        {
            SceneManager.LoadSceneAsync(_areaToLoad.ToString(), LoadSceneMode.Additive).completed += FinishLoadArea;
        }

        private void FinishLoadArea(AsyncOperation operation)
        {
            CurrentArea = _areaToLoad;
            CurrentAreaEntrance = _areaToLoadEntrance;
            IsLoading = false;
            _areaTransition.DOFade(0, _areaTransitionTime).From(1).OnComplete(
                () => _areaTransitionCanvas.enabled = false);
            _eventSubscriber.Trigger("finish-load-area", _areaToLoadEntrance);
        }
        #endregion
    }
}