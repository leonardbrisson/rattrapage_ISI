using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseListener : MonoBehaviour
{
    public GameObject descriptions;
    public int indice;
    void Start()
    {
      
    foreach (Transform description in descriptions.transform){  //cacher au démarrage
    description.gameObject.SetActive(false);
    }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnMouseDown()
    {
    PlanetManager.current.Cursor = transform; //mettre la planète au centre 
    
    foreach (Transform infos in descriptions.transform){ //re tout désactiver
        infos.gameObject.SetActive(false);
    }
    descriptions.transform.GetChild(indice).gameObject.SetActive(true); //activer la description voulue 

    }
} 