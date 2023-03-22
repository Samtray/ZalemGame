using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    List<Observer> observers;
    
    public void Attach(Observer observer){
        this.observers.Add(observer); 
    }

    public void Dettach(Observer observer){
        this.observers.Remove(observer);
    }

    public void Notify(int payload){
        Debug.Log(observers.ToString());
        foreach(Observer observer in observers){
            observer.update(payload);
        }
    }
}
