using UnityEngine;

public class UIRotation : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 1.0f;
    public float waitTimeBeforeRotation = 3.0f;

    private float timeSinceLastLookedAt = 0.0f;
    private bool isRotating = false;
    private Quaternion targetRotation;

    void Update()
    {
        // The position of the UI is set to be the same as the player
        transform.position = player.position;

        Vector3 directionToPlayer = player.position - transform.position;
        directionToPlayer.y = 0; // ensure rotation occurs only in horizontal plane

        // Check if the player is looking at the UI
        if (Vector3.Dot(player.forward, -directionToPlayer.normalized) > 0.5f) // 0.5f is an arbitrary value, adjust it based on your needs
        {
            timeSinceLastLookedAt = 0.0f;
            isRotating = false;
        }
        else
        {
            timeSinceLastLookedAt += Time.deltaTime;
        }

        // If the player hasn't been looking at the UI for a while and the UI is not currently rotating, start rotating the UI to face the player
        if (timeSinceLastLookedAt > waitTimeBeforeRotation && !isRotating)
        {
            isRotating = true;
            targetRotation = Quaternion.LookRotation(-directionToPlayer);
            //targetRotation.y -= 90;
        }

        if (!isRotating)
        {
            transform.rotation = targetRotation;
        }
        else
        {
            // Rotate the UI to face the player
            if (isRotating)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

                // If the UI has finished rotating, stop the rotation
                if (Quaternion.Angle(transform.rotation, targetRotation) < 0.01f)
                {
                    isRotating = false;
                }
            }
        }
    }
}