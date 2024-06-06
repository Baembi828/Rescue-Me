using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartAnimation : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    private void Start()
    {
        // Check if the animator reference is assigned
        if (animator != null)
        {
            // Trigger the animation to start playing
            animator.SetTrigger("StartAnimation");
        }
    }
}
