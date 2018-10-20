using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour {
    public Transform tile;
    public Transform obstacle;
    public int xsize = 16;
    public int ysize = 16;
    [Range(0,1)]
    public float obstaclePercent;

    public struct pos
    {
        public int x;
        public int y;
        public pos(int _x, int _y)
        {
            x = _x;
            y = _y;
        }
    }

    List<pos> obstacleList;
    Stack<pos> obstacleOrder;

    // Use this for initialization
    void Start () {
        CreateLevel();
	}

    void CreateLevel()
    {
        //make a list of position using map size
        obstacleList = new List<pos>();
        int[,] levelMap = new int[xsize, ysize]; //2D array for the level. 0 = tile, 1 = obstacle
        for (int y = 0; y < ysize; y++)
        {
            for (int x = 0; x < xsize; x++)
            {
                obstacleList.Add(new pos(x, y));
                levelMap[x, y] = 0; //default all to 0
            }
        }
        obstacleList.Shuffle(); //randomize ordering
        obstacleOrder = new Stack<pos>(obstacleList.ToArray()); //store order into stack
        //NEED a check to see if possible to navigate through, maybe 4way flood fill
        
        //obstacleCount is the top portion of the stack with the position to be obstacles
        int obstacleCount = (int)(xsize * ysize * obstaclePercent);
        //store obstacle position into levelMap
        while (obstacleOrder.Count != 0 && obstacleCount !=0)
        {
            pos temp = obstacleOrder.Pop();
            levelMap[temp.x, temp.y] = 1;
            obstacleCount--;
        }
        
        //generate tiles
        Transform newTile;
        for (int y= 0; y<ysize; y++)
        {
            for (int x = 0; x < xsize; x++)
            {
                //new position needs work, just random code right now
                Vector3 newPos = new Vector3((-xsize/2) + x, (-ysize/2) + y, 0);
                //if (Random.Range(0, 4) == 3 && obstacleCount > 0)
                if(levelMap[x,y] == 1)
                {
                    newTile = Instantiate(obstacle, newPos, Quaternion.identity) as Transform;
                }
                else
                {
                    newTile = Instantiate(tile, newPos, Quaternion.identity) as Transform;
                }
            }
        }
        DrawWall();
    }

    void DrawWall()
    {
        Vector3 newPos = new Vector3((-xsize / 2) -1, (-ysize / 2) - 1, 0);
        Transform wall;
        for (int x = 0; x < xsize + 2; x++)
        {
            //bottom wall
            newPos = new Vector3((-xsize / 2) -1 + x, (-ysize / 2) - 1, 0);
            wall = Instantiate(obstacle, newPos, Quaternion.identity) as Transform;
            //top wall
            newPos = new Vector3((-xsize / 2) - 1 + x, (-ysize / 2)  + ysize, 0);
            wall = Instantiate(obstacle, newPos, Quaternion.identity) as Transform;
        }
        for (int y = 0; y < ysize; y++)
        {
            //left wall
            newPos = new Vector3((-xsize / 2) - 1, (-ysize / 2) + y , 0);
            wall = Instantiate(obstacle, newPos, Quaternion.identity) as Transform;
            //right wall
            newPos = new Vector3((-xsize / 2) + xsize, (-ysize / 2) + y, 0);
            wall = Instantiate(obstacle, newPos, Quaternion.identity) as Transform;
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
