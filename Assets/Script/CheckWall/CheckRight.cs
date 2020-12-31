using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRight : MonoBehaviour
{
    [SerializeField]
    private bool checkRight;

    public void setCheckRight(bool checkRight)
    {
        this.checkRight = checkRight;
    }

    public bool getCheckRight()
    {
        return this.checkRight;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Wall"))
        {
            checkRight = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Wall"))
        {
            checkRight = false;
        }
    }
}
