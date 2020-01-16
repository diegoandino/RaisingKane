using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class WebCam : MonoBehaviour
{
    int currentCamIndex = 0;

    WebCamTexture tex;
    private string _SavePath = "C:/Users/u1082216/Documents/GitHub/RaisingKane/Assets/Art/Screenshots/";
    public RawImage display;
    int _CaptureCounter = 0;
    public SpriteRenderer CameraDetectedCheckMark;
    public SpriteRenderer pictureTakenCheckMark;
    public SpriteRenderer replaceImageCheckMark;
    public SpriteRenderer testImage;
    public Sprite original;
    public Sprite replacement;




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
        if (tex != null)
        {
            display.texture = null;
            tex.Stop();
            tex = null;


        }
        else
        {
            WebCamDevice device = WebCamTexture.devices[currentCamIndex];
            tex = new WebCamTexture(device.name);
            display.texture = tex;
            display.material.mainTexture = tex;
            tex.Play();
            CameraDetectedCheckMark.transform.position = new Vector3(CameraDetectedCheckMark.transform.position.x, CameraDetectedCheckMark.transform.position.y, -2);
        }

    }

    //TAKING A PICTURE
    public void takePicture_Clicked()
    {

        pictureTakenCheckMark.transform.position = new Vector3(pictureTakenCheckMark.transform.position.x, pictureTakenCheckMark.transform.position.y, -2);

        Texture2D screenshot = new Texture2D(tex.width, tex.height);
        screenshot.SetPixels(tex.GetPixels());
        screenshot.Apply();

        byte[] bytes = screenshot.EncodeToPNG();

        System.IO.File.WriteAllBytes(_SavePath + _CaptureCounter.ToString() + ".png", screenshot.EncodeToPNG());

        ++_CaptureCounter;

        tex.Stop();
    }

    //REPLACING IMAGE FROM DIRECTORY
    public void replaceImage_Clicked()
    {
        replaceImageCheckMark.transform.position = new Vector3(replaceImageCheckMark.transform.position.x, replaceImageCheckMark.transform.position.y, -2);

        getImage();

    }

    //GETTING IMAGE FROM DIRECTORY
    public void getImage()
    {
        
    }

    

    // Start is called before the first frame update
    void Start()
    {
        testImage.sprite = original;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
}

   
    


