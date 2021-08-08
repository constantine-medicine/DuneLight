using Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace Action
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Petrol))]
    public class Harvester : MonoBehaviour
    {
        [SerializeField] private Text textHarvesterCount;

        [SerializeField] private BlankEvent startTrainingHarvester;
        [SerializeField] private BlankEvent complitedTrainingHarvester;
        [SerializeField] private BlankEvent trainingOn;
        [SerializeField] private BlankEvent trainingOff;

        [SerializeField] private IntegerVariable harvesterCount;

        [SerializeField] private IntegerValue harvesterCost;
        [SerializeField] private IntegerValue harvesterConsumtion;
        [SerializeField] private IntegerValue harvesterMining;

        private Petrol _petrol;

        private void Awake()
        {
            _petrol = GetComponent<Petrol>();
        }

        private void Start()
        {
            SetHarvesterInfo();
        }

        private void Update()
        {
            startTrainingHarvester.Listener += StartTraining;
            complitedTrainingHarvester.Listener += CreateHarvester;
        }

        private void CreateHarvester()
        {
            harvesterCount.ApplyChange(1);
            SetHarvesterInfo();
            trainingOff.Raise();
        }

        private void StartTraining()
        {
            if (harvesterCost.Value <= _petrol.GetPetrolCount())
            {
                trainingOn.Raise();
            }
        }

        public int GetHarvesterMining()
        {
            return harvesterMining.Value * harvesterCount.GetValue();
        }

        public int GetHarvesterConsumption()
        {
            return harvesterConsumtion.Value * harvesterCount.GetValue();
        }

        private void SetHarvesterInfo()
        {
            textHarvesterCount.text = harvesterCount.GetValue().ToString();
        }

        public int GetCost()
        {
            return harvesterCost.Value;
        }
    }
}
