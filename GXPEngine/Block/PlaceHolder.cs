using GXPEngine;
using System;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using TiledMapParser;

public class PlaceHolder : AnimationSpriteAddOn
{
    public event Action PlaceHolderReplaceWithBlockEvent;
    public event Action PlaceHolderDestroyEvent;
    private double xSpeed = DesignerClass.xStartingSpeed;

    private int obstacle;
    public static int currentObstacle = 0;
    private int column;
    private int row;

    private int chosenOption;

    public PlaceHolder(string fileName, int colums, int rows, TiledObject placeHolderObject = null) : base(fileName, colums, rows, -1, false, false)
    {
        if (placeHolderObject != null)
        {
            obstacle = placeHolderObject.GetIntProperty("obstacle");
            row = placeHolderObject.GetIntProperty("row");
            column = placeHolderObject.GetIntProperty("column");
        }
        //x = pX;
        //y = DesignerClass.wHeight - height * DesignerClass.groundCountDefault + pY * height; 
        //MyGame.placeHolderWithObstacles[obstacle]++;
        //Console.WriteLine("Obstacle: " + MyGame.placeHolderWithObstacles[obstacle]);
    }

    void Update()
    {
        if (ControlClass.up && x < Level.cameraX + DesignerClass.wWidth || ControlClass.down && x < Level.cameraX + DesignerClass.wWidth || ControlClass.left && x < Level.cameraX + DesignerClass.wWidth || ControlClass.right && x < Level.cameraX + DesignerClass.wWidth)
        {
            if (ControlClass.up)
            {
                chosenOption = 0;
            }
            else if (ControlClass.left)
            {
                chosenOption = 1;
            }
            else if (ControlClass.down)
            {
                chosenOption = 2;
            }
            else if (ControlClass.right)
            {
                chosenOption = 3;
            }
            if (currentObstacle == obstacle)
            {
                if (DesignerClass.blocks[obstacle, chosenOption, row - 1, column - 1] == 1)
                {
                    replacePlaceHolderWithBlock();
                }
                else if (DesignerClass.blocks[currentObstacle, chosenOption, row - 1, column - 1] == 0)
                {
                    deletePlaceHolder();
                }
            }
        }
    }
    void replacePlaceHolderWithBlock()
    {
        Block temp = new Block(x, y, xSpeed);
        parent.AddChild(temp);
    }

    void deletePlaceHolder()
    {
        LateDestroy();
    }
}