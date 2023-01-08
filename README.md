# Better Input System
I tried Godot and found the Input System was so much better. So I made a similar one in Unity.

To use:
1. Copy the Input folder directly into your Assets folder.
2. Add the "ActionMap" file to anything.
3. Add keys and give that group a name.
4. Instead of calling "Input.GetKey" or anything else, call "InputHandler.ActionPressed(<name of action>)".
