using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls the speed of the projectiles.
/// </summary>
public class ArchProjectile : Projectile
{
    public  float BPM = 86;           //Tells how fast the rhythm is going. (BPM - Beats per minute)
    public  float laneSpeed;     //added Lanespeed for the different arcs of the lanes
    public  float ProjectileSpeed;
    private float count = 0.0f;
    private List<Vector3> points;

    public bool hasStarted;     //If gameplay has started 
    public Vector3 StartPoint;
    public Vector3 EndPoint;

    // Start is called before the first frame update
    void Start()
    {
        BPM = BPM / 60f;        //I believe this is the tempo / by 60 seconds to make it a minute.
        laneSpeed = 10f;
        StartPoint = new Vector3(7.5f, -4, 1);
        points = new List<Vector3>();

        points.Add(StartPoint);
        points.Add(EndPoint);
        points.Add(points[0] + (points[1] - points[0]) / 2 + Vector3.up * 60.0f);
    }

    // Update is called once per frame
    void Update()
    {
        this.BeatCheck();

        if (hasStarted)
        {
            if (count < 1f)
            {
                count += ProjectileSpeed * Time.deltaTime;

                Vector3 m1 = Vector3.Lerp(points[0], points[2], count);
                Vector3 m2 = Vector3.Lerp(points[2], points[1], count);
                transform.position = Vector3.Lerp(m1, m2, count);
            }

            if (count > 1f)
            {
                transform.position -= new Vector3(0f, (BPM * Time.deltaTime) * BP2_MusicSettings.instance.songSpeed * laneSpeed, 0f);
            }
            //Vector3(x,y,z)
            //The function to move NoteObjects from left to right
        }
    }
}
