using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour {

    public List<GameObject> Enemies = new List<GameObject>();
    public int upperLimit = 4;
    public int lowerLimit = -3;

    // Use this for initialization
    void Start () {
   		InvokeRepeating ("NewEnemy", 0.0f, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void NewEnemy(){
        var enemyIndex = Random.Range(0, Enemies.Count);
        float position = Random.Range(lowerLimit, upperLimit);

        position = position > 0 ? position + .5f : position - .5f;

        var enemy = GameObject.Instantiate(Enemies[enemyIndex], new Vector3(transform.position.x, position, transform.position.z), transform.rotation);

        // There has to be a more graceful way to do this. Look into Quaternions.
        enemy.transform.Rotate(new Vector3(0, 0, 90)); 
    }
}
