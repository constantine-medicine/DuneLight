using UnityEngine;
using UnityEngine.UI;
using Scriptable;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BlankEvent unSuccessfulAttack;
    [SerializeField] private BlankEvent successfulAttack;
    [SerializeField] private GameObject panelLose;
    [SerializeField] private IntegerVariable harvesterCount;

    private void Update()
    {
        successfulAttack.Listener += LoseGame;
    }

    private void LoseGame()
    {
        panelLose.SetActive(true);
        Time.timeScale = 0;
    }
}
