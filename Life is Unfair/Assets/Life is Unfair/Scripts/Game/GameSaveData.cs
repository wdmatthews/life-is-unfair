using LifeIsUnfair.Environment;

namespace LifeIsUnfair.Game
{
    [System.Serializable]
    public class GameSaveData
    {
        public AreaEnum CurrentArea = AreaEnum.StartingArea;
        public int CurrentAreaEntrance = 0;
        public float PlayerLight = 1;
        public float[] CharacterLight = { 0.5f };
    }
}