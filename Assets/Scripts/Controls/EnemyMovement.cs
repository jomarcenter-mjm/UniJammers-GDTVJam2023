using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float movementSpeed = 3f; // Speed of enemy movement
    public float wobbleDuration = 0.5f; // Duration of wobble off course
    public float wobbleMagnitude = 1f; // Magnitude of wobble off course

    private Transform player; // Reference to the player's Transform
    private Vector3 originalDirection; // Original direction towards the player
    private bool isWobbling = false; // Flag to track wobbling state
    private float wobbleTimer = 0f; // Timer for wobbling duration
    private float nextWobbleTime = 0f; // Time for the next wobble

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; // Find the player's GameObject by tag
        originalDirection = (player.position - transform.position).normalized; // Calculate original direction towards the player
        CalculateNextWobbleTime(); // Calculate the time for the next wobble
    }

    private void Update()
    {
        if (isWobbling)
        {
            // Perform wobbling off course
            transform.position += (originalDirection + Random.insideUnitSphere * wobbleMagnitude) * movementSpeed * Time.deltaTime;
            wobbleTimer -= Time.deltaTime;

            if (wobbleTimer <= 0f)
            {
                // Reset back to tracking the player after wobble duration expires
                isWobbling = false;
                CalculateNextWobbleTime(); // Calculate the time for the next wobble
            }
        } else
        {
            // Calculate the direction towards the player
            Vector3 directionToPlayer = (player.position - transform.position).normalized;

            // Move towards the player
            transform.position += directionToPlayer * movementSpeed * Time.deltaTime;
            transform.LookAt(player.position);
            // Check if it's time for the next wobble
            if (Time.time >= nextWobbleTime)
            {
                // Initiate wobble
                isWobbling = true;
                wobbleTimer = wobbleDuration;
            }
        }
    }

    private void CalculateNextWobbleTime()
    {
        // Generate a random interval for the next wobble
        float randomInterval = Random.Range(1f, 5f);
        nextWobbleTime = Time.time + randomInterval;
    }
}

