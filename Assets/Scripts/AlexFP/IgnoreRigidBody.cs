using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IgnoreRigidBody : MonoBehaviour
{
    public Animator animator;

    public float distance = 2f;

    public GameObject currentHitObject;

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {

        RaycastHit hit;

        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distance))
        {
            Debug.Log("HIT SOMETHING");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.red);

            currentHitObject = hit.transform.gameObject;
            if (currentHitObject.tag == "Doors")
            {
                agent.isStopped = true;
                animator.SetBool("isChasing", false);
            }
            else
            {
                agent.isStopped = false;
            }
        }
        else
        {
            Debug.Log("HIT NOTHING");
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * distance, Color.green);

        }
    }

}
