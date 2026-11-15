using UnityEditor;

using UnityEngine;
using UnityEngine.Rendering;

namespace StarterAssets
{
    public class RagdollController : MonoBehaviour
    {
        //Animator, Capsule collider, and Third person controller to be disabled
        public CharacterController characterController;
        public Animator animator;
        public Component thirdPersonController;
        

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        // Turn ragdoll on
        public void EnnableRagdoll()
        {
            characterController.enabled = false;
            animator.enabled = false;
    
    }
    }
}

