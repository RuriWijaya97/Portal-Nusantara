using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

[RequireComponent(typeof(PlayerMovementdupli))]
public class PlayerController : MonoBehaviour
{
    // butuh inputactionnyanya
    public InputActionReference attackAction; // input attacknya

    public PlayerStateMachine playerStateMachine {get; private set;} // statemachinenya

    // semua statenya
    public IdleState idleState;
    public AttackSequence1 attackSequence1;
    public AttackSequence2 attackSequence2;
    public AttackSequence3 attackSequence3;

    [Header("Debug Only")]
    public TextMeshProUGUI debugComboAttack;

    private void Awake() {
        // bikin state machinenya
        playerStateMachine = new PlayerStateMachine();

        // initialize idle state dulu
        idleState = new IdleState(this, playerStateMachine, attackAction);
        attackSequence1 = new AttackSequence1(this, playerStateMachine, attackAction);
        attackSequence2 = new AttackSequence2(this, playerStateMachine, attackAction);
        attackSequence3 = new AttackSequence3(this, playerStateMachine, attackAction);
    }

    private void Start() {
        playerStateMachine.Initialize(idleState);
    }

    private void OnEnable() {
        // aktifkan attacknya
        if (attackAction != null) attackAction.action.Enable();
    }

    private void OnDisable() {
        // matikin attacknya
        if (attackAction != null) attackAction.action.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        playerStateMachine.Update();
    }
}
