using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterMovement : MonoBehaviour
{

    public int[,] board;
    Vector2 playerPosition;
    Vector2 destinationPosition;

    // Use this for initialization
    void Start()
    {
        board = new int[15, 15];

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                board[i, j] = 0;
            }
        }

        board[7, 7] = 2;
        board[3, 3] = 1;

        playerPosition = new Vector2(7, 7);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            board[(int)playerPosition.x, (int)playerPosition.y] = 0;
            destinationPosition = new Vector2(playerPosition.x, playerPosition.y + 1);

            if (checkSide(playerPosition, 1) == true)
            {
                checkBall(1);
            }


        }
        if (Input.GetKeyDown("a"))
        {
            board[(int)playerPosition.x, (int)playerPosition.y] = 0;
            destinationPosition = new Vector2(playerPosition.x - 1, playerPosition.y);

            if(checkSide( playerPosition, 2 ) == true)
            {
                checkBall(2);
            }


        }
        if (Input.GetKeyDown("w"))
        {
            board[(int)playerPosition.x, (int)playerPosition.y] = 0;
            destinationPosition = new Vector2(playerPosition.x, playerPosition.y - 1);

            if (checkSide(playerPosition, 3) == true)
            {
                checkBall(3);
            }


        }
        if (Input.GetKeyDown("d"))
        {
            board[(int)playerPosition.x, (int)playerPosition.y] = 0;
            destinationPosition = new Vector2(playerPosition.x + 1, playerPosition.y);

            if (checkSide(playerPosition, 4) == true)
            {
                checkBall(4);
            }


        }

        if(checkWin())
        {
            Debug.Log("Someone Wins");
        }

    }

    void checkBall(int dir)
    {
        Debug.Log("Direction: " + dir);
        if (board[(int)destinationPosition.x, (int)destinationPosition.y] == 2)
        {
            
            if (dir == 1)
            {
                board[(int)destinationPosition.x, (int)destinationPosition.y + 1] = 2;
                

                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }
            if (dir == 2)
            {
                board[(int)destinationPosition.x - 1, (int)destinationPosition.y] = 2;

                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }
            if (dir == 3)
            {
                board[(int)destinationPosition.x, (int)destinationPosition.y - 1] = 2;

                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }
            if (dir == 4)
            {
                board[(int)destinationPosition.x + 1, (int)destinationPosition.y] = 2;

                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }

        }else
        {
            if (dir == 1)
            {
                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }
            if (dir == 2)
            {
                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }
            if (dir == 3)
            {
                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }
            if (dir == 4)
            {
                board[(int)destinationPosition.x, (int)destinationPosition.y] = 1;
            }
        }

        playerPosition = new Vector2(destinationPosition.x, destinationPosition.y);

        for (int i = 0; i < 15; i++)
        {
            for (int j = 0; j < 15; j++)
            {
                if(board[i, j] == 1)
                {
                    Debug.Log("person [" + i + ", " + j + "]");
                }
                if (board[i, j] == 2)
                {
                    Debug.Log("ball [" + i + ", " + j + "]");
                }
            }
        }
    }

    bool checkSide( Vector2 playerPosition, int direction)
    {
        if(direction == 1 && playerPosition.y == 13)
        {
            return false;
        }
        if (direction == 2 && playerPosition.x == 1)
        {
            return false;
        }
        if (direction == 3 && playerPosition.y == 1)
        {
            return false;
        }
        if (direction == 4 && playerPosition.x == 13)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    bool checkWin()
    {
        for (int i = 0; i < 15; i++)
        {
            if (board[0, i] == 2)
            {
                Debug.Log("Left wins");
                return true;
            }
            if (board[14, i] == 2)
            {
                Debug.Log("Right wins");
                return true;
            }
            if (board[i, 0] == 2)
            {
                Debug.Log("Top wins");
                return true;
            }
            if (board[i, 14] == 2)
            {
                Debug.Log("Bottom wins");
                return true;
            }
        }

        return false;
    }
    
}
