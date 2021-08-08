using UnityEngine;
using UnityEngine.UI;
using Scriptable;
using Action;

[DisallowMultipleComponent]
[RequireComponent(typeof(Trooper))]
public class Enemy : MonoBehaviour
{
    [SerializeField] private Text enemyCountText;
    [SerializeField] private IntegerVariable enemyCount;
    [SerializeField] private IntegerValue enemyReinforcement;
    [SerializeField] private BlankEvent complitedAttackCycle;
    [SerializeField] private BlankEvent successfulAttack;
    [SerializeField] private BlankEvent unSuccessfulAttack;

    [SerializeField] private IntegerVariable attackCycleCount;
    private Trooper _trooper;

    private void Awake()
    {
        _trooper = GetComponent<Trooper>();
    }

    private void Start()
    {
        SetAttackInfo();
    }

    private void Update()
    {
        complitedAttackCycle.Listener += ResultAttack;
    }

    private void ResultAttack()
    {
        attackCycleCount.ApplyChange(1);

        if (enemyCount.GetValue() <= _trooper.GetTrooperCount())
        {
            AttackProgress();
            unSuccessfulAttack.Raise();
        }
        else
        {
            _trooper.SetTrooperCount(0);
            successfulAttack.Raise();
        }
    }

    private void AttackProgress()
    {
        int enemyTemp = enemyCount.GetValue();
        _trooper.ReduceTrooper(enemyTemp);
        enemyCount.SetValue(0);
        enemyCount.ApplyChange(enemyReinforcement.Value * attackCycleCount.GetValue());
        SetAttackInfo();
    }

    private void SetAttackInfo()
    {
        enemyCountText.text = enemyCount.GetValue().ToString();
    }
}
