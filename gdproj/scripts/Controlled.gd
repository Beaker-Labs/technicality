extends RigidBody2D


# Declare member variables here. Examples:
# var a = 2
# var b = "text"

var accel = 0
var maxSpeedF = 500
var maxSpeedR = 400
var angular_speed = PI
var direction = 0

# Called when the node enters the scene tree for the first time.
func _ready():
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	direction = 0
	var held = false
	if Input.is_action_pressed("vehicle_forward"):
		held = true
		if(accel < maxSpeedF):
			accel += 5
	if Input.is_action_pressed("vehicle_back"):
		held = true
		if(accel > maxSpeedR * -1):
			accel -= 5
	if Input.is_action_pressed("vehicle_right"):
		direction = 1
	if Input.is_action_pressed("vehicle_left"):
		direction = -1
	
	if(held == false):
		if(accel > 0):
			accel -= 1
		if(accel < 0):
			accel += 1

func _physics_process(delta):
	#rotation += angular_speed * direction * delta
	angular_velocity = direction
	linear_velocity = Vector2.UP.rotated(rotation) * accel
	#position += velocity * delta
	
