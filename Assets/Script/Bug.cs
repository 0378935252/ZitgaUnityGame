using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bug : MonoBehaviour
{
    [SerializeField]
    private GameObject movingPosition;

    [SerializeField]
    private int posX = 0, posY = 0;

    [SerializeField]
    private CheckLeft checkL;

    [SerializeField]
    private CheckRight checkR;

    [SerializeField]
    private CheckTop checkT;

    [SerializeField]
    private CheckBottom checkB;
    // Start is called before the first frame update
    void Start()
    {
        checkL = GameObject.Find("CheckLeft").GetComponent<CheckLeft>();
        checkR = GameObject.Find("CheckRight").GetComponent<CheckRight>();
        checkT = GameObject.Find("CheckTop").GetComponent<CheckTop>();
        checkB = GameObject.Find("CheckBottom").GetComponent<CheckBottom>();            
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (!checkR.getCheckRight())
            {
                posX += 1;
                movingPosition = GameObject.Find("("+posX+","+posY+")");
                transform.position = new Vector2(movingPosition.transform.position.x, movingPosition.transform.position.y); 
            }           
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!checkL.getCheckLeft())
            {
                posX -= 1;
                movingPosition = GameObject.Find("(" + posX + "," + posY + ")");
                transform.position = new Vector2(movingPosition.transform.position.x, movingPosition.transform.position.y);
            }  
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (!checkB.getCheckBottom())
            {
                posY += 1;
                movingPosition = GameObject.Find("(" + posX + "," + posY + ")");
                transform.position = new Vector2(movingPosition.transform.position.x, movingPosition.transform.position.y);
            }  
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (!checkT.getCheckTop())
            {
                posY -= 1;
                movingPosition = GameObject.Find("(" + posX + "," + posY + ")");
                transform.position = new Vector2(movingPosition.transform.position.x, movingPosition.transform.position.y);
            }  
        }
        
    }
}
