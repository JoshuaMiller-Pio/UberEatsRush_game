using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class WaypointManager:Singleton<WaypointManager>
{
    public GameObject[] waypoints;

    public void Start()
    {

        
    }

      public void  insertWaypoints(WayPointList WPL)
    {
         for (int i = 0; i < waypoints.Length; i++)
         {
             WPL.InsertWaypoint(waypoints[i],i);
         }

    }
  
}

public class Node 
{
    public GameObject waypoint;
    public Node next;
    public int index;
    public int lap =0;
}

public class WayPointList
{
    public Node head;
    public Node tail;
    public int WaypointNum;
    public Node Newnode;

    //creates a new waypoint list
    public Node CreateWaypoint(GameObject waypoint)
    {
        //declares the head and node are = to instances of node
        head = new Node();
        
        Node node = new Node();

        //nodes waypoint is = waypoint coming from the parameter
        node.waypoint = waypoint;
        //because there are no other nodes we set it to the current node so that it is a Circle single link list
        node.next = node;


        head = node;
        tail = node;
        WaypointNum = 1;
        node.index = WaypointNum - 1;
        Newnode = head;
        return head;

    }

    public void InsertWaypoint(GameObject waypoint, int index)
    {
        //declaration of the new node
        Node node = new Node();
        node.waypoint = waypoint;

        //if the linked list doesnt exist we will make a new one
        if(head == null)
        {
            CreateWaypoint(waypoint);
            return;
        }
        //if the specified location is 0 we will insert it at the head
        else if (index == 0)
        {
            //the node after node = head value
            node.next = head;
            //head will = new node
            head = node;
            //tail will loop back around
            tail.next = head;

        }
        //if the specified location is greater than the size of the list it will go at the end
        else if(index >= WaypointNum)
        {
            //we create a tail .next which will point to the new tail not the head
            tail.next = node;

            //tail will be set to the node
            tail = node;

            //tail .next is set back to the head
            tail.next = head;
        }
        //if none of the above we will cycle through and add it to where it needs to be 
        else
        {
            //create a temp node and access the head
            Node tempnode = head;

            int cIndex = 0;

            while(cIndex < index - 1)
            {
                //cycle through the nodes until we get to the index
                tempnode = tempnode.next;
                cIndex++;
            }
            //set the next node to be the 
            node.next = tempnode.next;
            tempnode.next = node;
        }
        WaypointNum++;
        node.index = WaypointNum - 1;

    }

    public Node nextWaypoint(int CurrentNodeIndex)
    {
        Node temp;
        if(head != null)
        {
                temp = head;

            for(int i = 0; i <= CurrentNodeIndex; i++)
            {
                temp = temp.next;
            }

            Newnode = temp;
            if(CurrentNodeIndex == 0)
            {
                Newnode.lap++;
            }
            return Newnode;
        }
        return Newnode;
    }
}
