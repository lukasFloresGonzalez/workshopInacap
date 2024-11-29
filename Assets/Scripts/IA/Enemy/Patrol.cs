using UnityEngine;
using UnityEngine.AI;
using BehaviorTree;

public class Patrol : Node
{
    private NavMeshAgent _agent;
    private Transform[] _waypoints;
    private int _currentWaypointIndex = 0;
    private Transform _player;
    //private Animator _animator;

    public Patrol(NavMeshAgent agent, Transform[] waypoints, Transform player)
    {
        _agent = agent;
        _waypoints = waypoints;
        _player = player;
        //_animator = animator;
    }

    public override NodeState Evaluate()
    {

        if (_waypoints == null || _waypoints.Length == 0)
        {
            Debug.LogWarning("No hay waypoints asignados al Patrol.");
            state = NodeState.FAILURE;
            return state;
        }


        if (_agent.remainingDistance <= _agent.stoppingDistance)
        {
            _currentWaypointIndex = (_currentWaypointIndex + 1) % _waypoints.Length;
            _agent.SetDestination(_waypoints[_currentWaypointIndex].position);
        }

        
        /*if (_animator != null)
        {
            if (_agent.velocity.magnitude > 0.1f) 
            {
                _animator.SetBool("isIdle", false);
            }
            else  
            {
                _animator.SetBool("isIdle", true);   
            }
        }
    */


        if (_player != null)
        {
            Vector3 direction = (_player.position - _agent.transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            _agent.transform.rotation = Quaternion.Slerp(_agent.transform.rotation, lookRotation, Time.deltaTime * 5f);
        }

        state = NodeState.RUNNING;
        return state;
    }
}