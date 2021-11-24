using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathFinder : MonoBehaviour
{
    /// <summary>
    /// the initial level of the pathfinder
    /// </summary>
    public int intialLevel;

    /// <summary>
    /// the current level of the path finder
    /// </summary>
    public int currentLevel;

    /// <summary>
    /// the level the pathfinder is targeting
    /// </summary>
    [HideInInspector]
    public int targetLevel;

    /// <summary>
    /// the exit the path finder is targeting
    /// </summary>
    [HideInInspector]
    public GameObject targetExit;

    /// <summary>
    /// array that stores the escalators in the area
    /// </summary>
    public Escalator[] targetEscalator;

    /// <summary>
    /// The NavMeshAgent this is attached to
    /// </summary>
    [HideInInspector]
    public NavMeshAgent myAgent;

    /// <summary>
    /// Thing to move towards
    /// </summary>
    [HideInInspector]
    public Transform target;

    ///<summary>
    ///the initial spawning area of the navmesh
    /// </summary>
    [SerializeField]
    private GameObject HomePoint;

    // Start is called before the first frame update
    void Start()
    {
        // Get the attached NavMeshAgent and store it in agentComponent
        myAgent = GetComponent<NavMeshAgent>();

        //set current level to initial level first
        currentLevel = intialLevel;

        //warp or something
        myAgent.Warp(HomePoint.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void triggerMove(GameObject goTowards)
    {
        //warp or something
        myAgent.Warp(HomePoint.transform.position);

        //set target as given obj
        targetExit = goTowards;

        //grab the script
        Exit targetExitScript = goTowards.GetComponent<Exit>();

        //set the target level
        targetLevel = targetExitScript.currentLevel;

        //check if current level is the same as target level
        //if same, set target as the exit
        if (currentLevel == targetLevel)
        {
            target = goTowards.transform;
            
        }
        //if not on same level, set to the escalator on the same level
        else if (currentLevel != targetLevel)
        {
            target = targetEscalator[intialLevel].transform;         
        }

        //set the destination
        myAgent.SetDestination(target.position);

    }

    //use to set target and destination to the exit 
    public void reTarget()
    {
        currentLevel = targetLevel;
        triggerMove(targetExit);
    }

    
}
