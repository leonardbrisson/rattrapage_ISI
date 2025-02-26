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
    //trajectoires
    private GameObject[]  trajectoires;
    //material de la trajectoire
    public Material trajectoryMaterial;
    

    // Start is called before the first frame update
    void Start(){
        for (int i = 0; i < transform.childCount-1; i++){
            //création de la liste des planètes
            GameObject planete = transform.GetChild(i).gameObject; 
            Planets.Add(planete);
        }

        UpdateScale(true); //initialisation de la taille des planètes
        UpdatePosition(DateTime.Now); //initialisation de la position

        PlanetManager.current.Scale = true; 

        //abonnement des event du PlanetManager aux fonctions du SolarSystemController
        PlanetManager.current.OnTimeChange += UpdatePosition; //abonnement au OnTimeChange
        PlanetManager.current.ScaleChange += UpdateScale; //abonnement au ScaleChange
        PlanetManager.current.TrajChange += DisplayTrajectories; //abonnement au TrajChange

        CreateTrajectories(); //création des trajectoires et stockage de celles ci dans le GameObject trajectoires
        DisplayTrajectories(false);
    }

    // Update is called once per frame
    void Update(){
        if (PlanetManager.current.Play==true){ 
        PlanetManager.current.Date = PlanetManager.current.Date.dateTime.AddHours(PlanetManager.current.speed);
      }
    }

    void UpdatePosition(UDateTime t){
        //met à jour la position des planètes à la date t
        Debug.Log(t);
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

    void CreateTrajectories(){
        //fonction qui crée successivement toutes les trajectoires
        trajectoires = new GameObject[Enum.GetValues(typeof(PlanetData.Planet)).Length];  // Création et stockage des trajetoires (pour ne le faire qu'une fois)
        int index = 0;
        foreach (PlanetData.Planet p in Enum.GetValues(typeof(PlanetData.Planet)))
        {
            GameObject planetObject = GameObject.Find(p.ToString());
            if (planetObject != null)
            {
                GameObject trajectory = CreateTrajectory(p);
                trajectoires[index] = trajectory;
                index++;
            }
        }
    }

    public GameObject CreateTrajectory(PlanetData.Planet planetType){
        //fonction qui crée la trajectoire d'une planète en particulier
        DateTime startDate = DateTime.Now;
        // Création de l'objet représentant la trajectoire
        GameObject trajectory = new GameObject(planetType.ToString() + "Trajectory");
        trajectory.transform.SetParent(transform);

        // Initialisation du LineRenderer pour tracer l'orbite
        LineRenderer lineRenderer = trajectory.AddComponent<LineRenderer>();
        lineRenderer.positionCount = 100000;
        lineRenderer.material = trajectoryMaterial;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;

        //calcul des positions à chaque pas
        for (int i = 0; i < 100000; i++) 
        {
            Vector3 planetPosition = PlanetData.GetPlanetPosition(planetType, startDate.AddDays(1f*i)); 
            lineRenderer.SetPosition(i, planetPosition);
        }

        return trajectory;
    }

    void DisplayTrajectories(Boolean b){
        //fonction qui active ou désactive l'affichage des trajectoires calculées au démarrage
     if (trajectoires != null)
        {
            foreach (GameObject trajectoire in trajectoires)
            {
                if (trajectoire != null)
                {
                    // Activer ou désactiver les trajectoires
                    trajectoire.SetActive(b);
                }
             }
    }
  }
}
