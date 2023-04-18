using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Attack
{
    public virtual void attack(){
    }
}

public class Attack1: Attack{
    public override void attack(){
        
    }
}

public class Attack2: Attack{
    public override void attack(){
        Debug.Log("Attacking with attack 2");
    }
}

public class Attack3: Attack{
    public override void attack(){
        Debug.Log("Attacking with attack 3");
    }
}

public class Attack4: Attack{
    public override void attack(){
        Debug.Log("Attacking with attack 4");
    }
}

public class Attack5: Attack{
    public override void attack(){
        Debug.Log("Attacking with attack 5");
    }
}

public class Attack6: Attack{
    public override void attack(){
        Debug.Log("Attacking with attack 6");
    }
}