using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackSequence2 : PlayerState
{
    // attackactionnya
    private InputActionReference attackAction;
    // timer combonya
    private float comboWaitTime;

    // seberapa jauh dia ngedash
    private float dashDistance;
    private float dashDuration;

    // contructornya
    public AttackSequence2(PlayerController playerController, PlayerStateMachine playerStateMachine, InputActionReference attackAction) : base(playerController, playerStateMachine)
    {
        this.attackAction = attackAction;
        this.comboWaitTime = GameManager.instance.waitTimeAttackSequence2;
        this.dashDistance = GameManager.instance.dashDistanceAttackSequence2;
        this.dashDuration = GameManager.instance.dashDurationAttackSequence2;
    }

    public override void Enter()
    {
        Debug.Log("[State] attack2 entered");

        playerController.debugComboAttack.text = "attack2";
        playerController.CanDash = false;

        // nyalain collidernya
        playerController.attackColliderObj2.SetActive(true);

        // start coroutinenya
        playerController.StartCoroutine(ComboCoroutine());
    }

    private IEnumerator ComboCoroutine()
    {
        // start sedikit dash nya
        playerController.StartCoroutine(playerController.MiniDashAttack(dashDistance, dashDuration));

        // reference apakah queued
        bool isQueue = false;
        // timernya
        float timer = comboWaitTime;

        // kalau timernya masih ada maka cek apakah attack ditekan
        while (timer > 0f)
        {
            if (attackAction != null && attackAction.action != null && attackAction.action.triggered)
            {
                isQueue = true;
                Debug.Log("[Combo] queue to attack 3");
            }

            timer -= Time.deltaTime;
            yield return null;
        }

        if (isQueue) playerStateMachine.ChangeState(playerController.attackSequence3);
        else playerStateMachine.ChangeState(playerController.idleState);
    }

    public override void LogicUpdate()
    {

    }

    public override void Exit()
    {
        Debug.Log("[State] attack2 exited");
        playerController.CanDash = true;

        // matiin lagi collidernya
        playerController.attackColliderObj2.SetActive(false);
    }
}
