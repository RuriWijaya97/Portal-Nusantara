using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashState : PlayerState
{
    // seberapa jauh dia ngedash
    private float dashDistance;
    private float dashDuration;

    public DashState(PlayerController playerController, PlayerStateMachine stateMachine) : base(playerController, stateMachine)
    {
        this.dashDistance = GameManager.instance.dashDistanceDashState;
        this.dashDuration = GameManager.instance.dashDurationDashState;
    }

    public override void Enter()
    {
        Debug.Log("[State] dash entered");

        playerController.debugComboAttack.text = "dash";

        // pastikan attack collidernya nggak aktif pas idle
        playerController.attackColliderObj1.SetActive(false);
        playerController.attackColliderObj2.SetActive(false);
        playerController.attackColliderObj3.SetActive(false);

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
