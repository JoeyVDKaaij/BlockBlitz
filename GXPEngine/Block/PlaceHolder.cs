using GXPEngine;
using System;
using System.Diagnostics.Contracts;
using System.Diagnostics.Eventing.Reader;
using System.Runtime.InteropServices;
using System.Threading;
using TiledMapParser;

public class PlaceHolder : AnimationSpriteAddOn
{
    public static bool resetblock = false;
    public event Action PlaceHolderReplaceWithBlockEvent;
    public event Action PlaceHolderDestroyEvent;
    private double xSpeed = DesignerClass.xStartingSpeed;

    private int obstacle;
    public static int currentObstacle = 0;
    private int column;
    private int row;

    private int chosenOption;
    private float placeHolderX;

    Sound blockSoundEffect = new Sound(DesignerClass.placeBlockSoundEffect);

    public static bool blockPlacedDown = false;
    public static int blockPlacedDownCoolDown = 10000;

    public PlaceHolder(string fileName, int colums, int rows, TiledObject placeHolderObject = null) : base(fileName, colums, rows, -1, false, false)
    {
        if (placeHolderObject != null)
        {
            obstacle = placeHolderObject.GetIntProperty("obstacle");
            row = placeHolderObject.GetIntProperty("row");
            column = placeHolderObject.GetIntProperty("column");
            placeHolderX = placeHolderObject.X;
            visible = false;
        }
        //x = pX;
        //y = DesignerClass.wHeight - height * DesignerClass.groundCountDefault + pY * height; 
        //MyGame.placeHolderWithObstacles[obstacle]++;
        //Console.WriteLine("Obstacle: " + MyGame.placeHolderWithObstacles[obstacle]);
    }

    void Update()
    {
        if (x < Player.playerX + 1920 && x > Player.playerX - 64 * 4)
        {
            visible = true;
        }
        else
        {
            visible = false;
        }

        if (blockPlacedDown)
        {
            blockPlacedDownCoolDown--;
        }

        if (blockPlacedDownCoolDown == 0)
        {
            blockPlacedDown = false;
            blockPlacedDownCoolDown = 10000;
        }

        if (ControlClass.up && x < Player.playerX + game.width || ControlClass.down && x < Player.playerX + game.width || ControlClass.left && x < Player.playerX + game.width || ControlClass.right && x < Player.playerX + game.width)
        {
            if (ControlClass.up)
            {
                chosenOption = 0;
                CheckBlock(chosenOption);
            }
            else if (ControlClass.left)
            {
                chosenOption = 1;
                CheckBlock(chosenOption);
            }
            else if (ControlClass.down)
            {
                chosenOption = 2;
                CheckBlock(chosenOption);
            }
            else if (ControlClass.right)
            {
                chosenOption = 3;
                CheckBlock(chosenOption);
            }

            if (!blockPlacedDown)
            {
                blockSoundEffect.Play(false, 0, DesignerClass.placeBlockSoundEffectVolume * DesignerClass.soundEffectVolume, 0);
                blockPlacedDown = true;
            }
        }
    }

    void CheckBlock(int pChosenOption)
    {
        if (DesignerClass.blocks[obstacle, pChosenOption, row - 1, column - 1] == 1)
        {
            ReplacePlaceHolderWithBlock(resetblock);
        }
        else
        {
            DeletePlaceHolder();
        }
    }

    void ReplacePlaceHolderWithBlock(bool pResetBlock)
    {
        if (!pResetBlock)
        {
            Block temp = new Block(x, y, xSpeed);
            parent.AddChild(temp);
        }
    }

    void DeletePlaceHolder()
    {
        LateDestroy();
    }
}