using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WebCam : MonoBehaviour
{   
    //Webcam Declarations
    int currentCamIndex = 0;

    WebCamTexture tex;
    private string _SavePath = @"Assets\Resources\";
    public RawImage display;
    public Sprite replacementSprite;
    int _CaptureCounter = 0;

    //Sprite Renderers
    public SpriteRenderer testImage;
    public SpriteRenderer CameraDetectedCheckMark;
    public SpriteRenderer pictureTakenCheckMark;
    public SpriteRenderer replaceImageCheckMark;
    




    /*public void SwapCam_Clicked()
    {
        if(WebCamTexture.devices.Length >0)
        {
            currentCamIndex += 1;
            currentCamIndex %= WebCamTexture.devices.Length;
        }
    }
    */

    //ACTIVATING CAMERA
    public void startStopCamera_Clicked()
    {
        //if no camera deteced, declare camera null
        if (tex != null)
        {
            display.texture = null;
            tex.Stop();
            tex = null;


        }
        //if camera is deteced, cast video as a texture to the raw image
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;
            display.material.mainTexture = tex;
            tex.Play();

            //play checkmark camera detected
            CameraDetectedCheckMark.transform.position = new Vector3(CameraDetectedCheckMark.transform.position.x, CameraDetectedCheckMark.transform.position.y, -2);
        }

    }

    //TAKING A PICTURE AND STORING THE FILE AS A SPRITE
    public void takePicture_Clicked()
    {
        //play checkmark picture taken
        pictureTakenCheckMark.transform.position = new Vector3(pictureTakenCheckMark.transform.position.x, pictureTakenCheckMark.transform.position.y, -2);

        //capture the current texture feed
        Texture2D screenshot = new Texture2D(tex.width, tex.height);
        //turn the feed into a pack of pixels
        screenshot.SetPixels(tex.GetPixels());
        screenshot.Apply();

        //encode the pixel info as a png type
        byte[] bytes = screenshot.EncodeToPNG();

        //writing the png into a file at the directory specified
        System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", screenshot.EncodeToPNG());

        //turning the screenshot texture into a Sprite

        //creating the containment parameters of the sprite
        Rect rect = new Rect(0, 0, screenshot.width, screenshot.height);

        //seeking vector pivot points of sprite
        Vector2 vect = new Vector2(.5f, .5f);

        //creating the replacement sprite from the screenshot
        replacementSprite = Sprite.Create(screenshot, rect, vect, 80);
        
        
        //if more than one screenshot is allowed, name it ++ (0, 1, 2, etc)
        ++_CaptureCounter;

        //stop camera feed (DISABLE TO KEEP CAMERA LIVE)
        tex.Stop();
    }

    //REPLACING IMAGE FROM CURRENT QUEUED SCREENSHOT
    public void replaceImage_Clicked()
    {
        //play checkmark replaced image
        replaceImageCheckMark.transform.position = new Vector3(replaceImageCheckMark.transform.position.x, replaceImageCheckMark.transform.position.y, -2);

              //GameObject replacement = GameObject.Find("Test");

              //replacement.GetComponent<SpriteRenderer>().sprite = replacementSprite;

        //replacing the original image with the replacement Sprite
        testImage.sprite = replacementSprite;
        
    }

}

   
    


