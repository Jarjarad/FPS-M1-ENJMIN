using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public Transform EvilToSpawn;
    private float TimerSpawn = 0.0f;
    public float TimeSpawn = 3.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        TimerSpawn += Time.deltaTime;
        if(TimerSpawn > TimeSpawn)
        {
            TimerSpawn = 0.0f;
            Instantiate(EvilToSpawn, transform.position, Quaternion.identity);
        }

    }
}
