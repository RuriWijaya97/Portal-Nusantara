public abstract class PlayerState
{
    // reference ke player controllernya
    protected PlayerMovement playerMovement;

    // reference ke player state machinenya
    protected PlayerStateMachine playerStateMachine;

    // constructornya
    public PlayerState(PlayerMovement playerMovement, PlayerStateMachine stateMachine)
    {
        this.playerMovement = playerMovement;
        this.playerStateMachine = stateMachine;
    }

    // blueprint methodnya
    public virtual void Enter(){}
    public virtual void LogicUpdate(){}
    public virtual void Exit(){}
}
