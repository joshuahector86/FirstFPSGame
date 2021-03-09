using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class Axis
{
    //Helpers for defining the horizontal and vertical axes. Use this to avoid the string method in other scripts
    //declared public to allow for other scripts and functions to be able to pick up on this setting
    //defined with const to make sure that we cannot alter this variable ever
    public const string HORIZONTAL = "Horizontal";
    public const string VERTICAL = "Vertical";
}


public class MouseAxis
{
    public const string MOUSE_X = "Mouse X";
    public const string MOUSE_Y = "Mouse Y";

}