using UnityEngine;

namespace Scriptable
{
    [CreateAssetMenu(fileName ="BoolVariable", menuName ="Variables/BoolVariable", order = 50)]
    public class BoolVariable : ScriptableObject
    {
        public delegate void OnBoolVariable(bool value);

        private event OnBoolVariable listener;

        public event OnBoolVariable Listener
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

        [SerializeField] private bool value;

        public bool GetValue()
        {
            return value;
        }

        public void SetValue(bool value)
        {
            this.value = value;
        }

        public void Raise()
        {
            listener?.Invoke(value);
        }
    }
}

