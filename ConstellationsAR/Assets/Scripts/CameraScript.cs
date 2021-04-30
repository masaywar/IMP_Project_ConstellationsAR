using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraScript : MonoBehaviour
{

    private WebCamTexture WebCam;
    private float UserTime = 12.0f;
    private float CelestialTime = 0.0f;
    private float latitude = 0.0f;


    private Quaternion vUserCeiling = new Quaternion(0, 0, 1, 0);
    private Quaternion vGyro = Quaternion.Euler(0f, 180f, 180f);
    private Quaternion vCamera = new Quaternion(0, 0, 1, 0);


    private GameObject Earth;
    private GameObject UserScope;
    private GameObject GyroScope;

    private static Vector3 LookAtVector;
    private static Coord LookAtCoord = new Coord(0.0f, 0.0f);
    private static Coord Sun = new Coord(12.0f, 0.0f);

    private Quaternion rotation;
    private bool arReady = false;

    public RawImage background;
    public AspectRatioFitter fit;
    //public Text text = null;



    /* TODO
     * 
     * UserTime Setup
     * SunCoord Setup
     * Latitude Setup
     * 
     * 
     */
    void Start()
    {
        if (!SystemInfo.supportsGyroscope)
        {
            Debug.Log("this device does not have Gyroscope");
            return;
        }

        GyroAdapt();
        InvokeRepeating("UserCeilingUpdate", 0f, 3f);
        InvokeRepeating("CoordUpdate", 0f, 3f);
        
    }

    void Update()
    {
        transform.localRotation = Input.gyro.attitude * vCamera;

        LookAtVector = transform.forward;
        VecterToCoord(LookAtVector);
            
        //text.text =
        //    LookAtCoord.getAsc() + " " + LookAtCoord.getDec();
    }

    public class Coord
    {
        float asc;
        float dec;

        public Coord(float asc, float dec)
        {

            this.asc = asc; this.dec = dec;

        }
        public float getAsc() { return asc; }
        public float getDec() { return dec; }
        public void setAsc(float asc) { this.asc = asc; }
        public void setDec(float dec) { this.dec = dec; }


    }

    public static Quaternion CoordToQuarternion()
    {
        return new Quaternion(0, 0, 0, 0);

    }

    public static Coord VecterToCoord(Vector3 vec)
    {


        float asc;

        Vector3 XZ_Plane = new Vector3(vec.x, 0f, vec.z);
        asc = Vector3.Angle(Vector3.back, XZ_Plane);
        asc *= XZ_Plane.x / Mathf.Abs(XZ_Plane.x);

        float dec;

        dec = Vector3.Angle(XZ_Plane, vec);
        dec *= vec.y / Mathf.Abs(vec.y);

        if (asc < 0) asc += 360.0f;
        asc /= 15.0f;

        LookAtCoord.setAsc(asc);
        LookAtCoord.setDec(dec);

        return LookAtCoord;

    }

    public static float TimeToAngle(float time)
    {

        return time * 15.0f;

    }

    public static float RadianToTime(float rad)
    {

        return 0.0f;

    }

    public static float AngleToRadian(float angle)
    {

        return angle / 180.0f * Mathf.PI;

    }

    private void CoordUpdate()
    {

        CelestialTime = UserTime - Sun.getAsc();

        // need to update sun;
        // need to update latitude;

    }

    private void UserCeilingUpdate()
    {

        float rotate_X = latitude;
        float rotate_Y = TimeToAngle(CelestialTime);

        UserScope.transform.localRotation = Quaternion.Euler(-rotate_X, -rotate_Y, 0f);

    }

    private void GyroAdapt()
    {


        Earth = new GameObject("Earth");
        UserScope = new GameObject("UserScope");
        GyroScope = new GameObject("GyroScope");

        Earth.transform.position = transform.position;
        UserScope.transform.position = transform.position;
        GyroScope.transform.position = transform.position;


        UserScope.transform.SetParent(Earth.transform);
        GyroScope.transform.SetParent(UserScope.transform);
        transform.SetParent(GyroScope.transform);

        Input.gyro.enabled = true;
        Input.gyro.updateInterval = 0.01f;

        Earth.transform.rotation = Quaternion.Euler(0f, 180f, 23.5f);
        GyroScope.transform.localRotation = vGyro;
        vCamera = new Quaternion(0, 0, 1, 0);

    }

}

