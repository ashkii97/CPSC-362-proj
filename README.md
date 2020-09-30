# CPSC-362-proj



## TODO
 - Refactor Waypoints
 - UI
 - Combine Tower and CreepSpawner Scenes into new scene
   - Add in UI when completes


## Main Menu Documentation

- Menu object

  Empty object containing UI elements.  It has a script component "MainMenu.c#" that has two methods, PlayGame() and QuitGame().
  
- Canvas object

  Parent object created by Unity to contain the panel object used for the background
  
- Background object  

  A panel object used to display a background sprite for the main menu.
  
- Play button object

  An UI Button object.  The normal alpha is set to 0 to hide the button when interaction is absent.  Highlight alpha (mouse over) is set to ~70 for visual feedback.     Pressed alpha is set to ~140 for visual feedback.  Selected alpha is set to 0 so visual feedback does not persist past any interaction events. Upon button activation, the PlayGame() method from MainMenu.c# will be executed loading the next scene, the game itself.
  
- Play Text

  A TextMeshPro object used to display the "PLAY" text.  A custom color gradient has been defined and set for the object for visual appeal.

- Exit button object

  A duplicate of the Play Button object.  Upon button activation, the QuitGame() method from MainMenu.c# will be executed, printing a "PLAYER QUIT" console message from testing purposes then terminating the process.
