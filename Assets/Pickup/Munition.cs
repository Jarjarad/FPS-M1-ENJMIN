using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Munition : MonoBehaviour {
    private bool alreadyUsed = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.name == "Player" && !alreadyUsed)
        {
            PlayerData s = c.transform.GetComponent<PlayerData>();
            s.AddAmmo(10);

            GetComponent<Animator>().SetTrigger("pickup");
            alreadyUsed = true;
        }
    }

}
