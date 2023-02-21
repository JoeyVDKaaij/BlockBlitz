using GXPEngine;
using System;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using TiledMapParser;

public class PlaceHolder : AnimationSpriteAddOn
{
    public event Action PlaceHolderReplaceWithBlockEvent;
    public event Action PlaceHolderDestroyEvent;
    private double xSpeed = DesignerClass.xStartingSpeed;

    private int obstacle;
    private int currentObstacle = 0;
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
        width = DesignerClass.groundWidth;
        height = DesignerClass.groundHeight;
        //x = pX;
        //y = DesignerClass.wHeight - height * DesignerClass.groundCountDefault + pY * height;
    }

    void Update()
    {
        x -= (float)xSpeed;
        xSpeed += DesignerClass.XSpeedUp;

        /*
        if (player1 == null)
        {
            player1 = parent.FindObjectOfType<Player>();
        }
        else
        {
            Console.WriteLine(parent.FindObjectOfType<Player>().x);
        }
        */
        if (ControlClass.up && x < DesignerClass.wWidth || ControlClass.down && x < DesignerClass.wWidth || ControlClass.left && x < DesignerClass.wWidth || ControlClass.right && x < DesignerClass.wWidth)
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
            currentObstacle = obstacle;
            //Console.WriteLine("YAY");
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
        /*
        Collision placeHolder = MoveUntilCollision(-1, 0);

        if (x + width < 0)
        {
            PlaceHolderDestroyEvent.Invoke();
        }

        if (ControlClass.up) PlaceHolderReplaceWithBlockEvent.Invoke();
        */
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