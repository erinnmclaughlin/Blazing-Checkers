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
2. If a player takes too long to make a move, should the game be automatically surrendered?
    * If so, what should this timeframe be?
3. Are two players randomly assigned, or can they select who to play?
    * If players are randomly assigned, can they choose to rematch previous opponents?
4. Does this application need offline support?
5. Is there any need for different levels of authorization (admin vs regular users?)
6. Should there be an option for a local multiplayer game? What about player vs computer?
7. Will there be a need to support different front ends? (mobile? desktop?)