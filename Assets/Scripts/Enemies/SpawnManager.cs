using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class SpawnManager : MonoBehaviour
{
    
    public IVehicleInterface[] cars = new IVehicleInterface[5];
    public GameObject[] spawnedCars = new GameObject[5];
    public GameObject[] spawnPoints = new GameObject[5];
    public  GameObject fastCarPrefab, standardCarPrefab, slowCarPrefab;

    public IVehicleFactory factory;
   /* public SpawnManager(FastCarFactory factory)
    {
        fastFactory = factory;
    }*/
    public void Start()
    {
       factory = new ConcreteVehicleFactory();
        BuildCars();
        SpawnDrivers();
    }

    static void Main(string[] args)
    {

        



    }

    public void BuildCars()
    {
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            IVehicleInterface car = factory.CreateCar();
            cars[i] = car;
            

        }
    }
    public void SpawnDrivers()
    {
        for (int i = 0; i < cars.Length; i++)
        {
            int rnd = UnityEngine.Random.Range(0, 3);
            switch (cars[rnd])
            {
                case FastCar:
                   GameObject temp = Instantiate(slowCarPrefab, spawnPoints[i].transform.position, transform.rotation);
                    spawnedCars[i] = temp;
                    break;
                case StandardCar:
                    GameObject temp1 = Instantiate(standardCarPrefab, spawnPoints[i].transform.position, transform.rotation);
                    spawnedCars[i] = temp1;
                    break;
                case SlowCar:
                    GameObject temp2 = Instantiate(fastCarPrefab, spawnPoints[i].transform.position, transform.rotation);
                    spawnedCars[i] = temp2;
                    break;

                default:
                    throw new ApplicationException("Racer Spawning Invalid Type");

            }
        }
        BeginnerRaceManager.racers = spawnedCars;
    }
}

