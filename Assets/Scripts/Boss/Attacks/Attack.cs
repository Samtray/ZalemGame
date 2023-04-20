using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack
{
    public virtual void attack(Boss boss){
    }
}

public class Attack1: Attack{
    public override void attack(Boss boss){
        boss.animator.Play("souls_attack_animation");
        boss.childrenSpawners[0].SetActive(true);
    }
}

public class Attack2: Attack{
    public override void attack(Boss boss){
        boss.animator.Play("Fire_attack");
        boss.childrenSpawners[1].SetActive(true);
    }
}

public class Attack3: Attack{
    public override void attack(Boss boss){
        boss.transform.position = boss.flyingBulletLocation.GetComponent<Transform>().position;
        boss.animator.Play("piu_piu_attack_animation_laugh");
        boss.childrenSpawners[2].SetActive(true);
    }
}