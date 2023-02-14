using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Ground : Sprite
{
    public event Action GroundSpawnEvent;

    public Ground(int pX) : base(ArtistClass.groundFileName, false, true)
    {
        width = DesignerClass.groundWidth;
        height = DesignerClass.groundHeight;
        x = pX;
        y = DesignerClass.wHeight - height;
        Console.WriteLine("Ground Created");
    }

    void Update()
    {
        x--;
        if (x < 0)
        {
            GroundSpawnEvent.Invoke();
            LateDestroy();
        }
    }
}
