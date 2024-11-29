using BehaviorTree;
using UnityEngine;
using System.Diagnostics;

public class CheckDoorClosed : Node
{
    //private Animator animator;

    public CheckDoorClosed()
    {
        //this.animator = animator;
    }

    public override NodeState Evaluate()
    {
        object doorOpen = GetData("doorOpen");
        if (doorOpen == null || !(bool)doorOpen)
        {
            //animator.SetBool("IsIdle", true);
            state = NodeState.SUCCESS;
            return state;
        }

        state = NodeState.FAILURE;
        return state;
    }
}