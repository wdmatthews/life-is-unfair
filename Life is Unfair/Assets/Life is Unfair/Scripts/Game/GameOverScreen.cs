using UnityEngine;
using UnityEngine.SceneManagement;

namespace LifeIsUnfair.Game
{
    [AddComponentMenu("Life is Unfair/Game/Game Over Screen")]
    [DisallowMultipleComponent]
    public class GameOverScreen : MonoBehaviour
    {
        #region Public Methods
        public void Refill()
        {
            PlayerPrefs.SetString("Game Save", JsonUtility.ToJson(new GameSaveData()));
            PlayerPrefs.Save();
            SceneManager.LoadSceneAsync("Game");
        }

        public void Menu() => SceneManager.LoadSceneAsync("Main Menu");
        #endregion
    }
}