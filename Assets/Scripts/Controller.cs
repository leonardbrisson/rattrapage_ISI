using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Transform sun;
    
    // Start is called before the first frame update
    void Start()
    {
        PlanetManager.current.Cursor = sun;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeScale(){
        //change l'état de l'échelle
        PlanetManager.current.Scale =! PlanetManager.current.Scale;
        }
    
    public void Trajectory(){
        //change l'état de la trajectoire
        PlanetManager.current.Trajectories=!PlanetManager.current.Trajectories;
        }
    
    public void ChangeYear(String s){
        //change l'année
        //int year = int.Parse(s);
        //Debug.Log(year);
        DateTime parsedDate;
        DateTime.TryParse(s, out parsedDate);
        PlanetManager.current.Date = parsedDate;
    }

    public void Play(){ 
        // Bascule de la variable play
        PlanetManager.current.Play = ! PlanetManager.current.Play;
    }
}