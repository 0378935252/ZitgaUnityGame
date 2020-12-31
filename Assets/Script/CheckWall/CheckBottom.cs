using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBottom : MonoBehaviour
{
    [SerializeField]
    private bool checkBottom;

    public void setCheckBottom(bool checkBottom)
    {
        this.checkBottom = checkBottom;
    }

    public bool getCheckBottom()
    {
        return this.checkBottom;
    }

    void OnTriggerStay(Collider col)
    {
        if (col.CompareTag("Wall"))
        {
            checkBottom = true;
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.CompareTag("Wall"))
        {
            checkBottom = false;
        }
    }
}
