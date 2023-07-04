using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    private LogicScript logic;
    private PlayerScript player;

    [SerializeField] float deadZone; // On the y-axis.
    [SerializeField] AudioSource collisionEffect;

    // Awake is called when the script instance is being loaded.
    private void Awake()
    {
        logic = GameObject.FindAnyObjectByType<LogicScript>();
        player = GameObject.FindAnyObjectByType<PlayerScript>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!logic.IsGameStarted || logic.IsGameOver)
        {
            return;
        }
        var currentDeadZone = player.getPosition().y + deadZone;
        if (transform.position.y > currentDeadZone)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.layer == 3)
        //{
            logic.decreasePies(1);
            collisionEffect.Play();
        //}
    }
}
