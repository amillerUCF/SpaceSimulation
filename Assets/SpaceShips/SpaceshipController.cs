using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Controls and Physics for Spaceship:
 *  
 *  'Shift' and 'Ctrl' - Forwards and backwards respectively
 *  'A' and 'D' - Roll left and right respectively
 *  'W' and 'S' - Pitch down and up respectively
 *  Mouse = Yaw left and right respectively
 */

public class SpaceshipController : MonoBehaviour {

    private float powerCap = 100;           // Cap of overall forward/backward thruster power
    private float rateOfPowerChange = 0.5f; // Rate that power increases/decreases
    private float magnitudeOfDirection;     // This is the power for the current direction that we are traveling (e.g. Shift (+) and Ctrl (-)).
                                            // Throttle up and down

    private float rollSpeed = 0.5f;         // Roll
    private float pitchSpeed = 0.5f;        // Pitch
    private float yawSpeed = 0.25f;         // Yaw

    private float speed = 0.05f;            // Overall speed of the ship

    /* Temporary Vector Variables */
    protected Vector3 movementVector = new Vector3(0.0f, 0.0f, 0.0f);
    protected Vector3 rollVector = new Vector3(0.0f, 0.0f, 0.0f);
    protected Vector3 pitchVector = new Vector3(0.0f, 0.0f, 0.0f);
    protected Vector3 yawVector = new Vector3(0.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
        magnitudeOfDirection = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        // Update forward/backward movement
        movementVector.x = speed * magnitudeOfDirection;
        transform.Translate(movementVector);

        // Rotate on roll
        transform.Rotate(rollVector);

        // Rotate on pitch
        transform.Rotate(pitchVector);

        // Rotate on yaw
        transform.Rotate(yawVector);


        /* Update roll vector */
        // If positive roll
        if (Input.GetKey(KeyCode.A))
            rollVector.x = rollSpeed;
        // If negative roll
        else if (Input.GetKey(KeyCode.D))
            rollVector.x = -rollSpeed;
        // Otherwise, reset
        else
            rollVector.x = 0.0f;


        /* Update pitch vector */
        // If positive pitch
        if (Input.GetKey(KeyCode.S))
            pitchVector.z = pitchSpeed;
        // If negative pitch
        else if (Input.GetKey(KeyCode.W))
            pitchVector.z = -pitchSpeed;
        // Otherwise, reset
        else
            pitchVector.z = 0.0f;


        /* Update yaw vector */
        // If positive yaw (left)
        if (Input.GetAxis("Mouse X") < 0)
            yawVector.y = -yawSpeed;
        // If negative yaw (right)
        else if (Input.GetAxis("Mouse X") > 0)
            yawVector.y = yawSpeed;
        // Otherwise, reset
        else
            yawVector.y = 0.0f;


        /* Increase thruster power when "LeftShift" is held */
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // If magnitude of power is not capped out
            if (magnitudeOfDirection < powerCap)
                magnitudeOfDirection += rateOfPowerChange; // Increase power
            print("Power: " + magnitudeOfDirection);
        }

        /* Decrease thruster power when "LeftCtrl" is held */
        if (Input.GetKey(KeyCode.LeftControl))
        {
            // If magnitude of power is not capped out
            if (magnitudeOfDirection > -powerCap)
                magnitudeOfDirection -= rateOfPowerChange; // Decrease power
            print("Power: " + magnitudeOfDirection);
        }

    }
}
