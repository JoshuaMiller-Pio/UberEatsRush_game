using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AdvancedAiRacer : MonoBehaviour
{
    NavMeshAgent navMeshAgent;
    public int Nodeindex, waypointsPassed, currentTarget;
    public AdvancedWaypointManager waypointManager;


    // Start is called before the first frame update

    void Start()
    {
        navMeshAgent = gameObject.GetComponent<NavMeshAgent>();
        //pointing to ref in mem??
        waypointManager = GameObject.FindGameObjectWithTag("AdvancedWaypointManager").GetComponent<AdvancedWaypointManager>();
        waypointsPassed = 0;
        currentTarget = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
            StartCoroutine(Drive());
        
    }

    //Sets the navmesh target for the airacer to move towards
    public IEnumerator Drive()
    {
        var temp = waypointManager.GetGraphNode(currentTarget);
        navMeshAgent.destination = temp.value1.transform.position;
        

        yield return null;
    }

    //Updates the target for the navmesh agent on the airacer.
    //Random numbers are used to determine which waypoint the airacer will move toward when specificwaypoints are collided with (i.e when the airacer must choose whether to take the shortcut or not)
    private void OnTriggerEnter(Collider other)
    {
        MyGraph.GraphNode<int, GameObject> temp = waypointManager.GetGraphNode(currentTarget);
       
            if (other.tag == "Goal" && temp.value1.gameObject == other.gameObject)
            {
                    if(currentTarget == 4)
                    {
                             int i = Random.Range(0, 3);
                           if(i == 1)
                           {
                              currentTarget = 4;
                           }

                           if(i == 2)
                           {
                              currentTarget = 6;
                           }
                    }

                    if (currentTarget == 6)
                     {
                          currentTarget = 7;
                     }

                    if (currentTarget == 9)
                    {
                        int i = Random.Range(0, 3);
                        if (i == 1)
                        {
                            currentTarget = 9;
                        }

                        if (i == 2)
                        {
                            currentTarget = 10;
                        }
                    }

                    if(currentTarget >= 12)
                     {
                        currentTarget = 1;
                     }
                currentTarget++;

                waypointsPassed++;
            }
       

    }



}

