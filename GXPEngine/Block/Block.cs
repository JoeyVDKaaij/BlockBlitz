using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GXPEngine;

public class Block : Sprite
{
    public Block(int pX, int pY) : base("colors.png", false, true)
    {
        width = DesignerClass.groundWidth;
        height = DesignerClass.groundHeight;
        x = pX;
        y = DesignerClass.wHeight - height * DesignerClass.groundCountDefault + pY * height;
    }
}