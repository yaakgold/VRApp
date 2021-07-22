using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeSpawner : MonoBehaviour
{
    public enum MazeGenerationAlgorithm
    {
        PureRecursive
    }

    public MazeGenerationAlgorithm algorithm = MazeGenerationAlgorithm.PureRecursive;
    public bool fullRandom = false;
    public int randomSeed = 12345;
    public GameObject floor, wall, pillar;
    public int rows = 5, cols = 5;
    public float cellWidth = 4, cellHeight = 4;
    public bool addGaps = false;
    public GameObject goalPrefab;

    private BasicMazeGenerator mMazeGenerator = null;

    // Start is called before the first frame update
    void Start()
    {
        if(!fullRandom)
        {
            Random.InitState(randomSeed);
        }

        switch (algorithm)
        {
            case MazeGenerationAlgorithm.PureRecursive:
                mMazeGenerator = new RecursiveMazeAlgorithm(rows, cols);
                break;
            default:
                break;
        }

        mMazeGenerator.GenerateMaze();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                float x = c * (cellWidth + (addGaps ? .2f : 0));
                float z = r * (cellHeight + (addGaps ? .2f : 0));

                MazeCell cell = mMazeGenerator.GetMazeCell(r, c);
                GameObject tmp;
                tmp = Instantiate(floor, new Vector3(x, 0, z), Quaternion.Euler(0, 0, 0));
                tmp.transform.parent = transform;

                if (cell.WallRight)
                {
                    tmp = Instantiate(wall, new Vector3(x + cellWidth / 2, 0, z) + wall.transform.position, Quaternion.Euler(0, 90, 0));// right
                    tmp.transform.parent = transform;
                }
                if (cell.WallFront)
                {
                    tmp = Instantiate(wall, new Vector3(x, 0, z + cellHeight / 2) + wall.transform.position, Quaternion.Euler(0, 0, 0));// front
                    tmp.transform.parent = transform;
                }
                if (cell.WallLeft)
                {
                    tmp = Instantiate(wall, new Vector3(x - cellWidth / 2, 0, z) + wall.transform.position, Quaternion.Euler(0, 270, 0));// left
                    tmp.transform.parent = transform;
                }
                if (cell.WallBack)
                {
                    tmp = Instantiate(wall, new Vector3(x, 0, z - cellHeight / 2) + wall.transform.position, Quaternion.Euler(0, 180, 0));// back
                    tmp.transform.parent = transform;
                }

                print("Is Goal: " + cell.IsGoal);
                print("Prefab: " + goalPrefab);
                if (cell.IsGoal && goalPrefab != null)
                {
                    print("Goaaaaaaaaalllllllllllllll");
                    tmp = Instantiate(goalPrefab, new Vector3(x, 1, z), Quaternion.Euler(0, 0, 0));
                    tmp.transform.parent = transform;
                }
            }
        }

        if (pillar != null)
        {
            for (int r = 0; r < rows + 1; r++)
            {

                for (int c = 0; c < cols + 1; c++)
                {
                    float x = c * (cellWidth + (addGaps ? .2f : 0));
                    float z = r * (cellHeight + (addGaps ? .2f : 0));
                    GameObject tmp = Instantiate(pillar, new Vector3(x - cellWidth * .5f, 0, z - cellHeight * .5f), pillar.transform.rotation);
                    tmp.transform.parent = transform;
                }
            }
        }
    }
}
