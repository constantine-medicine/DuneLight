using UnityEngine;
using UnityEngine.UI;
using Scriptable;

namespace Action
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Trooper), typeof(Harvester))]
    public class Petrol : MonoBehaviour
    {
        [SerializeField] private Text textPetrolCount;
        [SerializeField] private IntegerVariable petrolCount;

        [SerializeField] private BlankEvent complitedConsumptionCycle;
        [SerializeField] private BlankEvent complitedHarvestCycle;
        [SerializeField] private BlankEvent trainingHarvesterOn;
        [SerializeField] private BlankEvent trainingTrooperOn;

        private Trooper _trooper;
        private Harvester _harvester;

        private void Awake()
        {
            _trooper = GetComponent<Trooper>();
            _harvester = GetComponent<Harvester>();
        }

        private void Start()
        {
            SetPetrolInfo();
        }

        private void Update()
        {
            complitedConsumptionCycle.Listener += PetrolConsumtion;
            complitedHarvestCycle.Listener += PetrolHarvest;
            trainingHarvesterOn.Listener += ReducePetrolHarvesterTraining;
            trainingTrooperOn.Listener += ReducePetrolTrooperTraining;
        }

        private void PetrolHarvest()
        {
            petrolCount.ApplyChange(_harvester.GetHarvesterMining());
            SetPetrolInfo();    
        }

        private void PetrolConsumtion()
        {
            petrolCount.ReduceChange(_trooper.GetTrooperConsumption());
            petrolCount.ReduceChange(_harvester.GetHarvesterConsumption());

            if (petrolCount.GetValue() < 0)
            {
                _trooper.SetTrooperCount(0);
                petrolCount.SetValue(0);
            }

            SetPetrolInfo();
        }

        public int GetPetrolCount()
        {
            return petrolCount.GetValue();
        }

        public void ReducePetrol(int value)
        {
            petrolCount.ReduceChange(value);
            SetPetrolInfo();
        }

        private void ReducePetrolHarvesterTraining()
        {
            petrolCount.ReduceChange(_harvester.GetCost());
            SetPetrolInfo();
        }

        private void ReducePetrolTrooperTraining()
        {
            petrolCount.ReduceChange(_trooper.GetCost());
            SetPetrolInfo();
        }

        public void SetPetrolInfo()
        {
            textPetrolCount.text = petrolCount.GetValue().ToString();
        }
    }
}

