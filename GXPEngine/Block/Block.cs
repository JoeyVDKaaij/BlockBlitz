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

    public Block(float pX, float pY, double pXSpeed) : base(ArtistClass.blockFileName, false, true)
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
        visible = false;
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
    }
}