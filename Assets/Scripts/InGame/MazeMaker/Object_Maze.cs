//Class used to represent and generate a maze
//Author: Vittorio Morrone

//-------Imports-------
using UnityEngine;
using System.Collections;

//-------Main Class-------
public class Object_Maze{
    //-------Variables-------
    private int[,] matrix_Maze; //Matrix representing the maze

    public const int CODE_FLOOR   = 0; //Code representing the floor
    public const int CODE_WALL    = 1; //Code representing the wall
    public const int CODE_PLAYER  = 2; //Code representing the player
    public const int CODE_PICK_UP = 3; //Code representing the pick ups

    private const int CODE_VERTICAL   = 0; //Used to insert vertical walls
    private const int CODE_HORIZONTAL = 1; //Used to insert horizontal wall

    //-------Class Constructors-------
    public Object_Maze(int input_height, int input_width) {
        matrix_Maze = new int[input_height, input_width];
    }

    //-------Class Methods-------
    //Generates the maze into the matrix
    public void generateMaze(){
        
        //Put the initial empty maze into the list of chambers to divide
        Object_Chamber chamber = new Object_Chamber(0, 0, matrix_Maze.GetLength(0), matrix_Maze.GetLength(1));
        ArrayList chambers = new ArrayList();

        if (chamber.isDivisible()) {
            chambers.Add(chamber);
        }        
        
        while (chambers.Count > 0) {

            //Get a chamber            
            chamber = (Object_Chamber) chambers[0];
            chambers.RemoveAt(0);
            
            //Generate wall
            int chamberHeight = chamber.getHeight();
            int chamberWidth = chamber.getWidth();
            int chamberI = chamber.getI();
            int chamberJ = chamber.getJ();

            //Decide orientation
            int wallOrientation = chamberHeight > chamberWidth ? CODE_HORIZONTAL : CODE_VERTICAL;

            //Decide index
            //Subtract 2 to the range and add 1 to the final position in order to avoid walls over the edges of a chamber
            int wallIndex = chamberHeight > chamberWidth ? Mathf.FloorToInt(Random.value * (chamberHeight - 2) + chamberI + 1) : Mathf.FloorToInt(Random.value * (chamberWidth - 2) + chamberJ + 1);

            //Generate wall
            if (wallOrientation == CODE_HORIZONTAL) {
                int j = chamber.getJ();

                insertWall(j, j+chamberWidth, wallOrientation, wallIndex);
                //Shorten the wall if it blocks a door
                if (j - 1 >= 0 && matrix_Maze[wallIndex, j - 1] == 0)
                    matrix_Maze[wallIndex, j] = 0;
                if(j + chamberWidth < matrix_Maze.GetLength(1) && matrix_Maze[wallIndex, j + chamberWidth] == 0)
                    matrix_Maze[wallIndex, j + chamberWidth -1] = 0;

                //Divide chamber
                Object_Chamber tempChamber = new Object_Chamber(chamberI, chamberJ, wallIndex - chamberI, chamberWidth);
                if (tempChamber.isDivisible()) chambers.Add(tempChamber);

                tempChamber = new Object_Chamber(wallIndex+1, chamberJ, chamberHeight - wallIndex - 1 + chamberI, chamberWidth);
                if (tempChamber.isDivisible()) chambers.Add(tempChamber);
            }
            else if (wallOrientation == CODE_VERTICAL){
                int i = chamber.getI();

                insertWall(i, i + chamberHeight, wallOrientation, wallIndex);

                //Shorten the wall if it blocks a door
                if (i - 1 >= 0 && matrix_Maze[i - 1, wallIndex] == 0)
                    matrix_Maze[i, wallIndex] = 0;
                if (i+chamberHeight < matrix_Maze.GetLength(0) && matrix_Maze[i+chamberHeight, wallIndex] == 0)
                    matrix_Maze[i + chamberHeight -1, wallIndex] = 0;

                //Divide chamber
                Object_Chamber tempChamber = new Object_Chamber(chamberI, chamberJ, chamberHeight, wallIndex - chamberJ);
                if (tempChamber.isDivisible()) chambers.Add(tempChamber);

                tempChamber = new Object_Chamber(chamberI, wallIndex + 1 , chamberHeight, chamberWidth - wallIndex - 1 + chamberJ);
                if (tempChamber.isDivisible()) chambers.Add(tempChamber);
            }            
        }
    }

    //Puts a wall into the matrix
    private void insertWall(int input_index_from, int input_index_to, int input_orientation, int input_fixedIndex){
        //Compute the index of the door in the wall
        int index_door = Mathf.FloorToInt(Random.value * (input_index_to - input_index_from)) + input_index_from;

        for (int index = input_index_from; index < input_index_to; index++){
            //Skip iteration in case the index is the position of the door
            if (index == index_door) continue;

            //Insert vertical wall
            if (input_orientation == CODE_VERTICAL){
                matrix_Maze[index, input_fixedIndex] = CODE_WALL;
            }
            //Insert horizontal wall
            else if (input_orientation == CODE_HORIZONTAL){
                matrix_Maze[input_fixedIndex, index] = CODE_WALL;
            }
        }
    }

    //-------Get method-------
    //Used to return the maze
    public int[,] get_Maze() {
        return matrix_Maze;
    }
}
