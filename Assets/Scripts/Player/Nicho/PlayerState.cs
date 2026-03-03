public abstract class PlayerState
{

    // reference ke player state machinenya
    protected PlayerStateMachine playerStateMachine;

    // reference ke playercontrollernya
    protected PlayerController playerController;

    // constructornya
    public PlayerState(PlayerController playerController, PlayerStateMachine stateMachine)
    {
        this.playerController = playerController;
        this.playerStateMachine = stateMachine;
    }

    // blueprint methodnya
    public virtual void Enter(){}
    public virtual void LogicUpdate(){}
    public virtual void Exit(){}
}
