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

        // Si el jugador est� dentro de la distancia m�xima, el enemigo lo sigue
        if (distanceToPlayer <= _maxChaseDistance)
        {
            _agent.SetDestination(_player.position);
            state = NodeState.RUNNING;
        }
        else
        {
            // Si el jugador est� fuera de la distancia m�xima, deja de perseguir
            state = NodeState.FAILURE;
        }

        return state;
    }
}
