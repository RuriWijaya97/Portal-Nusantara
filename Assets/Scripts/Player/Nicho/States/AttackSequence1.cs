using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackSequence1 : PlayerState
{
    // reference ke attack actionnya
    private InputActionReference attackAction;
    // wait time untuk ke attacksequence2
    private float comboWaitTime = 0.4f;

    // contructornya
    public AttackSequence1(PlayerController playerController, PlayerStateMachine playerStateMachine, InputActionReference attackAction) : base(playerController, playerStateMachine)
    {
        this.attackAction = attackAction;
    }

    public override void Enter()
    {
        Debug.Log("[State] attack1 entered");
        playerController.debugComboAttack.text = "attack1";
        playerController.StartCoroutine(ComboCoroutine());
    }

    private IEnumerator ComboCoroutine()
    {
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
    }
}
