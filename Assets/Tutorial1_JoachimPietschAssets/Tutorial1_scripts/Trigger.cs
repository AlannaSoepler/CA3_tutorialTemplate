using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Trigger : MonoBehaviour
{
    // Targets are only active when the player is inside
    // the trigger and overrides the setting of action.
    public TriggerAction action = TriggerAction.Activate;
    public Triggerable[] targets;

    void OnTriggerEnter (Collider other)
    {
        //only trigger with player collisions
        if (other.CompareTag("Player"))
        {
           TriggerTargets();
        }
    }
   
    public void TriggerTargets ()
    {
        //we are looping through the Triggerable list
        //and activate all objects
        
        foreach (Triggerable t in targets)
            {
                // Check in case a target is destroyed
                if (t != null)
                {
                    t.Trigger(action);
                }
            }
         
    }

    //Gizmos - draws a box for the invisible trigger
    void OnDrawGizmos ()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawCube(transform.position, Vector3.one);
        
    }

    //Gizmos - draws connecting to each triggerable object that gets activated. 
    //when selected in scene view.
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(transform.position, Vector3.one * 0.5f);

        if (targets != null)
        {
            foreach (Triggerable t in targets)
            {
                if (t != null)
                {
                    Gizmos.DrawLine(transform.position, t.transform.position);
                }
            }
        }        
    }
}
