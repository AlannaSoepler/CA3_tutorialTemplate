using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(MeshRenderer))]

public class Switch : MonoBehaviour
{
    public TriggerAction action = TriggerAction.Trigger;
    public Triggerable[] targets;

    public Material activeMaterial;
    public Material inactiveMaterial;

    private MeshRenderer _renderer;
    private bool pressed = false;

    void Awake ()
    {
        _renderer = GetComponent<MeshRenderer>();
        //apply active material to the renderer
        _renderer.sharedMaterial = activeMaterial;
    }


    void OnCollisionEnter (Collision collision)
    {
        //switch has not been pressed and collision object is on layer "Player"
        if (pressed == false && collision.gameObject.CompareTag("Player"))
        {
            _renderer.sharedMaterial = inactiveMaterial;
            pressed = true;
            TriggerTargets(action);
        }
        StartCoroutine ("DelayedReset");

    }

    //go through list of triggerTargets
    public void TriggerTargets (TriggerAction action)

    {
        foreach (Triggerable t in targets)
        {
            // Check in case a target is destroyed
            if (t != null)
            {
                t.Trigger(action);
            }
        }
    }
    //this is an example of a coroutine

    private IEnumerator DelayedReset() {
        yield return new WaitForSeconds(3);
        Debug.Log("3 seconds have passed since I hit switch");
        //add some lines of code here that will reset the switch
        // so we can use it again.
        pressed = false;
        //reset the material
        _renderer.sharedMaterial = activeMaterial;
    } 

    //Gizmo that draws lines to each item that is triggerable from 
    //switch
    void OnDrawGizmosSelected ()
    {
        Gizmos.color = Color.green;

        // null check to avoid editor error when creating switch
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
