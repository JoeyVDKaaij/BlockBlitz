using GXPEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ControlClass : GameObject
{
    // Don't touch these lines
    static public bool up;
    static public bool down;
    static public bool left;
    static public bool right;
    static public bool jump;

    void Update()
    {
        // Change the input.
        // Change the value by changing Key.W to Key.[your preferred input] for example
        // To add an input add the following behind the current input: || Input.GetKey(Key.[your preferred input]);
        up = Input.GetKey(Key.W) || Input.GetKey(Key.UP);
        down = Input.GetKey(Key.S) || Input.GetKey(Key.DOWN);
        left = Input.GetKey(Key.A) || Input.GetKey(Key.LEFT);
        right = Input.GetKey(Key.D) || Input.GetKey(Key.RIGHT);
        jump = Input.GetKey(Key.SPACE);
    }
}
