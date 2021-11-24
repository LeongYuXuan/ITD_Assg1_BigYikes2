/*********************************************
 * Script Name: ChangeModel
 * Author: Leong Yu Xuan
 * Summary: Script that manages the status of objects
 * in its array.
 **********************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ChangeModel : MonoBehaviour
{
    //The array that stores the objects
    public GameObject[] objArray;

    /// <summary>
    /// specific gameobject not to make inactive
    /// </summary>
    public GameObject pathFinder;

    //Value to choose what initial object will be
    public int initialObj;

    //Value to track current active object
    private int currentActiveObject;
    // Start is called before the first frame update
    void Start()
    {
        resetValues();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //the function to change the object with button input.
    public void ChangeObj(int upDown)
    {
        //get the mesg renderers in current obj
        var toDisable = new List<MeshRenderer> { objArray[currentActiveObject].GetComponentInChildren<MeshRenderer>() };  

        //disable all of them
        foreach (MeshRenderer e in toDisable)
        {
            e.enabled = false;
        }

        //set current object to inactive
        //objArray[currentActiveObject].SetActive(false);
    
        
        //add upDown to currentActiveObject, either going up or down the array
        currentActiveObject += upDown;

        //prevent currentActiveObject from going past array boundries
        if(currentActiveObject == objArray.Length)
        {
            currentActiveObject = objArray.Length - 1;
            Debug.Log("You can't go any furthur.");
        }
        else if (currentActiveObject < 0)
        {
            currentActiveObject = 0;
            Debug.Log("You can't go any furthur.");
        }

        //reenable the nav mesh but disable it's meshrendere?
        pathFinder.SetActive(true);
        pathFinder.GetComponent<MeshRenderer>().enabled = false;

        //reassign the list?
        toDisable = new List<MeshRenderer> { objArray[currentActiveObject].GetComponentInChildren<MeshRenderer>() };

        //reenable all of them
        foreach (MeshRenderer e in toDisable)
        {
            e.enabled = true;
        }

        //set new object to active
        //objArray[currentActiveObject].SetActive(true);
    }

    /// <summary>
    /// changes which object is active on the array
    /// this one is much more direct and used by the escalator class
    /// </summary>
    /// <param name="upDown"></param>
    public void DirectChangeObj(int index)
    {
        //set current object to inactive
        objArray[currentActiveObject].SetActive(false);

        //sets the number to the specified number
        currentActiveObject = index;

        //set new object to active
        objArray[currentActiveObject].SetActive(true);
    }

    //reset the values when triggered
    public void resetValues()
    {
        //set all objs to be inactive
        for (int i = 0; i < objArray.Length; ++i)
        {
            objArray[i].SetActive(false);
        }

        //disable all mesh renderers


        //set the specified one to be active
        objArray[initialObj].SetActive(true);

        //set current active object to current one.
        currentActiveObject = initialObj;
    }
}
