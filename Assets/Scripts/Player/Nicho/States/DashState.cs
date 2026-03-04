using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerState
{
    // seberapa jauh dia ngedash
    private float dashDistance = 3f;
    private float dashDuration = 0.15f;

    public DashState(PlayerController playerController, PlayerStateMachine stateMachine) : base(playerController, stateMachine)
    {
        
    }

    public override void Enter()
    {
        Debug.Log("[State] dash entered");
        // start sedikit dash nya
        playerController.StartCoroutine(DashCoroutine());
    }

    private IEnumerator DashCoroutine()
    {
        yield return playerController.StartCoroutine(playerController.MiniDashAttack(dashDistance, dashDuration));
        // balik ke idle state
        playerStateMachine.ChangeState(playerController.idleState);
    }
}
