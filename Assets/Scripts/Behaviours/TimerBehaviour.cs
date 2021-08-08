using Scriptable;
using UnityEngine;
using UnityEngine.UI;

namespace Behaviours
{
    [DisallowMultipleComponent]
    [RequireComponent(typeof(Image))]
    public class TimerBehaviour : MonoBehaviour
    {
        private Image _imageTimer;
        [SerializeField] private IntegerValue durationTime;
        [SerializeField] private BlankEvent progressComplited;
        [SerializeField] private BoolVariable progressWorker;
        private float durationTimeTemp;

        private void Start()
        {
            _imageTimer = GetComponent<Image>();
            StartProgress();
        }

        private void Update()
        {
            if (progressWorker.GetValue())
            {
                Progress();
            }
        }

        private void Progress()
        {
            if (durationTimeTemp > 0)
            {
                ProgressUpdate();
            }
            else
            {
                ComplitedProgress();
            }
        }

        private void ComplitedProgress()
        {
            _imageTimer.fillAmount = 1;
            StartProgress();
            progressComplited.Raise();
        }

        private void ProgressUpdate()
        {
            durationTimeTemp -= Time.deltaTime;
            _imageTimer.fillAmount = durationTimeTemp / durationTime.Value;
        }

        private void StartProgress()
        {
            durationTimeTemp = durationTime.Value;
        }
    }

}

