using Godot;
using System;

public partial class ThirdPersonCamera : Node3D
{
	[Export] float sensitivity = 50f;
	[Export] float maxAngle = 55f;
	[Export] float minAngle = -55f;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Input.MouseMode = Input.MouseModeEnum.Captured;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(Input.IsActionPressed("ui_cancel"))
		{
			Input.MouseMode = Input.MouseModeEnum.Visible;
		}
	}
	
	public override void _Input(InputEvent @event)
	{
		if(@event is InputEventMouseMotion mouseEvent)
		{
			Vector3 rotation = Rotation;
			rotation.Y -= mouseEvent.Relative.X / sensitivity; 
			rotation.X -= mouseEvent.Relative.Y / sensitivity; 
			rotation.X = Mathf.Clamp(
				rotation.X, 
				Mathf.DegToRad(minAngle),
				Mathf.DegToRad(maxAngle)
			);
			Rotation = rotation;
		}
	}
}
