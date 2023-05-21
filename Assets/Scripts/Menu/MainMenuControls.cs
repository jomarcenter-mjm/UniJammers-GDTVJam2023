using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControls : MonoBehaviour
{

  /// <summary>
  /// This option start the game
  /// </summary>
  public void StartGame()
  {
    //Code to switch to game scene
  }

  public void OptionMode()
  {
    
  }
  /// <summary>
  /// This code exit the game also run OnApplicationQuit if there any contents
  /// </summary>
  public void ExitGame()
  {
    Application.Quit();
  }
}
