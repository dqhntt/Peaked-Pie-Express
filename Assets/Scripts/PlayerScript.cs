using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    private LogicScript logic;
    private Rigidbody2D playerRigidbody;

    private float leftEdge, rightEdge; // Taken from background spawner.

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindAnyObjectByType<LogicScript>();
        playerRigidbody = GetComponent<Rigidbody2D>();

        var spawner = GameObject.FindAnyObjectByType<BackgroundSpawnerScript>();
        leftEdge = spawner.LeftEdge;
        rightEdge = spawner.RightEdge;
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.IsGameStarted || logic.IsGameOver) {
            playerRigidbody.velocity = Vector2.zero;
            return;
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerRigidbody.velocity = Vector2.left * 5;
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerRigidbody.velocity = Vector2.right * 5;
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            // Maybe slow down?
        }

        // Fences have their own colliders so these may not be needed.
        if (transform.position.x < leftEdge)
        {
            playerRigidbody.velocity = Vector2.right;
        }
        else if (transform.position.x > rightEdge)
        {
            playerRigidbody.velocity = Vector2.left;
        }
    }

    public Vector3 getPosition()
    {
        return transform.position;
    }
}
