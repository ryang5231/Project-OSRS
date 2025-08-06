# CS463 Virtual Reality Project - Old School RuneScape

Demo Video (raw uncut footage): https://youtu.be/45KxsoBPbRY

Task: Create an immersive VR experience that had interactables, and unique elements that showcases your creativity.

**Note**:
- I made this as a school project, used for non-commercial purposes. No copyright infringement was intended. If certain elements are buggy, I apologise, please be diplomatic about it. 
- This project has reached the end of development, so no more changes from me will be pushed out. Feel free to clone this repository and change it however you like, just remember to give credit where it's due.
- This project works with Unity 2022.3.211f and has not been tested with other versions of Unity. You can directly run the project on your PC
- I have managed to get this project running on a Meta Quest 3 after using USB debugging to get the ISO onto my Oculus Device. If you need more information, feel free to reach out.


## Features
- Free-roaming NPCs and 3D Interactable and Immersive environment.
  - Chop logs with an axe, burn them at a furnace, use keys, which are dropped by monsters, to unlock new areas.
  - Like in RuneScape, background music will change when players move to different areas. There are also proximity sounds, as demonstrated by the castle fountains.
  - Grey Teleportation portals disks around the game on the ground for ease of transport around the map.
- Simple combat system
  - 3 types of weapons (Steel dagger, Rune Scimitar, Osmumten's fang) which deal ascending amounts of damage in that order, which allows players to kill monsters quicker.
  - Some monsters, when defeated, will drop these weapons. Certain monsters can also drop useful items.
  - Fightable NPCs include: Goblins, Hill Giants, and Elvarg, the dragon.


## How it works
- All progrmamable behaviour of the Non-Playable Characters (NPCs) and what they dropped were mostly accomplished with C# programming and extensive online research in my own time, outside of class.
- All scripts can be found under "Assets > Project-OSRS > Scripts".
- NPC roaming behaviour was accomplished with a C# script (BlendShapeLoop.cs) and the NavMesh component, where the C# script allowed the NPCs to switch animation states when moving, giving the impression of walking and autonomy.
- Background music and SFX management fell under one C# script (AudioManager.cs), which fed the Audio Listener certain sounds when certain criteria were met (NPC health reached 0, entering new region, etc).
- All environment and character assests were exported from the Old School RuneScape game cache, and reanimated by myself in Blender 3.6, which is covered under Fair Use.

<p align = "center"><img width = 220px src = "https://github.com/user-attachments/assets/c8e41769-cea5-45f9-bf69-916946472f0a" align = "center"></p>
 
 _<p align = "center">Animating keyframes from game cache in Blender before use in Unity.</p>_

- All the interactions with the ground and other objects were configured by me, sources and tutorials used for guidance listed at bottom of readme.

## Gallery

![Screenshot 2024-08-18 175609](https://github.com/user-attachments/assets/d259515a-3fbb-4edf-b0e3-dc99c9a73a57)

![Screenshot 2024-08-18 175617](https://github.com/user-attachments/assets/7a2ff02e-6ea3-4793-86ba-a8ead334671b)

![Screenshot 2024-08-18 175626](https://github.com/user-attachments/assets/1dd54e22-3200-4cb6-b107-66c687405707)

![Screenshot 2024-08-18 175551](https://github.com/user-attachments/assets/8cf9ffa3-109d-4216-bd5b-3ef455d8baeb)

![Screenshot 2024-08-18 175536](https://github.com/user-attachments/assets/27adbec3-67ea-41a2-96e1-015fac962179)


## Setup


### Method 1: Running locally on your PC
1. Have Unity Hub and Unity **_2022.3.211f_** installed.
2. Clone the repo to your Unity working directory.
3. Under the "Viewers" GameObject, ensure that "XR Device Simulator", "XR Origin (XR Rig)" and OVRPlayerController (1) are checked and visible. *Everything else should be greyed out.*
<p align = "center"><img src = "https://github.com/user-attachments/assets/d23780b5-ef6b-404c-b2fa-6533d29e4aae"</img></p>
4. Under your "Game" tab, ensure that you are on "Display 8". This will be your main VR camera.
5. Click the "play" button to start.


- Controls (if using PC):
  - Tab = Alternates between and enables viewing, left controller, and right controller control. 
  - Cursor = Look around/move enabled controller.
  - Scroll Wheel = rotate controller (if controller enabled).

  - Q/E key = Look left/right.
  - Hold Shift key = left controller enabled.

  - Hold Spacebar = right controller enabled.
  - Shift key + W/A/S/D = move around. You can alse press Tab to cycle to the left controller, doing this removes the need to hold the Shift key.
  - Hold Shift/Spacebar + G = if your controller is aiming at an object, this grabs objects. Release G key to drop it.

### Method 2: Build it and directly run it on your Meta Quest 3
1. Clone the repo and open the project in Unity.
2. Under the "Viewers" GameObject, ensure that "XR Device Simulator", "XR Origin (XR Rig)" and OVRPlayerController (1) are checked and visible. *Everything else should be greyed out.*
3. Connect your Meta Quest to your PC and ensure that USB debugging is switched on (see online on a guide on how to turn it on).
4. In Unity, go under "File > Build Settings".
5. Select "Android" as your platform and under "Run Device", select your Oculus Device.
6. Click "Build and Run". After building, the project should be loaded onto the Meta Quest 3.


## Sources
- Huge thanks to all the content creators and Discord members who helped a novice like myself through this project, I would not have survived if it wasn't for you all.
[1] Exporting character models/animations in OSRS -
https://www.youtube.com/watch?v=Oxi67ouhkjw

[2] Exporting in-game environments in OSRS -
https://www.youtube.com/watch?v=NhqLDY9QH7k

[3] Useful glTF utility package that allowed me to work with the glTF file format in Unity (Unity 
package name - com.unity.cloud.gltfast) - https://github.com/atteneder/glTFast

[4] Iterating through BlendShapes to create the illusion of animation -
https://www.youtube.com/watch?v=sdl-jpZ0NR0

[5] Converting BlendShape keyframes into Unity Animations -
https://www.youtube.com/watch?v=xbLuYnWofVM&ab_channel=Unreality3D

[5.1] Where to add OVR Interaction Comprehensive in the Hierarchy -
https://www.youtube.com/watch?v=4kGD8q5kEx8

[6] My post for help on Reddit -
https://www.reddit.com/r/vrdev/comments/1blug4e/a_desperate_plea_for_help/

[7] Background Music and transition between audios -
https://www.youtube.com/watch?v=1VXeyeLthdQ

[8] 3D spatial audio for the fountains - https://www.youtube.com/watch?v=LrchScd806w

[9] Making rivers and terrains - https://www.youtube.com/watch?v=BKoplg30egw

[10] Applying Textures to terrains - https://www.youtube.com/watch?v=pKF9-c64NVs

[11] Making invisible materials for 3D objects in URP -
https://www.youtube.com/watch?v=Afsl_ZCEgKw

[12] Wandering AI for NPCs - Basic Wandering Ai Character 3D - Unity 2023 (script below) 
(youtube.com)

[13] NavMeshAgent tutorial - https://www.youtube.com/watch?v=CHV1ymlw-P8

[14] NavMeshAgents floating above ground fix - How to fix character floating above the ground 
when using NavMesh in Unity 3D (youtube.com)

[15] Converting normal existing 3D project into a 3D URP project -
https://www.youtube.com/watch?v=KpTK-OraZ-g

[16] Deleting .meta files when encountering “associated script cannot be loaded” error -
General problem with scripts: The associated script cannot be loaded - Unity Forum

[17] Setting up a project with OVR Camera Rig for Meta Quest 3 - Unity Meta Quest 3 Tutorial 
Lesson 01 Updated - Project Setup (youtube.com)

[17.1] Setting up interaction managers for OVR Camera Rig -
https://www.youtube.com/watch?v=4kGD8q5kEx8

[17.2] Adding controllers to show up on Meta Quest 3 -
https://www.youtube.com/watch?v=5vnEedwlOJY

[18] Basic portal functionality - Unity 3D: Creating Basic "Portal" Functionality 
(youtube.com)

[19] Teleporting a player controller - https://www.youtube.com/watch?v=xmhm5jGwonc

[20] XR Rigs and scaling - Question - XR Rig and Player Scale - Unity Forum

[21] Setting up distance grab for OVR - https://www.youtube.com/watch?v=OaPQPY_wuzk
