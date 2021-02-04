using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birds_controller : MonoBehaviour
{  
    public void Dead()
    {
        Destroy(this.gameObject);
    }
}
