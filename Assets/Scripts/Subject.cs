using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Subject : MonoBehaviour
{
    List<Observer> observers;
    
    public void attach(Observer observer){
        this.observers.Add(observer); 
    }

    public void dettach(Observer observer){
        this.observers.Remove(observer);
    }

    public void notify(int payload){
        Debug.Log(observers.ToString());
        foreach(Observer observer in this.observers){
            observer.update(payload);
        }
    }
}
