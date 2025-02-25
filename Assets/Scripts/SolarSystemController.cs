using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{   

    public List<GameObject> Planets = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount-1; i++)
    {
        GameObject planete = transform.GetChild(i).gameObject; // Création de la liste de transform de chaque planète (côté unity)
        Planets.Add(planete);
        Debug.Log("Planète trouvé : " + planete.name);
    }
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition(DateTime.Now);
    }

    void UpdatePosition(DateTime t){
        for (int i = 0; i < Planets.Count; i++) {
            Planets[i].transform.SetPositionAndRotation(PlanetData.GetPlanetPosition((PlanetData.Planet)i,t) , new Quaternion()); //faire le lien entre le transform de la planète i est les données de la planètes i
        }
    }
}
