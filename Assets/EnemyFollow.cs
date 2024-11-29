using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFollowAdvanced : MonoBehaviour
{
    public Transform target;
    public float updateSpeed = 0.1f;
    public float visionRange = 15f;
    public float lostSightTime = 5f;

    private NavMeshAgent agent;
    private float timeSinceLastSeen = 0f;
    private Vector3 lastKnownPosition;
    private enum State { Patrol, Chase, Search }
    private State currentState;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        currentState = State.Patrol;
        StartCoroutine(StateMachine());
    }

    private IEnumerator StateMachine()
    {
        while (true)
        {
            switch (currentState)
            {
                case State.Patrol:
                    Patrol();
                    break;
                case State.Chase:
                    Chase();
                    break;
                case State.Search:
                    Search();
                    break;
            }
            yield return new WaitForSeconds(updateSpeed);
        }
    }

    private void Patrol()
    {
        // Patrullar en un camino predeterminado
        if (!agent.hasPath)
        {
            Vector3 randomPoint = RandomNavmeshLocation(20f);
            agent.SetDestination(randomPoint);
        }

        if (Vector3.Distance(transform.position, target.position) < visionRange)
        {
            currentState = State.Chase;
        }
    }

    private void Chase()
    {
        agent.SetDestination(target.position);
        timeSinceLastSeen = 0f;

        if (Vector3.Distance(transform.position, target.position) > visionRange)
        {
            timeSinceLastSeen += updateSpeed;
            if (timeSinceLastSeen >= lostSightTime)
            {
                lastKnownPosition = target.position;
                currentState = State.Search;
            }
        }
    }

    private void Search()
    {
        agent.SetDestination(lastKnownPosition);

        if (Vector3.Distance(transform.position, lastKnownPosition) < 1f)
        {
            currentState = State.Patrol;
        }

        if (Vector3.Distance(transform.position, target.position) < visionRange)
        {
            currentState = State.Chase;
        }
    }

    private Vector3 RandomNavmeshLocation(float radius)
    {
        Vector3 randomDirection = Random.insideUnitSphere * radius;
        randomDirection += transform.position;
        if (NavMesh.SamplePosition(randomDirection, out NavMeshHit hit, radius, 1))
        {
            return hit.position;
        }
        return transform.position;
    }
}
