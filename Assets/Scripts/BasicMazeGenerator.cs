using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BasicMazeGenerator
{
    public int RowCount { get { return mMazeRows; } }
    public int ComlumnCount { get { return mMazeColumns; } }

    protected int mMazeRows;
    protected int mMazeColumns;
    private MazeCell[,] mMaze;

    public BasicMazeGenerator(int rows, int columns)
    {
        mMazeRows = Mathf.Abs(rows);
        mMazeColumns = Mathf.Abs(columns);
        if(mMazeRows == 0)
        {
            mMazeRows = 1;
        }
        if(mMazeColumns ==0)
        {
            mMazeColumns = 1;
        }
        mMaze = new MazeCell[rows, columns];
        for(int i =0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                mMaze[i, j] = new MazeCell();
            }
        }
    }

    public abstract void GenerateMaze();

    public MazeCell GetMazeCell(int row, int column)
    {
        if(row >= 0 && column >= 0 && row < mMazeRows && column < mMazeColumns)
        {
            return mMaze[row, column];
        }
        else
        {
            Debug.Log(row + " " + column);
            throw new System.ArgumentOutOfRangeException();
        }
    }
}
