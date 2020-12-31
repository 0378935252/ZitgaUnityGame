using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renderer2 : MonoBehaviour
{
    [SerializeField]
    [Range(1, 50)]
    private int width = 10;

    public void setWidth(int width)
    {
        this.width = width;
    }
    public int getWidth()
    {
        return this.width;
    }

    [SerializeField]
    [Range(1, 50)]
    private int height = 10;

    public int getHeight()
    {
        return this.height;
    }
    public void setHeight(int height)
    {
        this.height = height;
    }
    [SerializeField]
    private float size = 1f;

    [SerializeField]
    private Transform wallPrefab = null;


    // Start is called before the first frame update
    void Start()
    {
        var maze = MazeGenerator.Generate(width, height);
        Draw(maze);
        TransformObject();
    }

    private void Draw(WallState[,] maze)
    {
        //Make floor
        //var floor = Instantiate(floorPrefab, transform);
        //floor.localScale = new Vector3(width, 1, height);

        for (int i = 0; i < width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                var cell = maze[i, j];
                //var position = new Vector3(-width / 2 + i, 0, -height / 2 + j);
                var position = new Vector3(-width / 2 + i, -height/2 +j, 0);

                if (cell.HasFlag(WallState.UP))
                {
                    var topWall = Instantiate(wallPrefab, transform) as Transform;
                    //topWall.position = position + new Vector3(0, 0, size / 2);
                    topWall.position = position + new Vector3(0, size/2, 0);
                    topWall.localScale = new Vector3(size, topWall.localScale.y, topWall.localScale.z);
                    //modify angle
                    topWall.eulerAngles = new Vector3(-90, 0, 0);
                }

                if (cell.HasFlag(WallState.LEFT))
                {
                    var leftWall = Instantiate(wallPrefab, transform) as Transform;
                    leftWall.position = position + new Vector3(-size / 2, 0, 0);
                    leftWall.localScale = new Vector3(size, leftWall.localScale.y, leftWall.localScale.z);
                    leftWall.eulerAngles = new Vector3(0, 90, 0);
                }

                if (i == width - 1)
                {
                    if (cell.HasFlag(WallState.RIGHT))
                    {
                        var rightWall = Instantiate(wallPrefab, transform) as Transform;
                        rightWall.position = position + new Vector3(+size / 2, 0, 0);
                        rightWall.localScale = new Vector3(size, rightWall.localScale.y, rightWall.localScale.z);
                        rightWall.eulerAngles = new Vector3(0, 90, 0);
                    }
                }
                if (j == 0)
                {
                    if (cell.HasFlag(WallState.DOWN))
                    {
                        var bottomWall = Instantiate(wallPrefab, transform) as Transform;
                        //bottomWall.position = position + new Vector3(0, 0, -size / 2);
                        bottomWall.position = position + new Vector3(0, -size/2, 0);
                        bottomWall.localScale = new Vector3(size, bottomWall.localScale.y, bottomWall.localScale.z);
                        //modify angle
                        bottomWall.eulerAngles = new Vector3(-90, 0, 0);
                    }
                }
            }
        }
    }
    private void TransformObject()
    {
        transform.localScale = new Vector3(47.5875f, 51.90562f, transform.localScale.z);
        transform.localPosition = new Vector3(24,-59,0);
    }
    
    // Update is called once per frame
    void Update()
    {
    }
}
