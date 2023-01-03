using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Required to use the timeline.
using UnityEngine.Playables;

public class TriggerCutscene : MonoBehaviour
{
    //Required to select which timeline you want to use. 
    //You can input the timeline you want to use in Unity
    public PlayableDirector Timeline;
    //The main camera for this example
    public GameObject Camera1;
    //The camera that is used in the cutscene.
    public GameObject Camera2;

    // Start is called before the first frame update
    void Start()
    {
        //To initiate the Timeline feature.
        //Returns the component of type PlayableDirector
        //You can find this component in the Inspector of the Game Object associated with the Timeline. 
        Timeline.GetComponent<PlayableDirector>();
    }

    // Triggered when the player interacts with the GameObject
    private void OnTriggerEnter(Collider other)
    {
        //If the game object tagged player hit this triggerable GameObject do this:
        if(other.tag == "Player"){
            //Turn the cutscene camera on
            Camera2.SetActive(true);
            //Disable the main camera
            Camera1.SetActive(false);
            //Play the selected Timeline
            Timeline.Play();  
        }

    }
}
