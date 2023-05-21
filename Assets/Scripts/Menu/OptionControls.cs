using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class OptionControls : MonoBehaviour
{

  //Buttons and controls
  public Dropdown resolutionList;
  public Button acceptButton;


  //Screen Resolution Data
  bool currentFullScreen = false;

    // Get all Resolution information
    void Awake()
    {
    var resolutions = ScreenResolution.GetResolutionList();
    currentFullScreen = ScreenResolution.GetFullScreen();
    List<string> allOptions = new List<string>();

    foreach (var item in resolutions)
    {
      allOptions.Add($"{item.width}X{item.height}");
    }

    resolutionList.AddOptions(allOptions);
    }

  public void ApplyAllInformation()
  {
    //Resolution
    string[] resolution = resolutionList.options[resolutionList.value].text.Split("X");
    if (!int.TryParse(resolution[0], out int width))
    {

    }
    if (!int.TryParse(resolution[0], out int height))
    {

    }
    ScreenResolution.SetNewResolution(currentFullScreen, width, height);
  }

    
}
