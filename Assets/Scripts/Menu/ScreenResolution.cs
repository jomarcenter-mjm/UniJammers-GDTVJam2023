using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;


/// <summary>
/// This handles Screen resolution controls for unity
/// </summary>
public static class ScreenResolution
{
  public static Resolution[] GetResolutionList()
  {
    return Screen.resolutions;
  }

  public static bool GetFullScreen()
  {
    return Screen.fullScreen;
  }

  public static void SetNewResolution(bool NewFullScreen)
  {
    Screen.fullScreen = NewFullScreen;
  }

  public static void SetNewResolution(bool NewFullScreen, int width, int height)
  {
    Screen.SetResolution(width, height, NewFullScreen);
  }
}
