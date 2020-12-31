using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckTop : MonoBehaviour
{
    [SerializeField]
    private bool checkTop;

    public void setCheckTop(bool checkTop)
    {
        this.checkTop = checkTop;
    }

    public bool getCheckTop()
    {
        return this.checkTop;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Wall"))
        {
            checkTop = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Wall"))
        {
            checkTop = false;
        }
    }
}
