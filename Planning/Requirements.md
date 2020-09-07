# Blazing Checkers Software Requirements

This document describes the software requirements for the Blazing Checkers Web Application.

## Known Requirements
1. Multiplayer checkers game
2. The game will follow the rules of [Standard American Checkers](http://www.se.rit.edu/~swen-261/projects/WebCheckers/American%20Rules.html)
3. The game will be played in realtime
4. Users will register their own account with username/password
5. Winners and losers of each game will be tracked in a database

## Questions
1. Will the checkers game end if one player disconnects, or should the state of the game be stored in a database?
   > A: The game state should be saved as the game is played.
2. If a player takes too long to make a move, should the game be automatically surrendered?
    * If so, what should this timeframe be?
    > A: Yes, if a player does not move in 7 days, the other player should automatically win.
3. Are two players randomly assigned, or can they select who to play?
    * If players are randomly assigned, can they choose to rematch previous opponents?
    > A: Players should be randomly assigned, but have the option to rematch previous opponents. Also, it'd be nice to match players based on ability rather than having it be totally random.
4. Does this application need offline support?
   > A: This would be nice, but it's not a requirement.
5. Is there any need for different levels of authorization (admin vs regular users?)
   > A: No, all users will have the same level of access.
6. Should there be an option for a local multiplayer game? What about player vs computer?
   > A: No need for local multiplayer. Player vs. computer would be cool to do in the future, but not needed right now.
7. Will there be a need to support different front ends? (mobile? desktop?)
   > A: Not immediately, but in the near future we would like to develop this into a mobile application as well.
8. Should each player have a profile page? What type of information should it display? Can players view the profile pages of other players, or just their own?
   > A: Players should have a profile page with summary stats: # of games played, % win, % loss; They should also have a list of their previously played games. Players should be able to see the profiles of other players
