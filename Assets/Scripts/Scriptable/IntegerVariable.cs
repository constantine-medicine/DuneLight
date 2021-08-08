using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName = "integerVariable", menuName = "Variables/IntegerVariable", order = 50)]
    public class IntegerVariable : ScriptableObject
    {
        public delegate void OnIntegerVariable(int value);

        private event OnIntegerVariable listener;

        public event OnIntegerVariable Listener
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

        [SerializeField] private int value;

        public int GetValue()
        {
            return value;
        }

        public void SetValue(int value)
        {
            this.value = value;
        }

        public void ApplyChange(int value)
        {
            this.value += value;
            Raise();
        }

        public void ReduceChange(int value)
        {
            this.value -= value;
            Raise();
        }

        public void Raise()
        {
            listener?.Invoke(value);
        }
    }
}

