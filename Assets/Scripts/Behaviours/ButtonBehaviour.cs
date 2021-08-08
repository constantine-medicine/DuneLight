using Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviours
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Button))]
    public class ButtonBehaviour : MonoBehaviour
    {
        private Button _button;
        [SerializeField] private BlankEvent startTraining;
        [SerializeField] private BlankEvent trainingOn;
        [SerializeField] private BlankEvent trainingOff;

        [SerializeField] private BoolVariable startTrainingFlag;

        private void Start()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(StartTraining);
        }

        private void Update()
        {
            trainingOn.Listener += TrainingOn;
            trainingOff.Listener += TrainingOff;
        }

        private void TrainingOn()
        {
            _button.interactable = false;
            startTrainingFlag.SetValue(true);
        }

        private void TrainingOff()
        {
            _button.interactable = true;
            startTrainingFlag.SetValue(false);
        }

        private void StartTraining()
        {
            startTraining.Raise();
        }
    }
}