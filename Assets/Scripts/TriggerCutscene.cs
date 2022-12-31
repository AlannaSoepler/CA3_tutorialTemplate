using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Required to use the timeline.
using UnityEngine.Playables;

public class TriggerCutscene : MonoBehaviour
{
    //Required to select which timeline you want to use. 
    //You can input the timeline you want to use in Unity
    public PlayableDirector timeline;
    //The main camera for this example
    public GameObject Camera1;
    //The camera that is used in the cutscene
    public GameObject Camera2;

    // Start is called before the first frame update
    void Start()
    {
        //To initiate the timeline feature.
        //You should see on the timeline object, in Unity, that a component called Playable Director has been added. 
        timeline.GetComponent<PlayableDirector>();
    }

    // Triggered when the player interacts with the GameObject
    private void OnTriggerEnter(Collider other)
    {
        //If the player object tagged player hit this triggerable GameObject
        if(other.tag == "Player"){
            //Turn the cutscene camera on
            Camera2.SetActive(true);
            //Disable the main camera
            Camera1.SetActive(false);
            //Play the selected timeline
            timeline.Play();  
        }

    }
}
