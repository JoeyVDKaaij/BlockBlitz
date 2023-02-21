using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Block : Sprite
{

    public event Action BlockDestroyEvent;
    private double xSpeed = DesignerClass.xStartingSpeed;

    public Block(float pX, float pY, double pXSpeed) : base("colors.png", false, true)
    {
        width = 64;
        height = 64;
        x = pX - width/2f;
        y = pY - height / 2f;
        xSpeed = pXSpeed;
        Console.WriteLine("created");
        Console.WriteLine("X: " + x);
        Console.WriteLine("Y:" + y);
    }

    void Update()
    {
        x -= (float)xSpeed;
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