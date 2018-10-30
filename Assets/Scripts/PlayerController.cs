using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float movementSpeed = 0.5f;
    public Vector3 spawnPoint = new Vector3(-4.5f, 0, 0);
    public float movementDelayTime = 0.1f;

    private float movementTimer = 0.0f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (movementTimer >= movementDelayTime)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Movement(Vector2.up, vertical: movementSpeed);
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                Movement(Vector2.down, vertical: -movementSpeed);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                Movement(Vector2.right, horizontal: movementSpeed);
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                Movement(Vector2.left, horizontal: -movementSpeed);
        }

        movementTimer += Time.deltaTime;
    }

    private void Movement(Vector2 direction, float horizontal = 0, float vertical = 0)
    {
        var newPosition = new Vector2(
            transform.position.x + horizontal,
            transform.position.y + vertical);
        var position2D = new Vector2(transform.position.x, transform.position.y);

        var hit = Physics2D.Raycast(position2D, direction, movementSpeed);

        if (hit.collider != null)
        {
            print("There is something in front of the object!");
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().MovePosition(newPosition);
        }

        /*if (Physics.Raycast(transform.position, horizontal == 0 ? Vector3.up : Vector3.left, movementSpeed) == false)
        {
            gameObject.GetComponent<Rigidbody2D>().MovePosition(newPosition);
        } */

        movementTimer = 0.0f;
    }
    /* if(boundary.Contains(newPosition)){
        gameObject.GetComponent<Rigidbody2D>().MovePosition(newPosition);
        // transform.position = newPosition;
    }
} */

    public void Die()
    {
        transform.position = spawnPoint;
    }
}
