using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Escalator : MonoBehaviour
{
    /// <summary>
    /// the current level of the path finder
    /// </summary>
    public int currentLevel;

    //object manager to handle transitions or something
    public ChangeModel objManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// change the level active and the target 
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(collision);
        PathFinder path = collision.gameObject.GetComponent<PathFinder>();

        Debug.Log("rewrite");
        path.reTarget();

    }

   
}