using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScale(){
        PlanetManager.current.Scale =! PlanetManager.current.Scale;
        }
    
    public void Trajectory(){
        PlanetManager.current.Trajectories=!PlanetManager.current.Trajectories;
        }
}