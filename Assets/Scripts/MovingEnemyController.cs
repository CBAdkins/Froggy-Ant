using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingEnemyController : MonoBehaviour {

    public float speed = 5.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * Time.deltaTime * speed ;
	}

	/// <summary>
	/// Sent when another object enters a trigger collider attached to this
	/// object (2D physics only).
	/// </summary>
	/// <param name="other">The other Collider2D involved in this collision.</param>
	void OnTriggerEnter2D(Collider2D other)
	{
        if(other.GetComponent<PlayerController>() != null)
		{
            other.GetComponent<PlayerController>().Die();
        }
    }

	/// <summary>
	/// OnBecameInvisible is called when the renderer is no longer visible by any camera.
	/// </summary>
	void OnBecameInvisible()
	{
        Destroy(gameObject);
    }
}
