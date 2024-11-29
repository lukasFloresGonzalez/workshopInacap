using UnityEngine;
using UnityEngine.AI;

public class PlayerControllerNav : MonoBehaviour
{
    public Camera camera;
    public NavMeshAgent agent;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition); 
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                agent.SetDestination(hit.point);
            }
        }
    }
}
