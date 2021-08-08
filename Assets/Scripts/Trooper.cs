using UnityEngine;
using UnityEngine.UI;
using Scriptable;

namespace Action
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Petrol))]
    public class Trooper : MonoBehaviour
    {
        [SerializeField] private Text textTrooperCount;

        [SerializeField] private BlankEvent startTrainingTrooper;
        [SerializeField] private BlankEvent complitedTrainingTrooper;
        [SerializeField] private BlankEvent trainingOn;
        [SerializeField] private BlankEvent trainingOff;

        [SerializeField] private IntegerVariable trooperCount;

        [SerializeField] private IntegerValue trooperCost;
        [SerializeField] private IntegerValue trooperConsumption;

        private Petrol _petrol;

        private void Awake()
        {
            _petrol = GetComponent<Petrol>();
        }

        private void Start()
        {
            SetTrooperinfo();
        }

        private void Update()
        {
            startTrainingTrooper.Listener += StartTraining;
            complitedTrainingTrooper.Listener += CreateTrooper;
        }

        private void StartTraining()
        {
            if (trooperCost.Value <= _petrol.GetPetrolCount())
            {
                trainingOn.Raise();
            }
        }

        private void CreateTrooper()
        {
            trooperCount.ApplyChange(1);
            SetTrooperinfo();
            trainingOff.Raise();
        }

        public int GetTrooperConsumption()
        {
            return trooperCount.GetValue() * trooperConsumption.Value;
        }

        public void SetTrooperCount(int value)
        {
            trooperCount.SetValue(value);
            SetTrooperinfo();
        }

        public void ReduceTrooper(int value)
        {
            trooperCount.ReduceChange(value);
            SetTrooperinfo();
        }

        public int GetTrooperCount()
        {
            return trooperCount.GetValue();
        }

        public int GetCost()
        {
            return trooperCost.Value;
        }

        public void SetTrooperinfo()
        {
            textTrooperCount.text = trooperCount.GetValue().ToString();
        }
    }
}

