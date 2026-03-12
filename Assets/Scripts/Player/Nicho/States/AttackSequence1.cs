using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackSequence1 : PlayerState
{
    // reference ke attack actionnya
    private InputActionReference attackAction;
    // wait time untuk ke attacksequence2
    private float comboWaitTime;

    // seberapa jauh dia ngedash
    private float dashDistance;
    private float dashDuration;

    // contructornya
    public AttackSequence1(PlayerController playerController, PlayerStateMachine playerStateMachine, InputActionReference attackAction) : base(playerController, playerStateMachine)
    {
        this.attackAction = attackAction;
        this.comboWaitTime = GameManager.instance.waitTimeAttackSequence1;
        this.dashDistance = GameManager.instance.dashDistanceAttackSequence1;
        this.dashDuration = GameManager.instance.dashDurationAttackSequence1;
    }

    public override void Enter()
    {
        Debug.Log("[State] attack1 entered");

        playerController.debugComboAttack.text = "attack1";
        playerController.CanDash = false;

        // nyalain collidernya
        playerController.attackColliderObj1.SetActive(true);

        playerController.StartCoroutine(ComboCoroutine());
    }

    private IEnumerator ComboCoroutine()
    {
        // start sedikit dash nya
        playerController.StartCoroutine(playerController.MiniDashAttack(dashDistance, dashDuration));

        // buang 1 frame dari idle biar nggak kedetect masih di pressed
        yield return null;

        // apakah ke sequence berikutnya
        bool isQueued = false;
        float timer = comboWaitTime; // set timernya dulu

        while (timer > 0f) // selama timernya masih ada
        {
            // kalau attacknya diteken lagi maka queue
            if (attackAction != null && attackAction.action != null && attackAction.action.triggered)
            {
                isQueued = true;
                Debug.Log("[Combo] queued to attack 2");
            }

            timer -= Time.deltaTime;
            yield return null;
        }

        if (isQueued) playerStateMachine.ChangeState(playerController.attackSequence2);
        else playerStateMachine.ChangeState(playerController.idleState);
    }

    public override void LogicUpdate()
    {

    }

    public override void Exit()
    {
        Debug.Log("[State] attack1 exited");
        playerController.CanDash = true;

        // matiin lagi collidernya
        playerController.attackColliderObj1.SetActive(false);
    }
}
