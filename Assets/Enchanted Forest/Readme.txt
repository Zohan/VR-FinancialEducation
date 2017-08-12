
--------------------------------------------
README - INTERACTIVE AUDIO: ENCHANTED FOREST
--------------------------------------------
Version: 1.1
(c) Alpaca Sound 2014
Interactive Audio: Enchanted Forest requires Unity Free or Pro, version 4.2.2 or later.


Usage
------------
1. Drag and drop the Enchanted Forest prefab to the scene.
2. Run the application.


Controlling the parameters
--------------------------
The following parameters that can be changed in the inspector or from code:

Autoplay		— Makes the soundscape start playing automatically.
Master Volume	— Master volume for the soundscape.
Wind			— The volume of the wind.
Animal Activity	— How often the birds and other animals will play. (Doesn’t affect their volume.)
Fairy Dust		— How often the sound effects and musical elements play. (Doesn’t affect their volume.)
Use Local Time	— Makes the Time Of Day follow the computer clock.
Time Of Day		— 0 = midnight, 0.25 = morning, 0.5 = midday, 0.75 = evening, 1 = midnight (again)


using namespace AlpacaSound.EnchantedForest;

public float autoplay; // true or false
public float masterVolume; // between 0 and 1
public float wind; // between 0 and 1
public float animalActivity; // between 0 and 1
public float fairyDust; // between 0 and 1
public bool useLocalTime; // true or false
public float timeOfDay; // between 0 and 1



---
Contact and support: info@alpacasound.se
Website: http://www.alpacasound.se/
 
Alpaca Sound creates music and sound effects for video games. (And sometimes does a bit of coding.)
