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
    }

    void Update()
    {
        x -= 1;

        if (x + width < 0)
        {
            GroundSpawnEvent.Invoke();
            LateDestroy();
        }
    }
}
