using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StandardCar : MonoBehaviour, IVehicleInterface
{
    [SerializeField] int acceleration = 15, speed = 60;
    public int currentLap;
    public NavMeshAgent agent;
    public AiRacer aiRacer;
    #region Accessors
    public float GetAcceleration()
    {
        return acceleration;
    }

    public float GetSpeed()
    {
        return speed;
    }

    public int GetCurrentLap()
    {
        return currentLap;
    }
    #endregion

    #region Mutators

    public void SetAcceleration(int acceleration)
    {
        this.acceleration = acceleration;
    }

    public void SetSpeed(int speed)
    {
        this.speed = speed;
    }

    public void SetCurrentLap(int currentLap)
    {
        this.currentLap = currentLap;
    }
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        agent = gameObject.GetComponent<NavMeshAgent>();
        agent.acceleration = acceleration;
        agent.speed = speed;
        aiRacer = gameObject.GetComponent<AiRacer>();
       // aiRacer.StartCoroutine(aiRacer.Drive());
    }

    public void Drive(float acceleration, Transform currentWaypoint)
    {

    }

    public void UpdateWaypoint(GameObject currentWaypoint, GameObject newWaypoint)
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
