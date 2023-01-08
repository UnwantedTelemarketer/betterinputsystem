# Better Input System
I tried Godot and found the Input System was so much better. So I made a similar one in Unity.

To use:
1. Copy the Input folder directly into your Assets folder.
2. Add the "Actions" file to any object (but only once).
3. Add keys and give that group a name.
4. Instead of calling "Input.GetKey" or anything else, call "InputHandler.ActionPressed('name of action')".


Todo:  
  - Add controller support (the main reason I like the Godot one so much).  
  - Add an editor so you don't need to add a script to something and use the Unity Inspector.  
