using UnityEngine;
using BehaviorTree;

public class CheckPlayerInRange : Node
{
    private Transform _enemy;
    private Transform _player;
    private float _viewDistance;
    private float _viewAngle;
    private LayerMask _obstacleLayer;
    private float _maxChaseDistance;
    private Enemy _enemyScript;

    public CheckPlayerInRange(Transform enemy, Transform player, float viewDistance, float viewAngle, LayerMask obstacleLayer, float maxChaseDistance, Enemy enemyScript)
    {
        _enemy = enemy;
        _player = player;
        _viewDistance = viewDistance;
        _viewAngle = viewAngle;
        _obstacleLayer = obstacleLayer;
        _maxChaseDistance = maxChaseDistance;
        _enemyScript = enemyScript;
    }

    public override NodeState Evaluate()
    {
        object playerDetected = GetData("playerDetected");
        float distanceToPlayer = Vector3.Distance(_enemy.position, _player.position);

        if (playerDetected != null && (bool)playerDetected)
        {
            if (distanceToPlayer > _maxChaseDistance)
            {
                SetData("playerDetected", false);
                state = NodeState.FAILURE;
            }
            else
            {
                state = NodeState.SUCCESS;
            }
            return state;
        }

        Vector3 directionToPlayer = (_player.position - _enemy.position).normalized;

        if (distanceToPlayer <= _viewDistance &&
            Vector3.Angle(_enemy.forward, directionToPlayer) <= _viewAngle / 2)
        {
            if (Physics.Raycast(_enemy.position, directionToPlayer, out RaycastHit hit, _viewDistance, _obstacleLayer))
            {
                if (hit.transform == _player)
                {
                    SetData("playerDetected", true);
                    state = NodeState.SUCCESS;
                    return state;
                }
            }
        }

        state = NodeState.FAILURE;
        return state;
    }
}