# The Pathfinder
"Have you ever wondered what happens in those few seconds of buffering in which Google Maps
elaborates the best route to your destination? 
In this game, you're playing an arrow situated in one of Berlin's districts. You're working
for a maps organization and your mission is to figure out a path to get to your client's 
destination whithin a certain time limit - you'll encounter points of interest 
(restaurants, banks, supermarkets, ...) and so called "bits" (giving you extra points and more speed) - 
both of which you have to collect - and "bots"(stealing points and speed from you) - that must be avoided."

The game is using geo data to develope a game environment which our group obtained from Mapbox SDK for Unity. For a first step into their work and how you can deal with it you should check their documentation: https://www.mapbox.com/unity-sdk/
The scripts we aditionally used in Unity are described below.

# -BotsMove-
checks if the player is in a certain distance. If true, the bot stops rotating (Rotator script) and moves towards the player with a defined speed.

# -CountdownTimer-
counts down a certain time interval and triggers the game over scene when no time is left.
The current time is passed to GUIManger to be displayed while playing.

# -DontDestroy-
prevents GameObjects from destruction while loading a next scene.

# -EinfuehrungResetGame-
jumps to a certain scene chosen by a string name after a defined time and disables the GameObjects protected by the DontDestroy script for that time. The shown cutscene can also be abandoned earlier be hitting the escape key.

# -GUIManager-
displays texts on the screen while playing. It gets target numbers for intermediate goals (restaurants, banks, supermarkets) to be found from the OpenGate script, the already collected intermediate goals and the number of hit bits and bots from the Move script and the time left to reach the main goal from the CountdownTimer script. It also shows the short instruction “press space” and the current scene name when a new scene is loaded.

# -GameEventManager-
triggers the private functions GameStart () and GameOver() in several scripts.

# -Move-
allows to move the avatar by using the arrow keys and to let it jump by using the space key.
The jump speed is predefined; the moving speed is controlled by the number of collected bits.
Each level starts with a bit number of 25.
The script counts up or down the bit number when the avatar hits bits and bots (OnTriggerEnter)
and the numbers of collected intermediate goals (restaurants, banks and supermarkets).
It also allows to enter the next level, when the goal column is open. (all intermediate goals must be fulfilled). Therefor it passes the current numbers of collected intermediate goals to the OpenGate script. Move also passes all counted numbers to the GUIManager script, that displays the current values at the upper part of the display.
If the bit number comes to zero or the y-value of the avatar’s transform undercuts -10 the script triggers the game over scene.

# -OpenGate-
takes the available number of Points of Interest (restaurants, banks, supermarkets) from the scrolling script and sets target numbers, the player has to collect by a certain ratio. These target numbers are passed to the GUIManager to get displayed. 
It also checks, if the current number of collected intermediate goals coincide with the target numbers. When true, it makes the collider of the goal column a trigger that can be entered to complete a level.

# -PauseManger-

# -Positioning-
takes a transform (in our case the goal column) and places it onto the mapbox map by using latitude and longitude coordinates after the initial map load.

# -RotateDirection-
rotates a transform smoothly towards another transform. In our case the arrow always turns to the goal column.

# -Rotator-
rotates objects along their y-axes. In our case bits and bots rotate as long the avatar does not hit them.
-findBitsPlaceBots-
counts the actual number of bits and instantiates a bot for every one of them randomly on the loaded map by a defined probability. 

# -scrolling-
finds every column for the intermediate goals and the main goal and lets their textures scroll down.
It also passes their total numbers to the OpenGate script.


