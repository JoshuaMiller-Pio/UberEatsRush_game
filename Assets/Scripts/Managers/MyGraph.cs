using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class MyGraph : MonoBehaviour
{

    //Declares the GraphNode class that makes use of 2 abstract variables T and W that will be defined whem the graph is creatd and populated
    public class GraphNode<T, W>
    {
        public T value { get; set; }
        public W value1 { get; set; }
        
        
        public List<GraphNode<T, W>> Neighbours ;
        
       //Basic abstract constructor for GraphNodes
        public GraphNode(T value, W waypoint)
        {
           this.value1 = waypoint;
            this.value = value;
            this.Neighbours = new List<GraphNode<T, W>>();
        }

       

       
        //CHecks to see if the target node already has a neighbour relationship, if not then one is created
        public bool AddNeighbour(GraphNode<T, W> neighbour)
        {
            if (Neighbours.Contains(neighbour))
            {
                return false;
            }
            else
            {
                neighbour.AddNeighbour(this);
                return true;
            }
        }
        //Removes the target node from the Neighbours list
        public bool RemoveNeighbor(GraphNode<T, W> neighbour) 
        {
            return Neighbours.Remove(neighbour);
        }

        //Clears all nodes from the neighbours list
        public bool RemoveAllNeighbours()
        {
            for (int i =  Neighbours.Count; i >= 0; i-- )
            {
                Neighbours.Remove(Neighbours[i]);
            }
            return true;
        }

        //Returns a string of nodes and their neighbours
        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            nodeString.Append("[ Node Value " + value + " with neighbours : ");
            for (int i = 0; i < Neighbours.Count; i++)
            {
                nodeString.Append(Neighbours[i].value + " ");
            }
            nodeString.Append("]");
            return nodeString.ToString();
        }

    }

    //Declares the Graph class that makes use of 2 abstract variables T and W that will be defined when the graph is created and populated
    public class RaceGraph<T, W>
    {
        //Declares a list of graph nodes
        List<GraphNode<T, W>> nodes = new List<GraphNode<T, W>>();
       
        //Constructor for the raceGraph
        //Might need to come back
        public RaceGraph() 
        {
            /*for (int i = 0; i < waypoints.Length; i++)
            {
                nodes[i].value1 = waypoints[i];
            }*/
        }

        public int Count
        {
            get { return nodes.Count; }

        }

        public IList<GraphNode<T, W>> Nodes
        {
            get { return nodes.AsReadOnly(); }
        }
        //Returns a specific node from the nodes list if it exists
        public GraphNode<T, W> Find(T value)
        {
            foreach (GraphNode<T, W> node in nodes)
            {
                if (node.value.Equals(value))
                {
                    return node;
                }
            }
            return null;
        }
        //Adds a node to the graph
        public bool AddNode(T value, W value1)
        {
            if(Find(value) != null)
            {
                return false;
            }
            else
            {
                nodes.Add(new GraphNode<T, W>(value, value1 ));
                return true;
            }
        }
        //Adds an edge relationshp between 2 nodes
        public bool AddEdge(T value1, T value2)
        {
            GraphNode<T, W> node1 = Find(value1);
            GraphNode<T, W> node2 = Find(value2);

            if(node1 == null || node2 == null)
            {
                return false;
            }
            else if(node1.Neighbours.Contains(node2))
            {
                return false;
            }
            else
            {
                node1.AddNeighbour(node2);
                return true;
            }
        }

        //Removes a specific node from the nodes list if it exists and then uses the remove neighbour function to delete a neighboiur relationship between any stablished neighbour of the deleted node
        public bool RemoveNode(T value)
        {
            GraphNode<T, W> removeNode = Find(value);
            if(removeNode == null)
            {
                return false;
            }
            else
            {
                nodes.Remove(removeNode);
                foreach(GraphNode<T, W> node in nodes)
                {
                    node.RemoveNeighbor(removeNode);
                }
                return true;
            }
        }
        //Removes an edge between 2 nods by removing an established neighbour relationship between them if there is one
        public bool RemoveEdge(T value1, T value2)
        {
            GraphNode<T, W> node1 = Find(value1);
            GraphNode<T, W> node2 = Find(value2);

            if(node1 == null || node2 == null)
            {
                return false;
            }
            else if (node1.Neighbours.Contains(node2))
            {
                return false;
            }
            else
            {
                node1.RemoveNeighbor(node2);
                return true;
            }
        }

        //Removes all neighbour relationships from every node and then removes all the nodes from the graph
        public void Clear()
        {
            foreach(GraphNode<T, W> node in nodes)
            {
                node.RemoveAllNeighbours();
            }
            for (int i =  nodes.Count-1; i >= 0; i--)
            {
                nodes.RemoveAt(i);
            }
        }
        //returns a neighbour of a specific node if there is one or more
        public GraphNode<T, W> GetNeighbour(GraphNode<T, W> node)
        {
            if(node.Neighbours.Count == 0)
            {
                return null;
            }
            int randomNeighbour = Random.Range(0, node.Neighbours.Count);
            return node.Neighbours[randomNeighbour];
        }

        //Returns a string representing the nodes in the graph
        public override string ToString()
        {
            StringBuilder nodeString = new StringBuilder();
            for (int i = 0; i < Count; i++)
            {
                nodeString.Append(nodes[i].ToString());
                if (i < Count - 1)
                {
                    nodeString.Append("/n ");
                }
            }
            return nodeString.ToString();
        }

    }
    
}
