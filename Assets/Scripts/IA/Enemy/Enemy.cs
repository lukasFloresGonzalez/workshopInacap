using System.Collections.Generic;
using BehaviorTree;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : BehaviorTree.Tree
{
    public Transform[] waypoints;
    public Transform player;
    float maxChaseDistance = 15f;
    private NavMeshAgent agent;
    public float chaseDistance = 10f;

    private bool isChasing = false;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    protected override Node SetupTree()
    {
        float viewDistance = 10f;
        float viewAngle = 90f;
        LayerMask obstacleLayer = LayerMask.GetMask("Default", "Obstacles");

        Node checkDoorClosed = new CheckDoorClosed();
        Node checkDoorOpen = new CheckDoorOpen();
        Node checkPlayerInRange = new CheckPlayerInRange(transform, player, viewDistance, viewAngle, obstacleLayer, maxChaseDistance, this);
        Node chaseNode = new Chase(agent, player, maxChaseDistance);
        Node patrolNode = new Patrol(agent, waypoints, player);

        Sequence chaseSequence = new Sequence(new List<Node> { checkDoorOpen, checkPlayerInRange, chaseNode });

        Node root = new Selector(new List<Node>
        {
            checkDoorClosed,
            new Selector(new List<Node> { chaseSequence, patrolNode })
        });

        return root;
    }
}