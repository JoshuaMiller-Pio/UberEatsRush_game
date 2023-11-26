using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static MyGraph;

public class AdvancedWaypointManager : MonoBehaviour
{
    
    private RaceGraph<int, GameObject> graph;
    public GameObject[]  waypoints = new GameObject[13];
   
    void Start()
    {
        BuildGraph();
    }

    //The build graph method first defines the data types for Value and Value1 required for using the node/graph classes. Here we use int and game object. 
    //We use the int to easily identify, reference and access the individual nodes throughout the graph. 
    //We use the gameobject data type to assign the various waypoint objects place throughout the scene to a specific graphnode when creating the graph, we do this to use the waypoints local transforms to allow our airacers to navigate and traverse the track
    public RaceGraph<int, GameObject> BuildGraph()
    {
        graph = new RaceGraph<int, GameObject>();

        // Add vertices to the graph
        for (int i = 0; i < waypoints.Length; i++)
        {
            graph.AddNode(i, waypoints[i]);
        }

        int currentNode = 0;
        int temp = 1;

        foreach (var waypoint in waypoints)
        {
            if(temp > 13)
            {
                temp = 1;
            }
            graph.AddEdge(currentNode, temp);
            currentNode++;
            temp++;
        }

        //These edges are added to join the waypoints at either end of each shortcut
        graph.AddEdge(6, 8);
        graph.AddEdge(10, 12);

        return graph;
    }
   
    //Used to return a specific graphnode
    public GraphNode<int,GameObject> GetGraphNode(int value)
    {
        Debug.Log("Entered get graph");
        GraphNode<int, GameObject> temp = graph.Find(value);
        return temp;
    }
}