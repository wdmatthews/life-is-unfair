using UnityEngine;

namespace LifeIsUnfair.Game
{
    [System.Serializable]
    public class GameSettings
    {
        public bool ShowCharacterLabels = false;
        public Color TileColor = new Color(25 / 255f, 25 / 255f, 25 / 255f);
        public Color MovingPlatformColor = new Color(25 / 255f, 25 / 255f, 25 / 255f);
        public Color MovableBoxColor = new Color(45 / 255f, 45 / 255f, 45 / 255f);
        public Color BouncePadColor = new Color(232 / 255f, 67 / 255f, 147 / 255f);
        public Color LadderColor = new Color(0, 184 / 255f, 148 / 255f);
        public Color ButtonColor = new Color(214 / 255f, 48 / 255f, 49 / 255f);
        public Color DoorColor = new Color(25 / 255f, 25 / 255f, 25 / 255f);
    }
}