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

        public void OnRagdol()
        {
            if (isRagdol)
            {
                isRagdol = false;
                DisableRagdol();

            }
            else
            {
                isRagdol = true;
                EnableRagdoll();
            }
        }

        // Turn ragdoll on
        public void EnableRagdoll()
        {
            Vector3 velocityToApply= characterController.velocity;

            thirdPersonController.enabled = false;
            characterController.enabled = false;
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
            gameObject.transform.SetPositionAndRotation(foot.transform.position, transform.rotation);

            animator.enabled = true;
            characterController.enabled = true;
            thirdPersonController.enabled = true;

            characterController.SimpleMove(Vector3.zero);

            foreach (GameObject part in ragdolParts)
            {
                part.GetComponent<Rigidbody>().isKinematic = true;
            }

            

        }
    }
}

