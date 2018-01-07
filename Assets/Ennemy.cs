using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy : MonoBehaviour
{
    private Transform _Player;
    private bool run = false;
    public float attackdistance = 1.5f;

    public float _UpdateAI = 0.0f;
    public const float _UpdateAIPeriod = 0.3f;

    private bool _canattack = false;

    public float Life = 100f;

    public Transform DeathEffect;

    // Use this for initialization
    void Start()
    {
        _Player = GameObject.FindWithTag("Player").transform;
        _UpdateAI += Random.value;
        GetComponent<Rigidbody>().isKinematic = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Life <= 0)
        {
            Destroy(this.gameObject);
            Instantiate(DeathEffect, transform.position, Quaternion.identity);
            return;
        }

        _UpdateAI += Time.deltaTime;
        if (_UpdateAI > _UpdateAIPeriod)
        {
            _UpdateAI = 0.0f;
            NavMeshAgent na = GetComponent<NavMeshAgent>();
            na.SetDestination(_Player.position);

            run = (na.desiredVelocity.magnitude > 0.5f);
            GetComponentInChildren<Animator>().SetBool("Walk", run);

            Vector3 vecToPlayer = _Player.position - transform.position;
            float distToPlayer = vecToPlayer.magnitude;
            _canattack = distToPlayer < attackdistance;
            GetComponentInChildren<Animator>().SetBool("Attack", _canattack);

            //if (_canattack)
            //transform.LookAt(_Player);

            if (!na.enabled)
            {
                if (GetComponent<Rigidbody>().velocity.magnitude < 0.5f)
                {
                    GetComponent<NavMeshAgent>().enabled = true;
                    GetComponent<Rigidbody>().isKinematic = true;
                }
            }
        }
    }
    public void OnCollisionEnter(Collision c)
    {
        Harmful h = c.transform.GetComponent<Harmful>();
        if (h != null)
        {
            Life -= h.Damages;
            h.Damages = 0;

            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = false;
            GetComponent<Rigidbody>().AddForce(c.relativeVelocity / 3, ForceMode.Impulse);
        }
    }
}
