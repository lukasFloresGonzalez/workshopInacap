using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class Chase : Node
{
    private NavMeshAgent _agent;
    private Transform _player;
    private float _maxChaseDistance; 

    public Chase(NavMeshAgent agent, Transform player, float maxChaseDistance)
    {
        _agent = agent;
        _player = player;
        _maxChaseDistance = maxChaseDistance;
    }

    public override NodeState Evaluate()
    {
        float distanceToPlayer = Vector3.Distance(_agent.transform.position, _player.position);

        // Si el jugador está dentro de la distancia máxima, el enemigo lo sigue
        if (distanceToPlayer <= _maxChaseDistance)
        {
            _agent.SetDestination(_player.position);
            state = NodeState.RUNNING;
        }
        else
        {
            // Si el jugador está fuera de la distancia máxima, deja de perseguir
            state = NodeState.FAILURE;
        }

        return state;
    }
}
