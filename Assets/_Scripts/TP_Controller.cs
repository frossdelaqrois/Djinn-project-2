using UnityEngine;
using System.Collections;

public class TP_Controller : MonoBehaviour 
{
	// Use this for initialization
	public static CharacterController CharacterController;
	public static TP_Controller Instance;

	
	void Awake () {
		
		CharacterController = GetComponent("CharacterController") as CharacterController;
		Instance = this;
		TP_Camera.UseExistingOrCreateNewMainCamera();
	}
	
	// No Camera Dont do ANYTHING!
	
	void Update () {
		if (Camera.mainCamera == null)
			return;
		
		GetLocomotionInput();
		
		TP_Motor.Instance.UpdateMotor();
	}
	void GetLocomotionInput()
	{
		//this is to change your deadzone on controller
		var deadZone = 0.1f;
			
		TP_Motor.Instance.MoveVector = Vector3.zero;
		
		if (Input.GetAxis("Vertical") > deadZone || Input.GetAxis("Vertical") < -deadZone)
			TP_Motor.Instance.MoveVector += new Vector3(0,0,Input.GetAxis("Vertical"));
		
		if (Input.GetAxis("Horizontal") > deadZone || Input.GetAxis("Horizontal") < -deadZone)
			TP_Motor.Instance.MoveVector += new Vector3(Input.GetAxis("Horizontal"),0,0);
	}
}

