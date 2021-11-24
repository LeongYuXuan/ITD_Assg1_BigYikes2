using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    /// <summary>
    /// the current level of the path finder
    /// </summary>
    public int currentLevel;

    /// <summary>
    /// the canvas that the 
    /// </summary>
    public Canvas exitProfile;



    // Start is called before the first frame update
    void Start()
    {
        exitProfile.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void toggleCanvas()
    {
        bool state = exitProfile.isActiveAndEnabled;
        exitProfile.gameObject.SetActive(!state);
    }
}
