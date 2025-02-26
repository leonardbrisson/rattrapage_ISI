using System;
using UnityEngine;
public class PlanetManager : MonoBehaviour
{
 public static PlanetManager current;
 private void Awake()
 {
 if (current == null)
 {
 current = this;
 }
 else
 {
 Destroy(obj: this);
 }
 }

 [SerializeField]
 private UDateTime date;
 public UDateTime Date
 {
 get => date;
 set
 {
 date = value;
 TimeChanged(value.dateTime); //Fire the event
 }
 }
  public event Action<UDateTime> OnTimeChange;
 public void TimeChanged(UDateTime newTime)
 {
 OnTimeChange?.Invoke(newTime);
 }

 [SerializeField]
 private Boolean scale;
 public Boolean Scale
 {
 get => scale;
 set
 {
 scale = value;
 ScaleChanged(value); //Fire the event
 }
 }

 public event Action<Boolean> ScaleChange;
 public void ScaleChanged(Boolean b)
 {
 ScaleChange?.Invoke(b);
 }
}