using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchTracker : MonoBehaviour
{
    //not sure what this is
    private Touch firstTouch;

    //debug text to update
    public Text debugText;


    //update happens every frame
    private void Update()
    {
        StoreTouch();
    }

    //to check for touches or something
    private void StoreTouch()
    {
        //to do the same but with a mouse
        if (Input.GetMouseButton(0))
        {
            //create ray from click position
            //firstTouch.position if using touch
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //varaible to hold hit info
            RaycastHit info;

            //check to see if raycast hit anything
            if (Physics.Raycast(ray, out info))
            {
                //if hit anything, display infomation
                debugText.text = "First \"touch\" position: " + Input.mousePosition + ". Current Object: " + info.collider.name;

                //check if the interacted object has a script with toggleButtonStatus
                if (info.collider.gameObject.GetComponent<Exit>())
                {
                    info.collider.gameObject.GetComponent<Exit>().toggleCanvas();
                }
            }
            else
            {
                //what to do if it hits nothing
                debugText.text = "First \"touch\" position: " + Input.mousePosition + ". Current object: None ";
            }


        }

        //do something if there is more than one touch?
        if (Input.touchCount > 0)
        {
            firstTouch = Input.GetTouch(0);

            debugText.text = "First touch position: " + firstTouch.position + ". Current Phase: " + firstTouch.phase;

        }
        else
        {
            //do nothing if no touches detected
            return;
        }
    }
}
