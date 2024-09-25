using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interface
{
    public interface Rotate
    {
        void Right();
        void Left();
        void Up();
        void Down();
    }
    public interface Movement
    {
        void TurnTop();
        void TurnBot();
        void TurnLeft();
        void TurnRight();
    }
}
