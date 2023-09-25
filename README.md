# Project_UFO
 
Little game where the main goal is to find the exit with a tiny UFO. This game was made in Unity for a univeristy class. 

The original version for the class only contained 2 levels. 
In the first one you need to go to the elevator but an electric gate stands in the way. You need to find a way to turn off the gate.

![Showcase gif](https://github.com/czanikan/Project-UFO/blob/master/gifs/Level1Cropped.gif)

This is a real time, puzzle game with top-down perspective. The main idea was highly inspired by classic puzzle games like *Portal 2* and *The Talos Principle*. The UFO's movement is phyisics based. The hovering mechanics use a rigidbody with simple force to keep the machine in the air.


## The Story

You are driving a little UFO and you have been captured in area 51. You are at the lower level in the underground base. You need to find the exit to leave this planet. Every level in the game is a floot in the  millitary base. To finish a level you need to find the way to the elevaotr.

`rb.AddForceAtPosition(transform.up * forceAmount, transform.position);`

The *forceAmount* calculated by the mass of the body, the distance from the ground, the disctance in the last update and a little bit of damping:
`float forceAmount = strength * rb.mass * (rayLength - hitDistance) + (dampening * rb.mass * (lastHitDistance - hitDistance));`

# Hi, I'm Andy! 👋


## 🚀 About Me
I'm a computer science student at the University of Debrecen, Hungary.
My passion is game development and I mostly use the Unity game engine but I have experience with the Unreal Engine and Godot as well.

Most of the time I'm make stylized 3D games with low-poly graphic.
I'm also interested in Machine Learning and 3D modeling.

## 🛠 Skills
* Unity (6+ years)
* Blender3D
* Photoshop
* C#
* C++
* Python


## 🔗 Links
* [Twitter](https://twitter.com/goblinatron)
## License

[MIT](https://choosealicense.com/licenses/mit/)





