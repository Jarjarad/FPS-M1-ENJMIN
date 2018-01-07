using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class MiaouRandom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        GetComponent<AudioSource>().pitch = Random.Range(0.2f, 1.8f);
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<AudioSource>().pitch = GetComponent<Rigidbody>().velocity.magnitude;
    }
}
