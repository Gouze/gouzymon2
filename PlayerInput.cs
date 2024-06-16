using Godot;
using System;

public partial class PlayerInput : RigidBody3D
{
	private Vector3 velocity;
	[Export] private float speed;
	[Export] private ThirdPersonCamera camera;

	public override void _PhysicsProcess(double delta)
	{
		ProcessInput();
		Move();
	}

	private void ProcessInput()
	{
		Transform3D cameraTransform = camera.Transform;
		Vector3 cameraRight = cameraTransform.Basis.X.Normalized();
		Vector3 cameraBasisZ = -cameraTransform.Basis.Z;
		Vector3 cameraForward = new Vector3(cameraBasisZ.X, 0f, cameraBasisZ.Z).Normalized();

		Vector3 input = Vector3.Zero;
		velocity = Vector3.Zero;
		if (Input.IsActionPressed("up"))
		{
			input += cameraForward;
		}
		if (Input.IsActionPressed("down"))
		{
			input -= cameraForward;

		}
		if (Input.IsActionPressed("left"))
		{
			input -= cameraRight;
		}
		if (Input.IsActionPressed("right"))
		{
			input += cameraRight;
		}
		velocity = input * speed;
	}

	private void Move()
	{
		MoveAndCollide(velocity);
	}


}
