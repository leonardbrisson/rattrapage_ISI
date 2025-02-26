using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{   

    //liste des planètes
    public List<GameObject> Planets = new List<GameObject>();
    //liste des échelles réelles
    private static List<float> Scales = new List<float> {0.002f, 0.008f, 0.008f, 0.004f, 0.102f, 0.086f, 0.036f, 0.034f} ;


    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount-1; i++) //création de la liste des planètes
    {
        GameObject planete = transform.GetChild(i).gameObject; 
        Planets.Add(planete);
        Debug.Log(planete.name);
    }

    UpdateScale(true); //initialisation de la taille des planètes
    
    PlanetManager.current.Scale = true; 

    PlanetManager.current.OnTimeChange += UpdatePosition; //abonnement au OnTimeChange
    PlanetManager.current.ScaleChange += UpdateScale; //abonnement au ScaleChange
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition(DateTime.Now);
    }

    void UpdatePosition(UDateTime t){
        for (int i = 0; i < Planets.Count; i++) {
            Planets[i].transform.SetPositionAndRotation(PlanetData.GetPlanetPosition((PlanetData.Planet)i,t) , new Quaternion());
        }
    }

    void UpdateScale(Boolean b){
        //fonction qui met à jour la taille des planètes
        if (b==true){ //echelle pédagogique
            for (int i = 0; i < Planets.Count; i++){
                Planets[i].transform.localScale = new Vector3(0.2f,0.2f,0.2f);
            }
        //mercure et venus plus petites
        transform.GetChild(0).localScale = new Vector3(0.1f,0.1f,0.1f);    
        transform.GetChild(1).localScale = new Vector3(0.15f,0.15f,0.15f);
        //taille du soleil
        transform.GetChild(8).localScale = new Vector3(0.2f,0.2f,0.2f);
        }

        if (b==false){ //echelle réelle (sauf le soleil)
            for (int i = 0; i < Planets.Count; i++){
                Planets[i].transform.localScale = new Vector3(Scales[i],Scales[i],Scales[i]);
            }
        // taille du soleil
        transform.GetChild(8).localScale = new Vector3(0.2f,0.2f,0.2f);
        }
    }
}
