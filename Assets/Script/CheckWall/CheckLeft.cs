using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLeft : MonoBehaviour
{
    [SerializeField]
    private bool checkLeft;

    public void setCheckLeft(bool checkLeft)
    {
        this.checkLeft = checkLeft;
    }

    public bool getCheckLeft()
    {
        return this.checkLeft;
    }


    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Wall"))
        {
            checkLeft = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Wall"))
        {
            checkLeft = false;
        }
    }
}
