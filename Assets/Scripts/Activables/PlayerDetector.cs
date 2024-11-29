using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    public bool InZone { get; private set; } = false; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) InZone = true;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) InZone = false;
    }
}
