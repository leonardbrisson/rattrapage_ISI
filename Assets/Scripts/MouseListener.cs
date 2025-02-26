using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseListener : MonoBehaviour
{
        public GameObject descriptions;
    public int indice;
    void Start()
    {
      
    foreach (Transform description in descriptions.transform){// désactiver toute les infos
    description.gameObject.SetActive(false);
    }  
    }

    // Update is called once per frame
    void Update()
    {
        
    }

     private void OnMouseDown()
    {
    PlanetManager.current.Cursor = transform; //changer de cible pour la caméra 
    
    foreach (Transform infos in descriptions.transform){
        infos.gameObject.SetActive(false);
    }
    descriptions.transform.GetChild(indice).gameObject.SetActive(true); // afficher les bonnes infos 

    }
}
