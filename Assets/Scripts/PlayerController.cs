using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float movementSpeed = 0.5f;
    public Vector3 spawnPoint = new Vector3(-4.5f, 0, 0);
    public float movementDelayTime = 0.1f;

    private float movementTimer = 0.0f;
    private Bounds boundary = new Bounds(Vector3.zero, new Vector3(10,10,0));

    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (movementTimer >= movementDelayTime)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
                Movement(vertical: movementSpeed);
            else if (Input.GetKeyDown(KeyCode.DownArrow))
                Movement(vertical: -movementSpeed);
            else if (Input.GetKeyDown(KeyCode.RightArrow))
                Movement(horizontal: movementSpeed);
            else if (Input.GetKeyDown(KeyCode.LeftArrow))
                Movement(horizontal: -movementSpeed);
        }

        movementTimer += Time.deltaTime;
    }

    private void Movement(float horizontal = 0, float vertical = 0)
    {
        var newPosition = new Vector3(
            transform.position.x + horizontal,
            transform.position.y + vertical,
            transform.position.z);
        if (Physics.Raycast(transform.position, horizontal == 0 ? Vector3.up : Vector3.left, movementSpeed) == false)
        {
            gameObject.GetComponent<Rigidbody2D>().MovePosition(newPosition);
        }

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
