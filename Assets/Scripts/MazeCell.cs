using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Start,
    Right,
    Front,
    Left,
    Back,
    Goal
};

public class MazeCell
{
    public bool IsVisited = false;
    public bool WallRight = false;
    public bool WallFront = false;
    public bool WallLeft = false;
    public bool WallBack = false;
    public bool IsGoal = false;
}
