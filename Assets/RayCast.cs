using UnityEngine;

/*public class RayCast : MonoBehaviour
{
    public int range;
    public Camera camera;
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
        {
            if(hit.collider.GetComponent<InteractableLights>() == true)
            {
                if(Input.GetKeyDown(KeyCode.E))
                {
                    if(hit.collider.GetComponent<InteractableLights>().light == true)
                    { 
                        hit.collider.GetComponent<InteractableLights>().OnOffLights();
                    }
                    
                }
            }
        }
        
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(camera.transform.position, camera.transform.forward * range);
    }
}
*/