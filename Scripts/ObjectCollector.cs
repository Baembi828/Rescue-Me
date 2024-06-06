using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    private List<GameObject> capturedObjects = new List<GameObject>();

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectible"))
        {
            // Disable physics on the captured object
            other.attachedRigidbody.isKinematic = true;

            // Attach the captured object to the game object
            other.transform.SetParent(transform);

            // Add the captured object to the list
            capturedObjects.Add(other.gameObject);
        }
    }

    // Release all captured objects
    public void ReleaseCapturedObjects()
    {
        foreach (GameObject obj in capturedObjects)
        {
            // Enable physics on the captured object
            obj.GetComponent<Rigidbody>().isKinematic = false;

            // Detach the captured object from the game object
            obj.transform.SetParent(null);
        }

        capturedObjects.Clear();
    }
}
