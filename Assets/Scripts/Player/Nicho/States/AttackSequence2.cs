using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackSequence2 : PlayerState
{
    // attackactionnya
    private InputActionReference attackAction;
    // timer combonya
    private float comboWaitTime = 0.35f;

    // contructornya
    public AttackSequence2(PlayerController playerController, PlayerStateMachine playerStateMachine, InputActionReference attackAction) : base(playerController, playerStateMachine)
    {
        this.attackAction = attackAction;
    }

    public override void Enter()
    {
        Debug.Log("[State] attack2 entered");
        playerController.debugComboAttack.text = "attack2";
        // start coroutinenya
        playerController.StartCoroutine(ComboCoroutine());
    }

    private IEnumerator ComboCoroutine()
    {
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
    }
}
