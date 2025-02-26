using System;
using UnityEngine;
public class PlanetManager : MonoBehaviour
{
public static PlanetManager current;
//vitesse de rotation
    public int speed =100;
private void Awake(){
    // Vérifie s'il existe déjà une instance
    if (current == null){
        current = this;
    }
    else{
        Destroy(obj: this);
    }
}

// Gestion du temps
[SerializeField]
private UDateTime date;
public UDateTime Date{
    get => date;
    set{
        date = value;
        TimeChanged(value.dateTime);
    }
}

// Événement déclenché lors du changement de temps
    public event Action<UDateTime> OnTimeChange;
    public void TimeChanged(UDateTime newTime)
    {
        OnTimeChange?.Invoke(newTime);
    }

    // Gestion de l'échelle
    [SerializeField]
    private Boolean scale;
    
    public Boolean Scale
    {
        get => scale;
        set
        {
            scale = value;
            ScaleChanged(value);
        }
    }

    public event Action<Boolean> ScaleChange;
    public void ScaleChanged(Boolean b)
    {
        ScaleChange?.Invoke(b);
    }

    // Gestion de l'affichage des trajectoires
    [SerializeField]
    private Boolean trajectories = true; 
    
    public Boolean Trajectories
    {
        get => trajectories;
        set
        {
            trajectories = value;
            TrajChanged(value);
        }
    }


    public event Action<Boolean> TrajChange;
    public void TrajChanged(Boolean b)
    {
        TrajChange?.Invoke(b);
    }

    private Boolean play = true; 
    
    public Boolean Play
    {
        get => play;
        set
        {
            play = value;
        }
    }

    [SerializeField] private Transform cursor = null;

    public Transform Cursor //Astre sélectionner 
     {
    get => cursor;
    set
     {
     cursor = value;
    }
    }
}