using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {

    public float RateOfFire = 2.0f;
    public Transform Projectile;
    public Transform Socket;

    private float TimerShoot = 0.0f;

	// Use this for initialization
	void Start () {
        if (Projectile == null)
            Debug.LogError("Pas de projectile pour le joueur");
    }
	
	// Update is called once per frame
	void Update () {
        TimerShoot += Time.deltaTime;

        if (Input.GetButton("Fire1") && TimerShoot > 1.0f / RateOfFire && GetComponent<PlayerData>().GetAmmo() > 0)
        {
            TimerShoot = 0.0f;

            Vector3 shootPosition = Camera.main.transform.position + Camera.main.transform.forward * 2.0f;
            if (Socket != null)
                shootPosition = Socket.position;

            Debug.Log(Socket.position);

            Transform balle = Instantiate(Projectile,
                shootPosition,
                Camera.main.transform.rotation
                ) as Transform;
            Rigidbody rb = balle.GetComponent<Rigidbody>();
            rb.AddForce(Camera.main.transform.forward*40,ForceMode.Impulse);

            GetComponent<PlayerData>().UseAmmo(1);
        }
	}
}
