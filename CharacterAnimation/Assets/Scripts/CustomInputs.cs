using StarterAssets;
using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CustomInputs : MonoBehaviour
{
    RagdollController ragdollController;

    Animator animator;

    bool isLookMode = false;
    bool twistingLeft = false;
    bool twistingRight = false;


    int degreesTwisted = 90;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ragdollController = gameObject.GetComponent<RagdollController>();
        animator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        if (isLookMode)
        {
            if (twistingLeft)
            {
                Debug.Log("Twisting Left!");
                degreesTwisted -= 1;
            }
            else if (twistingRight)
            {
                degreesTwisted += 1;
            }

            if (degreesTwisted > 180)
            {
                degreesTwisted = 180;
            }
            else if (degreesTwisted < 0)
            {
                degreesTwisted = 0;
            }

            animator.SetFloat("Angle", degreesTwisted);
        }

    }

    public void OnRagdol()
    {
        ragdollController.Ragdol();
    }
    
    public void OnTrip()
    {
        animator.SetBool("Trip", true);
    }

    public void OnLookMode()
    {
        if(!isLookMode)
        {
            ragdollController.DisableMovement();
            animator.SetBool("LookMode", true);
            degreesTwisted = 90;
            isLookMode = true;
        }
        else
        {
            ragdollController.EnableMovement();
            animator.SetBool("LookMode", false);
            isLookMode = false;
        }

    }

    public void OnTwistLeft(InputValue value)
    {
        if (value.Get<float>() >= 1f)
        {
            twistingLeft = true;

        }
        else
        {
            twistingLeft = false;

        }

    }

    public void OnTwistRight(InputValue value)
    {
        if (value.Get<float>() >= 1f)
        {
            twistingRight = true;
        }
        else
        {
            twistingRight = false;
        }
    }

}
