using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterCollision : MonoBehaviour {

    private bool destroyWhenOutOfSight = false;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (destroyWhenOutOfSight)
        {
            //Direction de la balle
            Vector3 dirBalle = transform.position - Camera.main.transform.position;
            if(Mathf.Abs(Vector3.Angle(dirBalle,Camera.main.transform.forward)) > 90)
            {
                Destroy(this.gameObject);
            }
            
        }

        if(transform.position.y < -100)
            Destroy(this.gameObject);

    }

    public void OnCollisionEnter(Collision col)
    {
        destroyWhenOutOfSight = true;
        GetComponent<AudioSource>().Play();
    }
}
