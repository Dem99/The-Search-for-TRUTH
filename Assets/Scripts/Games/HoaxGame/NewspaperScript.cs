using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewspaperScript : MonoBehaviour
{
    public Rigidbody2D myRigidbody;
    public float flapStrenght;
    public LogicScript logic;
    public bool playerDied = false;

    // Start is called before the first frame update
    void Start()
    {
        logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !playerDied)
        {
            myRigidbody.velocity = Vector2.up * flapStrenght;
        }
        if(transform.position.y > 6.1 || transform.position.y < -6.5)
        {
            logic.gameOver();
            playerDied = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        logic.gameOver();
        playerDied = true;
    }
}
