using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameStatics
{
    public static (float width, float heigh) screenSize => (1080.0f, 1920.0f);

    public static float screenRatio => Screen.width / screenSize.width;
}
