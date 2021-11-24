using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TargetTracker : MonoBehaviour
{
    //create the dictionary
    Dictionary<GameObject, bool> trackObjStatus = new Dictionary<GameObject, bool>();

    //text obj to change
    public Text debug;

    //The Buttons to toggle
    public Button[] levelButtons;

    //The ObjManager to access
    public ChangeModel changeModel;

    public void ObjTrack(GameObject toTrack)
    {
        //update tracked status in dictionary
        if (toTrack != null)
        {
            trackObjStatus[toTrack] = true;

            //set all the buttons to true
            for (int i = 0; i < levelButtons.Length; ++i)
            {
                levelButtons[i].gameObject.SetActive(true);
            }
        }
        else
        {
            return;
        }
    }

    public void ObjectLost(GameObject toTrack)
    {
        if(toTrack != null)
        {
            trackObjStatus[toTrack] = false;

            //set all the buttons to false
            for (int i = 0; i < levelButtons.Length; ++i)
            {
                levelButtons[i].gameObject.SetActive(true);
            }
        }
        else
        {
            return;
        }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //check if something is in dictionary before updating the text
        //if (trackObjStatus.Count > 0)
        //{
            debug.text = " ";

            //goes through every key value pair in dictionary
            foreach (KeyValuePair<GameObject, bool> objectStatus in trackObjStatus)
            {
                debug.text += objectStatus.Key.name + ": " + objectStatus.Value + '\n';
            }
        //}
    }
}
