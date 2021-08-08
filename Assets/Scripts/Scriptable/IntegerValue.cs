using UnityEngine;

namespace Scriptable 
{
    [CreateAssetMenu(fileName = "IntegerValue", menuName = "Value/IntegerValue", order = 50)]
    public class IntegerValue : ScriptableObject
    {
        [SerializeField] private int value;

        public int Value { get => value; set => Value = value; }
    }
}

