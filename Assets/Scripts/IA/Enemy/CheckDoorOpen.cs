using BehaviorTree;
using UnityEngine;
using System.Diagnostics;

public class CheckDoorOpen : Node
{
    private Animator animator;
    private float delay = 3.0f; 
    private float timer;

    
    public CheckDoorOpen()
    {
        //this.animator = animator;
        timer = 0f;
    }
    

    public override NodeState Evaluate()
    {
        object doorOpen = GetData("doorOpen");
        if (doorOpen != null && (bool)doorOpen)
        {

            return NodeState.RUNNING;
        }

        timer = 0f;
        state = NodeState.FAILURE;
        return state;
    }
}
