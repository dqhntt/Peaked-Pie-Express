using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMover : MonoBehaviour
{
    private LogicScript logic;
    private PlayerScript player;

    [SerializeField] float moveSpeed;
    [SerializeField] float deadZone;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindAnyObjectByType<LogicScript>();
        player = GameObject.FindAnyObjectByType<PlayerScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.IsGameStarted || logic.IsGameOver)
        {
            return;
        }
        // Without deltaTime, it's moving (moveSpeed) units per frame.
        // With deltaTime, -> units per second.
        transform.position = transform.position + (Vector3.up * moveSpeed) * Time.deltaTime;

        var currentDeadZone = player.getPosition().y + deadZone;
        if (transform.position.y > currentDeadZone)
        {
            if (transform.tag != "DoNotDelete")
            {
                Destroy(gameObject);
            }
        }
    }
}
