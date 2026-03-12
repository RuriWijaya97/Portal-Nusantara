using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackSequence3 : PlayerState
{
    private InputActionReference attackAction;
    private float endComboTime;

    // seberapa jauh dia ngedash
    private float dashDistance;
    private float dashDuration;

    // contructornya
    public AttackSequence3(PlayerController playerController, PlayerStateMachine playerStateMachine, InputActionReference attackAction) : base(playerController, playerStateMachine)
    {
        this.attackAction = attackAction;
        this.endComboTime = GameManager.instance.waitTimeAttackSequence3;
        this.dashDistance = GameManager.instance.dashDistanceAttackSequence3;
        this.dashDuration = GameManager.instance.dashDurationAttackSequence3;
    }

    public override void Enter()
    {
        Debug.Log("[State] attack 3 entered");

        playerController.debugComboAttack.text = "attack3";
        playerController.CanDash = false;

        // nyalain collidernya
        playerController.attackColliderObj3.SetActive(true);

        playerController.StartCoroutine(FinishCoroutine());
    }

    private IEnumerator FinishCoroutine()
    {
        // start sedikit dash nya
        playerController.StartCoroutine(playerController.MiniDashAttack(dashDistance, dashDuration));

        yield return new WaitForSeconds(endComboTime);
        playerStateMachine.ChangeState(playerController.idleState);
    }

    public override void LogicUpdate()
    {

    }

    public override void Exit()
    {
        Debug.Log("[State] attack3 exited");
        playerController.CanDash = true;

        // matiin lagi collidernya
        playerController.attackColliderObj3.SetActive(false);
    }
}
