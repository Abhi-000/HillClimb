using System;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
[RequireComponent(typeof (Rigidbody2D))]
[Serializable]
public class Wheel_Options
{
	public float dampingRatio = 0.7f;
	public float frequency = 6f;
	public float mass = 0.1f;
	public float gravityScale = 1f;
}