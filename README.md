# Better Input System
I tried Godot and found the Input System was better. So I made a similar one in Unity. Basically the new input system for unity but way easier to use.

To use:
1. Copy the Input folder directly into your Assets folder.
2. At the top of the window, hover over Input Handler and open the Action Editor.
3. Here you can add "Actions" which consist of a name (not case sensitive) and keycodes.
4. Click "Update Actions" whenever you change them. This will create a GameObject called "Input Injector" which you can ignore.
4. Instead of calling "Input.GetKey" or anything else, call "InputHandler.ActionPressed('name of action')".


Todo:  
  - Add controller support (the main reason I like the Godot one so much).   
