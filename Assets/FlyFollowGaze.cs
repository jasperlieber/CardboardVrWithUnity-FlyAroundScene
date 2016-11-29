using UnityEngine;
using System.Collections;

public class FlyFollowGaze : MonoBehaviour {

    [Range(1f, 30f)]
    public float thrust;

    //[Range(1f, 20f)]
    //public float inputUpdates = 10f;

    public Camera myCamera;

    // Use this for initialization
    void Start()
    {

        Debug.Log("in start, thrust = " + thrust);
        //thrust = 3f;
        myCamera = Camera.main;
    }


    private float bxmax = 50f, bxmin = -50f,
                    bymax = 200f, bymin = .5f,
                    bzmax = 50f, bzmin = -50f;

    private static bool btnDown = false;

    private int forwardOrReverse = 1;
    private Vector3 screenPos;
    private bool screenIsTouched;

    private void CheckTouch()
    {
        if (Input.GetMouseButtonUp(0))
        {
            btnDown = false;
            forwardOrReverse = -forwardOrReverse;
            //thrust = 2;
        }
        if (Input.GetMouseButtonDown(0))
        {
            btnDown = true;
        }

        if (btnDown)
        {
            //thrust += .1f;
            //screenPos = Input.mousePosition;
        }

        //Debug.Log("thrust = " + thrust);

        screenIsTouched = Input.touchCount > 0;

        bool moveTransform = screenIsTouched || btnDown;// && !btnUp;

        //return moveTransform;

        //float time = Time.time;
        //float delta = time - mLastInputSend;
        //float delay = 1f / inputUpdates;

        //return;

        // Don't send updates more than 20 times per second
        if (/*delta > 0.05f &&*/ moveTransform)
        {
            //mLastInputSend = time;

            //Debug.Log(transform.position.y);
            //Camera
            transform.position += myCamera.transform.forward * thrust * Time.deltaTime * forwardOrReverse;

            transform.position = new Vector3(
                Mathf.Max(Mathf.Min(transform.position.x, bxmax), bxmin),
                Mathf.Max(Mathf.Min(transform.position.y, bymax), bymin),
                Mathf.Max(Mathf.Min(transform.position.z, bzmax), bzmin));
        }
        //Debug.Log(moveTransform);
    }

    protected float mLastInputSend = 0f;

    // Update is called once per frame
    void Update()
    {
        CheckTouch();
        //Debug.Log(transform.position.y);

        //transform.position += this.transform.forward * thrust * Time.deltaTime;

        //if (transform.position.y < .25f)
        //{
        //    Debug.Log("under");

        //    transform.position = new Vector3(transform.position.x, .25f, transform.position.z);
        //}

    }
}
