using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

public class CustomInputs : MonoBehaviour
{
    RagdollController ragdollController;

    Animator animator;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ragdollController = gameObject.GetComponent<RagdollController>();
        animator = gameObject.GetComponent<Animator>();
    }
    public void OnRagdol()
    {
        ragdollController.Ragdol();
    }
    
    public void OnTrip()
    {
        animator.SetBool("Trip", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
