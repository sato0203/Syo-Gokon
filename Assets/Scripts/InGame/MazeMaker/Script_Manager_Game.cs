/**
*   Class used to handle the initialization of the game.
*/

//Imports
using UnityEngine;

//Main class
public class Script_Manager_Game : MonoBehaviour {
    //-------Variables-------
    public int maze_height; //Represents the height of the maze
    public int maze_width;  //Represents the width of the maze

    public GameObject prefab_wall; //represents the tile of the wall
    public GameObject prefab_floor; //represents the tile of the floor

    private Object_Maze maze_object; //Object containing the matrix which represents the maze

    //-------MonoBehaviour methods-------
    /**
    *   Initializes the maze
    */
    private void Start(){
        //Generates the matrix that represents the maze
        maze_object = new Object_Maze(maze_height, maze_width);
        maze_object.generateMaze();

        
        instantiateMaze();
        //TODO decomment
        /*
        instantiatePlayer();
        instantiatePickUps();
        */
    }

    //-------Class Methods-------
    //Compute the coordinates x and y
    //This coordinate computation allows the representation
    //of the maze as a matrix (As used to be printed)
    private Vector2 getCoordinates(int i, int j){
        Vector2 result = new Vector3();
        result.x = j - maze_width / 2;
        result.y = -i + maze_height / 2;

        return result;
    }

    //Instantiates the maze according to the matrix
    private void instantiateMaze(){
        int[,] matrix_Maze = maze_object.get_Maze();

        /*
        *   The loop starts at -1 and finishes at height/width +1
        *   in order to instantiate also the borders of the maze
        */
        for (int i = -1; i < maze_height+1; i++){
            for (int j = -1; j < maze_width+1; j++){
                //Decide to instantiate the wall or the floor
                GameObject prefab;
                if (i == -1 || i == maze_height || j == -1 || j == maze_width || matrix_Maze[i, j] == Object_Maze.CODE_WALL){
                    prefab = prefab_wall;
                }
                else {
                    prefab = prefab_floor;
                }

                Vector2 coordinates = getCoordinates(i, j);
                Instantiate(prefab, coordinates, Quaternion.identity);
            }
        }
    }
}
