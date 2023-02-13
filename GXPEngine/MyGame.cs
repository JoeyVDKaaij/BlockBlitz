using System;                                   // System contains a lot of default C# libraries 
using GXPEngine;                                // GXPEngine contains the engine
using System.Drawing;                           // System.Drawing contains drawing tools such as Color definitions
using System.Collections.Generic;

public class MyGame : Game {

	Player player;
	List<Ground> ground;

	public MyGame() : base(DesignerClass.wWidth, DesignerClass.wHeight, false, false, -1, -1, true)
	{
		player = new Player();

		ground = new List<Ground>();

		ground.Add(new Ground());

		// NEED TO LOOK INTO THIS LATER
		//ground.ForEach(x => AddChild(ground[x]));

		

		//ground.Find();
        AddChild(player);

		Console.WriteLine("MyGame initialized");
	}

	// For every game object, Update is called every frame, by the engine:
	void Update() {
		// Empty
	}

	static void Main()                          // Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}