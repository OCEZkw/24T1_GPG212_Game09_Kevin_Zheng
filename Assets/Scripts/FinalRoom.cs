using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalRoom : MonoBehaviour
{
    public float bounceForce = 5f; // The force applied to the player
    private Rigidbody2D playerRigidbody;
    private bool isColliding;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Inventory inventory = collision.GetComponent<Inventory>();
            if (inventory != null && inventory.GetItemCount("Time Ticket") < 2)
            {
                isColliding = true;
                playerRigidbody = collision.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null)
                {
                    Vector2 bounceDirection = -Vector2.up; // Bounce downward
                    playerRigidbody.velocity = Vector2.zero; // Stop player's current movement
                    playerRigidbody.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
                }
            }
            else
            {
                isColliding = false;
                // Player has enough time tickets, allow entry
                // For example, load a new scene
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isColliding = false;
        }
    }

    private void FixedUpdate()
    {
        if (isColliding && playerRigidbody != null)
        {
            // Apply a downward force to the player while they are colliding with the door
            Vector2 bounceDirection = -Vector2.up; // Bounce downward
            playerRigidbody.AddForce(bounceDirection * bounceForce, ForceMode2D.Impulse);
        }
    }
}