using UnityEditor;

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

namespace StarterAssets
{
    public class RagdollController : MonoBehaviour
    {
        //Animator, Capsule collider, and Third person controller to be disabled
        public CharacterController characterController;
        public Animator animator;
        public ThirdPersonController thirdPersonController;

        private bool isRagdol = false;
        private bool canRagdol = true;

        private GameObject[] ragdolParts;

        private GameObject foot;
        

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
        {
            ragdolParts = GameObject.FindGameObjectsWithTag("SkeletonRB");

            foot = GameObject.FindGameObjectWithTag("foot");
        }

        // Update is called once per frame
        void Update()
        {
        }

        public void Ragdol()
        {
            if (isRagdol)
            {
                
                DisableRagdol();

            }
            else if(!isRagdol && canRagdol)
            {

                EnableRagdoll();
            }
        }

        // Turn ragdoll on
        public void EnableRagdoll()
        {
            isRagdol = true;
            canRagdol = false;
            
            Vector3 velocityToApply= characterController.velocity;

            DisableMovement();
            animator.enabled = false;

            foreach (GameObject part in ragdolParts)
            {
                Rigidbody rb = part.GetComponent<Rigidbody>();
                rb.isKinematic = false;

                rb.linearVelocity = velocityToApply;

            }


        }

        public void DisableRagdol()
        {
            isRagdol = false;
            //Forcing the animator to play the recovery every time helps
            animator.Play("Recover");

            animator.SetBool("Trip", false);
            //animator.SetTrigger("Enter Recover");
            gameObject.transform.SetPositionAndRotation(foot.transform.position, transform.rotation);

            
            animator.enabled = true;



            foreach (GameObject part in ragdolParts)
            {
                part.GetComponent<Rigidbody>().isKinematic = true;
            }

            

        }

        // Called by method that starts ragdoll, and trip to prevent movement
        public void DisableMovement()
        {
            thirdPersonController.enabled = false;
            characterController.enabled = false;
        }

        // Called by recover animation so you cannot walk when moving
        public void EnableMovement()
        {
            characterController.enabled = true;
            thirdPersonController.enabled = true;
            canRagdol = true;


            characterController.SimpleMove(Vector3.zero);
        }
    }
}

