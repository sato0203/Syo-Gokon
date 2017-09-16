//Class used to represent a chamber
//that is an empty room in the maze
//Author: Vittorio Morrone

//-------Main Class-------
public class Object_Chamber {
    //-------Variables-------
    private int iCoordinate; //The i and j coordinates of the top left cell, relative to the maze matrix
    private int jCoordinate;
    private int height; //The dimensions off the empty space
    private int width;

    //-------Constructors-------
    public Object_Chamber(int iCoordinate, int jCoordinate, int height, int width) {
        this.iCoordinate = iCoordinate;
        this.jCoordinate = jCoordinate;
        this.height = height;
        this.width = width;
    }

    //-------Class methods-------
    //Returns true if one of the dimensions of the chamber is
    //greater then 2
    public bool isDivisible() {
        return (height > 2 || width > 2) && !(height < 2 || width < 2);
    }

    //-------Get methods-------
    public int getWidth() {
        return width;
    }

    public int getHeight() {
        return height;
    }

    public int getI() {
        return iCoordinate;
    }

    public int getJ() {
        return jCoordinate;
    }

    //-------ToString-------
    public override string ToString() {
        return ("I: " + iCoordinate + " J: " + jCoordinate + " Height: " + height + " Width: " + width);
    }
}
