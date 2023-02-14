using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game {

	Player player;
	List<Ground> ground;
	ControlClass controlClass = new ControlClass();

	public MyGame() : base(DesignerClass.wWidth, DesignerClass.wHeight, DesignerClass.fullScreen, false, -1, -1, false)
	{
		player = new Player();
		
		ground = new List<Ground>();

        for (int i = 0; i < (width / DesignerClass.groundWidth) + 1; i++)
		{
			ground.Add(new Ground(0));
		}

        int groundId = 0;
        foreach (Ground x in ground)
		{
			x.GroundSpawnEvent += Ground_GroundSpawnEvent;
            x.x += 50 * groundId;
			AddChild(x);
			groundId++;
		}
		groundId = 0;
		
		AddChild(player);
		AddChild(controlClass);

		Console.WriteLine("MyGame initialized");
	}

	// For every game object, Update is called every frame, by the engine:
	void Update() {
		// Empty
	}

    private void Ground_GroundSpawnEvent()
    {
        ground.Add(new Ground(width));
		ground[ground.Count - 1].GroundSpawnEvent += Ground_GroundSpawnEvent;
        AddChild(ground[ground.Count -1]);
    }

    static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}