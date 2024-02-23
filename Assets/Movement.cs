using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Rigidbody rb;
    [SerializeField] float forceMag;


    [SerializeField] GameObject lane1Cube;
    [SerializeField] GameObject lane2Cube;
    [SerializeField] GameObject lane3Cube;

    private Vector3[] lanePos;

    int currentLaneIndex;
    int targetIndex;

    void Start()
    {
        Debug.Log("Start");
        lanePos = new Vector3[3];

        currentLaneIndex = 1;
        targetIndex = 1;

        lanePos[0] = lane1Cube.transform.position;
        lanePos[1] = lane2Cube.transform.position;
        lanePos[2] = lane3Cube.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * forceMag);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (currentLaneIndex != 0)
                targetIndex = currentLaneIndex - 1;

            currentLaneIndex = targetIndex;

            Debug.Log(lanePos[targetIndex]);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            if (currentLaneIndex != 2)
                targetIndex = currentLaneIndex + 1;

            currentLaneIndex = targetIndex;



            Debug.Log(lanePos[targetIndex]);
        }

        var step = 20f * Time.deltaTime; // calculate distance to move
        transform.position = Vector3.MoveTowards(transform.position, lanePos[targetIndex], step);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Coin")
            Destroy(collision.gameObject);
    }
}
