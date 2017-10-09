# fun-serious-game
A game based on a serious genre, built with the unity game engine.


## Running the game

### From the build file (.exe)
* Double click on the .exe file
* You should start at the main menu once the game has loaded.
* Click on the "New Game" button.


### From Unity
* Import the project folder into Unity.
* Switch to the MainMenu scene.
* Press the start game button.
* You should start at the main menu.
* Click on the "New Game" button.



### Known bugs in the Prototype (to be fixed for the final submission)
* With certain Unity builds, the initial dialogue may be incorrect when starting the game and user must press space to pass it. 
* When transitioning back to the game after completing the maths minigame, the dialogue box doesn't reopen.
* Starting the principal's trial and selecting "You were right to suspect him, Mr. Wilson" into "(as said my Rita)" option will bring up an empty dialogue (Why do you say that Erin, but still increases score). Going through the same process a second time ends the game.
* It is currently possible to end the principal's trial by continuing with spacebar. Doing this will add trial dialogue button options to Jimmy and Rita (unintended).
* Talking to Jimmy, then solving Rita's math minigame and then talking to Jimmy again will add duplicate Jimmy entries to the journal (this happens with or without collecting the register entry from Rita).
* Solving Rita's math minigame clears the journal. Talking to Rita again to obtain the register entry restores journal state.
