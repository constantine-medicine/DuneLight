using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "BlankEvent", menuName = "Events/BlankEvent", order = 50)]
    public class BlankEvent : ScriptableObject
    {
        public delegate void OnBlankEventGame();

        private event OnBlankEventGame listener;

        public event OnBlankEventGame Listener
        {
            add
            {
                listener -= value;
                listener += value;
            }
            remove
            {
                listener -= value;
            }
        }

        public void Raise()
        {
            listener?.Invoke();
        }
    }

}

