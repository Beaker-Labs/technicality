extends RigidBody2D

var accel = Vector2.ZERO # The player's movement vector.
var speed = 1000;

# Called when the node enters the scene tree for the first time.
func _ready():
	
	pass # Replace with function body.

# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(delta):
	accel = Vector2.ZERO # The player's movement vector.
	if Input.is_action_pressed("vehicle_right"):
		accel.x += 1
	if Input.is_action_pressed("vehicle_left"):
		accel.x -= 1
	if Input.is_action_pressed("vehicle_forward"):
		accel.y -= 1
	if Input.is_action_pressed("vehicle_back"):
		accel.y += 1
	
func _physics_process(delta):
	#position += accel * delta * speed
	linear_velocity += accel * delta * speed
	
