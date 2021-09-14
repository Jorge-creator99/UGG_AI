using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public sealed class GameEnvironment 
{
    private static GameEnvironment instance;
    private List<GameObject> checkpoints = new List<GameObject>();
    //public call for checkpoints
    public List<GameObject> Checkpoints { get { return checkpoints; } }
    public GameObject safeLocation;
    
    //Singleton
    public static GameEnvironment Singleton
    {
        get
        {
            //If no instance create one
            if (instance == null)
            {
                instance = new GameEnvironment();
                instance.safeLocation = GameObject.FindGameObjectWithTag("Safe");
                //Populate instance with checkpoints and lists them in alphabetical order
                instance.Checkpoints.AddRange(
                    GameObject.FindGameObjectsWithTag("Checkpoint"));
                instance.checkpoints = instance.checkpoints.OrderBy(waypoint => waypoint.name).ToList();
            }
            return instance;
        }
    }
}
