using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ChildGrabber : MonoBehaviour
{            
        
    //    BoxCollider2D box;

       void Awake(){
            // box = GetComponent<BoxCollider2D>(); 
       }


       void OnTriggerEnter2D(Collider2D other)
    {
        // if(other.GetComponent<Main_Character>() != null){
        if(other.gameObject.CompareTag("Player")){
            other.transform.parent = this.transform;
            // box.isTrigger = false; // must do this so player doesnt faze through object after standing on elevator
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.transform.parent = null;
            // box.isTrigger = true; // must do this so OnTriggerEnter can be called again
        }
    }
}
