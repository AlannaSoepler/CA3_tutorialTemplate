using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MoveToPosition : MonoBehaviour
{
    public float knockbackTime = 1;
    public float kick = 1.8f;
    
    private Transform goal;
    private NavMeshAgent agent;

    private bool hit;
    private ContactPoint contact;
    private float timer;


    // Start is called before the first frame update
    void Start()
    
    
    {
        //we cannot attach GameObject Player in Inspector when spawning
        //so we use code instead.
        goal = GameObject.FindGameObjectWithTag("Player").transform;
        agent = GetComponent<NavMeshAgent>();  
        timer = knockbackTime;  
        
    }

    void Update() {
        if (hit) {
            //allow physics to be applied
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
            //disable navmesh seeking behaviour
            gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            //apply force
            gameObject.GetComponent<Rigidbody>().AddForceAtPosition(Camera.main.transform.forward * kick, contact.point, ForceMode.Impulse);
            hit = false;
            timer = 0;

        } else {
            timer += Time.deltaTime;
            //after being knocked back restart Navmesh movement
            if (knockbackTime < timer) {
                gameObject.GetComponent<Rigidbody>().isKinematic = true;
                //enable navmesh seeking behaviour
                gameObject.GetComponent<NavMeshAgent>().isStopped = false;
                //restart seeking behaviour
                agent.SetDestination(goal.position);
            

            }
        }

       
    }

    void OnCollisionEnter(Collision other) {
        if (other.transform.CompareTag("bullet")) 
        {
            contact = other.contacts[0];
            hit = true; 
        }
    }


}
