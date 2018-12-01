using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGen : MonoBehaviour {
    public Transform tile;
    public Transform obstacle;

    public GameObject shieldPrefab;
    public GameObject minePrefab;
    
    public int xsize = 16;
    public int ysize = 16;
    [Range(0,0.3f)] //range for obstaclePercent slider, 0 to 30%
    public float obstaclePercent;
    //private bool player1Spawned = false;

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

        //add item position to map

        //1 = obstacle, 2 = beacon, 3 = shield, 4 = flamegun, 5 = landmine, 6 = player1(ball), 7 = player2
	int itemCount = 7;
	//if this part fail to work, remove the second condition, it isn't needed if obstaclePercent [Range(0,0.3f)] works
	if (obstacleOrder.Count != 0 && (obstacleOrder.Count - itemCount) > 0) {
		for (int i = 2; i <= itemCount; i++) {
			pos temp = obstacleOrder.Pop ();
			levelMap [temp.x, temp.y] = i;
		}
	}

        //generate tiles
        for (int y= 0; y<ysize; y++)
        {
            for (int x = 0; x < xsize; x++)
            {
                //new position needs work, just random code right now
                Vector3 newPos = new Vector3((xsize / 2) + x, (ysize / 2) + y, 0);
                //if (Random.Range(0, 4) == 3 && obstacleCount > 0)
                if(levelMap[x,y] == 1)
                {
                    Instantiate(obstacle, newPos, Quaternion.identity);
                }
                else
                {
                    Instantiate(tile, newPos, Quaternion.identity);
                    
                    /*
                    if (!player1Spawned)
                    {   
                        //move player to open tile
                        GameObject player1 = GameObject.Find("player1");
                        player1.transform.position = newPos;
                        player1Spawned = true;
                    }
                    */
                    switch (levelMap[x, y])
                    {
                        case 2:
                            //Debug.Log(levelMap[x,y]);
                            //GameObject beacon = GameObject.Find("beacon");
                            //beacon.transform.position = newPos;
                            break;
                        case 3:
                            //GameObject shield = GameObject.Find("shield");
                            //shield.transform.position = newPos;
                            break;
                        case 4:
                            //GameObject flamegun = GameObject.Find("flamegun");
                            //flamegun.transform.position = newPos;
                            break;
                        case 5:
                            //GameObject landmine = GameObject.Find("landmine");
                            //landmine.transform.position = newPos;
                            break;
                        case 6:
                            GameObject player1 = GameObject.Find("player1");
                            player1.transform.position = newPos;
                            break;
                        case 7:
                            GameObject player2 = GameObject.Find("player2");
                            player2.transform.position = newPos;
                            break;
                        default:
                            break;
                    }
                }
            }
        }
        DrawWall();
    }

    void DrawWall()
    {   //draw walls surrounding the map
        Vector3 newPos = new Vector3((xsize / 2) -1, (ysize / 2) - 1, 0);

        for (int x = 0; x < xsize + 2; x++)
        {
            //bottom wall
            newPos = new Vector3((xsize / 2) -1 + x, (ysize / 2) - 1, 0);
            Instantiate(obstacle, newPos, Quaternion.identity);
            //top wall
            newPos = new Vector3((xsize / 2) - 1 + x, (ysize / 2)  + ysize, 0);
            Instantiate(obstacle, newPos, Quaternion.identity);
        }
        for (int y = 0; y < ysize; y++)
        {
            //left wall
            newPos = new Vector3((xsize / 2) - 1, (ysize / 2) + y , 0);
            Instantiate(obstacle, newPos, Quaternion.identity);
            //right wall
            newPos = new Vector3((xsize / 2) + xsize, (ysize / 2) + y, 0);
            Instantiate(obstacle, newPos, Quaternion.identity);
        }
    }


	// Update is called once per frame
	void Update () {
        //Debug.Log("respawn items");
		
	}
}
