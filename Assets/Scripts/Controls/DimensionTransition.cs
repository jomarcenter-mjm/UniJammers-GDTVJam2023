using UnityEngine;
using UnityEngine.UI;

public class RenderTextureSwitcher : MonoBehaviour
{
    [SerializeField] private Camera fPCam;   //first parent camera selectebale
   [SerializeField] private Camera tDCam;   //Top Down camera selectable
   [SerializeField] private RawImage smallScreenRawImage;  // RawImage component to display the camera output
    [SerializeField] private RawImage largeSCreenRawImage;  // RawImage component to display the camera output

    

   private void Start()
    {
        // Make sure at least one camera and RawImage are assigned
        if (fPCam == null || tDCam == null)
        {
            Debug.LogError("A camera is not assigned");
            return;

        }

        if (smallScreenRawImage == null || largeSCreenRawImage == null)
        {
            Debug.LogError("An image is not assigned");
            return;

        }        
    }

    private void Update()
    {
        // Check for input to switch camera outputs
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            
            SwitchScreens();
                       
        }
    }
    private void SwitchScreens()
        {
        Debug.Log("small = " + smallScreenRawImage.texture + "Large = " +largeSCreenRawImage.texture +  "\nfpCam = " + fPCam.targetTexture +"tDCam = " + tDCam.targetTexture  );

        //Reassign the target Textures to the other camera.
        fPCam.enabled = false;
        tDCam.enabled = false;
        if (smallScreenRawImage.texture == fPCam.targetTexture)
        {            
            smallScreenRawImage.texture = tDCam.targetTexture;
            largeSCreenRawImage.texture = fPCam.targetTexture;
        } else 
        {            
            smallScreenRawImage.texture = fPCam.targetTexture;
            largeSCreenRawImage.texture = tDCam.targetTexture;
        }
        fPCam.enabled = true;
        tDCam.enabled = true;
        Debug.Log("AFTER small = " + smallScreenRawImage.texture + "Large = " + largeSCreenRawImage.texture + "\nfpCam = " + fPCam.targetTexture + "tDCam = " + tDCam.targetTexture);
       

    }
}
