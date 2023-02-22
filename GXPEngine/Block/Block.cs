using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Block : Sprite
{

    private int blockPlaced;
    public static int checkObstacle = 0;

    public event Action BlockDestroyEvent;
    private double xSpeed = DesignerClass.xStartingSpeed;

    public Block(float pX, float pY, double pXSpeed) : base("colors.png", false, true)
    {
        width = 64;
        height = 64;
        x = pX - width/2f;
        y = pY - height / 2f;
        xSpeed = pXSpeed;
        blockPlaced++;
        if (MyGame.placeHolderWithObstacles[checkObstacle] == blockPlaced)
        {
            PlaceHolder.currentObstacle++;
            blockPlaced = 0;
        }
    }

    void Update()
    {
        /*
        if (Player.currentlyCrouched)
        {

            x -= (float)xSpeed * Player.xCrouchSpeed;
            Player.xCrouchSpeed -= DesignerClass.playerCrouchSpeedDecrease;
            if (Player.xCrouchSpeed < 0.5) Player.xCrouchSpeed = 0.5f;
        }
        else
        {
            x -= (float)xSpeed;
            Player.xCrouchSpeed = DesignerClass.playerCrouchStartingSpeed;
        }

        xSpeed += DesignerClass.XSpeedUp;

        /*
        x--;

        if (x + width < 0)
        {
            BlockDestroyEvent.Invoke();
        }
        */
    }
}