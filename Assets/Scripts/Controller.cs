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
        if (PlanetManager.current.Scale == true){
        PlanetManager.current.Scale = false;
        return;
        }
        if (PlanetManager.current.Scale == false){
        PlanetManager.current.Scale = true;
        return;
        }
    }
}
