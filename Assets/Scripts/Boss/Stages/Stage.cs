using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stage
{
    public virtual void enter(Boss boss){
        // If there are attacks, clear them
        if(boss.attacks.Count > 0){
            boss.attacks.Clear();
        }
    }
    public abstract void next(Boss boss);
}


public class Stage1: Stage{
    private static Stage instance;

    public static Stage Instance(){
        if(instance == null){
            instance = new Stage1();
        }
        return instance;
    }

    public override void enter(Boss boss)
    {
        Debug.Log("Stage 1");
        //boss.bossSpriteRenderer.color = Color.red;
        base.enter(boss);
        // Load new set of attacks to perform
        boss.attacks.Add(new Attack1());  
        boss.attacks.Add(new Attack2());  
        boss.attacks.Add(new Attack3());  
    }
    public override void next(Boss boss)
    {
        boss.Stage = Stage2.Instance();
    }
}

public class Stage2: Stage{
    private static Stage instance;

    public static Stage Instance(){
        if(instance == null){
            instance = new Stage2();
        }
        return instance;
    }
    public override void enter(Boss boss)
    {
        Debug.Log("Stage 2");
        boss.EnemyDelayBetweenAttacks *= 0.75f;
    }
    public override void next(Boss boss){
        exit();
    }

    private void exit(){
        // Defeat animation 
        // Destroy Boss
        // etc, etc, etc. 
        Debug.Log("Boss defeated");
    }
}
