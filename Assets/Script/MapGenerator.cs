using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{

    [SerializeField]
    private GameObject tilePrefab;

    Renderer2 render2;

    [SerializeField]
    private GameObject initialPosition;

    [SerializeField]
    private GameObject Bug;

    [SerializeField]
    private GameObject Reddot;
    // Start is called before the first frame update
    void Start()
    {
        render2 = GameObject.Find("Renderer2").GetComponent<Renderer2>();
        DrawGround();
        TransformObject();

        initialPosition = GameObject.Find("(0,0)");
        InitializeBug();
    }

    private void InitializeBug(){
        Instantiate(Bug, initialPosition.transform.position, Quaternion.identity);
    }
    private void DrawGround()
    {
        int width = render2.getWidth();
        int height = render2.getHeight();

        //create the red dot
        int reddotPositionX = Random.Range(1, width);
        int reddotPositionY = Random.Range(1, height);
        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                Vector2 position = new Vector2(i, -j);
                GameObject BackGroundTile = Instantiate(tilePrefab, position, Quaternion.identity) as GameObject;
                BackGroundTile.transform.parent = this.transform;
                BackGroundTile.name = "(" + i + "," + j + ")";
                if (reddotPositionX == i && reddotPositionY == j)
                {
                    GameObject reddot = Instantiate(Reddot, position, Quaternion.identity) as GameObject;
                    reddot.transform.parent = this.transform;
                }
            }
        }
    }
    private void TransformObject()
    {
        transform.localScale = new Vector3(47.5875f, 51.90562f, transform.localScale.z);
        transform.localPosition = new Vector3(-212, 252, 0);
    }
}
