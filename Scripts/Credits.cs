using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject panel;
    

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Check if the panel is active
// Hide the panel
                panel.SetActive(false);
                
        }
    }
}
