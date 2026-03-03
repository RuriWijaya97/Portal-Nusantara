using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AttackSequence3 : PlayerState
{
    private InputActionReference attackAction;
    private float endComboTime = 0.3f;

    // contructornya
    public AttackSequence3(PlayerController playerController, PlayerStateMachine playerStateMachine, InputActionReference attackAction) : base(playerController, playerStateMachine)
    {
        this.attackAction = attackAction;
    }

    public override void Enter()
    {
        Debug.Log("[State] attack 3 entered");
        playerController.debugComboAttack.text = "attack3";
        playerController.StartCoroutine(FinishCoroutine());
    }

    private IEnumerator FinishCoroutine()
    {
        yield return new WaitForSeconds(endComboTime);
        playerStateMachine.ChangeState(playerController.idleState);
    }

    public override void LogicUpdate()
    {
        
    }

    public override void Exit()
    {
        Debug.Log("[State] attack3 exited");
    }
}
