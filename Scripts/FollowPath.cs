using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public float rotationSpeed = 180.0f;
    public float speed = 5.0f;
    public float maxDistancePerPath = 5.0f; // Maximum distance from the first point of the path to follow
    private List<Vector3> pathPoints = new List<Vector3>();
    private int currentTargetIndex = -1;
    private float distance = 0.0f;
    private bool isDrawingPath = false;
    private bool isPlayerFollowingPath = false;

    private void Update()
    {
        if (!isPlayerFollowingPath && Input.GetMouseButtonDown(0))
        {
            if (!isDrawingPath)
            {
                isDrawingPath = true;

                // Pause everything else in the game
                Time.timeScale = 0;

                pathPoints.Clear();
                pathPoints.Add(Camera.main.ScreenToWorldPoint(Input.mousePosition));
                currentTargetIndex = 0;
                distance = 0.0f;
            }
        }

        if (isDrawingPath && Input.GetMouseButton(0))
        {
            Vector3 lastPoint = pathPoints[pathPoints.Count - 1];
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Vector3.Distance(lastPoint, mousePosition) > 0.1f)
            {
                pathPoints.Add(mousePosition);
            }
        }

        if (isDrawingPath && Input.GetMouseButtonUp(0))
        {
            isDrawingPath = false;
            StartCoroutine(MoveAlongPath());
        }
    }

    IEnumerator MoveAlongPath()
    {
        isPlayerFollowingPath = true;

        Vector3 firstPoint = pathPoints[0];
        distance = 0.0f;
        bool startedMoving = false;  // Flag to check if object has started moving
        for (int i = 1; i < pathPoints.Count; i++)
        {
            distance += Vector3.Distance(pathPoints[i - 1], pathPoints[i]);
            if (distance > maxDistancePerPath)
            {
                break;
            }

            currentTargetIndex = i;
            Vector3 currentTarget = pathPoints[currentTargetIndex];
            while (Vector3.Distance(transform.position, currentTarget) > 0.01f)
            {
                Time.timeScale = 1;
                if (!startedMoving)
                {
                    // Start moving at the normal speed
                    transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
                    startedMoving = true;
                }
                else
                {
                    // Move at the normal speed
                    transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
                }

                Quaternion targetRotation = Quaternion.LookRotation(Vector3.forward, currentTarget - transform.position);
                transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
                yield return null;
            }
            distance = 0.0f;
        }

        currentTargetIndex = -1;
        isPlayerFollowingPath = false;

        // Pause everything else in the game
        Time.timeScale = 0;
    }

    private void OnDestroy()
    {
        Debug.Log("Object destroyed: " + gameObject.name);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Collectible"))
        {
            Destroy(collider.gameObject);
        }
        else if (collider.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}