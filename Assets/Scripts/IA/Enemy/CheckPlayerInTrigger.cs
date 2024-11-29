using UnityEngine;
using BehaviorTree;

public class CheckPlayerInTrigger : Node
{
    private bool _playerInRange;

    public CheckPlayerInTrigger(Enemy enemy)
    {
        return;
    }

    public override NodeState Evaluate()
    {
        state = _playerInRange ? NodeState.SUCCESS : NodeState.FAILURE;
        return state;
    }
}
