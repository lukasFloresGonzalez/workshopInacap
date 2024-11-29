using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activable : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private PlayerDetector playerDetector;
    [SerializeField] private bool active = false;

    public string activateTrigger;
    public AudioClip activateSound; 
    private AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.playOnAwake = false; 
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerDetector.InZone)
        {
            Debug.Log("hola");
            if (CompareTag("Object"))
            {
                Destroy(gameObject);
            }
            else
            {
                Activate();
            }
        }
    }

    private void Activate()
    {
        if (activateSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(activateSound);
        }
    }
}
