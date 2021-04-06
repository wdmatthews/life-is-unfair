using UnityEngine;

namespace LifeIsUnfair.Environment
{
    public abstract class Triggerable : MonoBehaviour
    {
        public abstract void Trigger();
        public abstract void Trigger(bool boolValue);
    }
}