using UnityEngine;

[System.Serializable]
public class Accelerator
{
	// Variables
	public float pos { get; private set; }
	public float speed { get; private set; }

	// Parameters
	float accel;
	float topSpeed;
	float decel;
	float target;

	public Accelerator(float start = 0, float accel = 0, float topSpeed = 0, float decel = 0, float target = 0)
	{		
		float sign = Mathf.Sign(target - start);
		pos = start;
		speed = 0;

		this.accel = sign * Mathf.Abs(accel);
		this.topSpeed = sign * Mathf.Abs(topSpeed);
		this.decel = sign * Mathf.Abs(decel);
		this.target = target;

		if (accel == 0 || topSpeed == 0 || decel == 0) {
			Debug.LogWarning("Accelerator: invaild settings");
			return;
		}

		if (Mathf.Abs((topSpeed * topSpeed) / (2f * accel) + (topSpeed * topSpeed) / (2f * decel)) > Mathf.Abs(target - pos)) {
			this.topSpeed = sign * Mathf.Sqrt((2f * Mathf.Abs(target - pos) * accel * decel) / (accel + decel));
		}
	}

	public float step(float deltaTime)
	{
		if (pos == target) {
			return pos;
		}

		if (accel == 0 || topSpeed == 0 || decel == 0 || deltaTime == 0) {
			return pos;
		}

		if (Mathf.Abs(speed * deltaTime - decel * deltaTime * deltaTime / 2f) > Mathf.Abs(target - pos)) {
			pos = target;
			return pos;
		}

		if (Mathf.Abs((speed * speed) / (2f * decel)) > Mathf.Abs(target - pos)) {
			speed -= decel * deltaTime;
		} else if (Mathf.Abs(speed) < Mathf.Abs(topSpeed)) {	
			speed += accel * deltaTime;
			if (Mathf.Abs(speed) > Mathf.Abs(topSpeed)) {
				speed = topSpeed;
			}
		} 

		pos += speed * deltaTime;
		return pos;
	}

	public bool isStopped {
		get {
			return (speed == 0 || pos == target);
		}
	}
}
