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
        //change la date
        DateTime parsedDate;
        DateTime.TryParse(s, out parsedDate);
        PlanetManager.current.Date = parsedDate;
    }

    public void Play(){ 
        // change l'état de la variable play
        PlanetManager.current.Play = ! PlanetManager.current.Play;
    }

public void SpeedUp(){ 
  //accélère de 5 la vitesse
  PlanetManager.current.speed += 5;
}

public void SpeedDown(){ 
  //ralenti de 5 la vitesse
  PlanetManager.current.speed -= 5;
}

public void SpeedReset(){ 
  //remet la vitesse à 25
  PlanetManager.current.speed = 25;
}
}