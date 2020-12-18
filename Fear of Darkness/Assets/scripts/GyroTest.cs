using UnityEngine;


/// <summary>
/// Gyroscope demo. Attach to a visible object or camera.
/// </summary>
public class GyroTest : MonoBehaviour
{

	Quaternion origin = Quaternion.identity;


	void Start()
	{
		Input.gyro.enabled = true;
		origin = Input.gyro.attitude;
	}


	void Update()
	{
		// reset origin on touch or not yet set origin
		if (Input.touchCount > 0 || origin == Quaternion.identity)
			origin = Input.gyro.attitude;

		transform.localRotation = Quaternion.Inverse(origin) * Input.gyro.attitude;
	}


	void OnGUI()
	{
		GUILayout.Label(origin.eulerAngles + " <- origin");
		GUILayout.Label(Input.gyro.attitude.eulerAngles + " <- gyro");
		GUILayout.Label(Quaternion.Inverse(Input.gyro.attitude).eulerAngles + " <- inv gyro");
		GUILayout.Label(transform.localRotation.eulerAngles + " <- localRotation");
	}

}