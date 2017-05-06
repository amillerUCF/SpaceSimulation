using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/** Controls and Physics for Spaceship:
 *  
 *  'Shift' and 'Ctrl' - Forwards and backwards respectively
 *  'A' and 'D' - Roll left and right respectively
 *  'W' and 'S' - Pitch up and down respectively
 *  Mouse = Yaw left and right respectively
 */

public class SpaceshipController : MonoBehaviour {

    public float powerCap;              // Cap of overall forward/backward thruster power
    public float rateOfPowerChange;     // Rate that power increases/decreases
    private float magnitudeOfDirection; // This is the power for the current direction that we are traveling (e.g. Shift (+) and Ctrl (-)).
                                        // Throttle up and down

    public float rollSpeed;             // Roll
    public float pitchSpeed;            // Pitch
    public float yawSpeed;              // Yaw

    public float speed;                 // Overall speed of the ship

    /* Temporary Variables */
    Vector3 movementVector = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 rollVector = new Vector3(0.0f, 0.0f, 0.0f);

    // Use this for initialization
    void Start () {
        magnitudeOfDirection = 0.0f;
	}
	
	// Update is called once per frame
	void Update () {

        // Update forward/backward movement
        movementVector.x = speed * magnitudeOfDirection;
        transform.Translate(movementVector);


        /* Update roll movement */
        // If positive roll
        if (Input.GetKey(KeyCode.A))
            rollVector.x = rollSpeed;

        // If negative roll
        else if (Input.GetKey(KeyCode.D))
            rollVector.x = -rollSpeed;

        else
            rollVector.x = 0.0f;

        transform.Rotate(rollVector); // Update roll


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
