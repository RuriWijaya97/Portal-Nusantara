using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IdleState : PlayerState
{
    // attack actionnya
    private InputActionReference attackAction;

    // constructornya
    public IdleState(PlayerController playerController, PlayerStateMachine stateMachine, InputActionReference attackAction) : base(playerController, stateMachine)
    {
        this.attackAction = attackAction;
    }

    public override void Enter()
    {
        Debug.Log("[State] idle entered");
        playerController.debugComboAttack.text = "idle";
    }

    public override void LogicUpdate()
    {
        // kalau misalkan attack pressed maka pindah ke attacksequence1
        if (attackAction != null && attackAction.action != null && attackAction.action.triggered)
        {
            Debug.Log("[Input] attack pressed, go to attacksequence1");
            playerStateMachine.ChangeState(new AttackSequence1(playerController, playerStateMachine, attackAction));
        }
    }

    public override void Exit()
    {
        Debug.Log("[State] idle exited");
    }
}
