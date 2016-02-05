using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour
{	
	public FishManager fishManager;
	Bounds area;

	public Animator anim;
	int speedHash;

	public float baseSpeed;
	public float accel;
	Vector3 direction;
	float timer;
	float maxSpeed;
	float speed;

	public float idleTime;
	bool resting;

	void Start()
	{
		speedHash = Animator.StringToHash("speed");
		speed = 0;
		setArea(new Bounds(transform.position, Vector3.one));
	}

	void Update()
	{
		if (timer < speed / accel && speed > 0) {
			speed -= accel * Time.deltaTime;
		} else if (speed < maxSpeed) {
			speed += accel * Time.deltaTime;
		}
		timer -= Time.deltaTime;

		anim.SetFloat(speedHash, speed / baseSpeed + 0.5f);
		transform.localScale = new Vector3(direction.x > 0? 1: -1, 1, 1);
		transform.position += direction * speed * Time.deltaTime;

		if (timer < 0) {
			resetTarget();
		}
	}
	
	public void setArea(Bounds newArea)
	{
		area = newArea;
		resting = true;
		resetTarget();
	}

	void resetTarget()
	{
		resting = !resting;
		if (resting) {
			timer = idleTime * Random.Range(0.5f, 1.5f);
			maxSpeed = 0;
			speed = 0;

		} else {
			Vector3 target = new Vector3(Random.Range(area.min.x, area.max.x), Random.Range(area.min.y, area.max.y), Random.Range(area.min.z, area.max.z));
			target += fishManager.transform.position;
			Vector3 dist = target - transform.position;
			direction = dist.normalized;
			timer = dist.magnitude / baseSpeed * Random.Range(0.5f, 1.5f);
			maxSpeed = dist.magnitude / timer;
			speed = 0;
		}
	}
}
