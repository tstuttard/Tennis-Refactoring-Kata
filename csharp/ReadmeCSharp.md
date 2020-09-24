# Tom's Notes

Please see the csharp section for how I have refactored the TennisGame1 code.

If I had more time I would create a IGameScore implementation that uses state transitions.
This is the state transition I think I would use.
love -> 15 -> 30 -> 40 -> Game Won
                       -> Deuce -> Advantage -> Game Won
                                             -> Deuce
                                             
State transitions would probably make the transitions between points easier to understand. I didn't really want to touch the Tennis Score logic as it seemed to work fine and it would have been too much work to refactor.


If you wanted to take this a bit deeper I would use events to model a tennis game match.
FaultedOnServe, ServeLandedIn, PointWon, GameWon, SetWon, MatchOne using an event store to store all events. These events could then be used to populate a number of different views such as: Live Game ScoreBoard, Real Time Statistics (percentage of serves in), Serve Analysis View etc.

Using Events would work nicely with the state transitions. Using events to populate different views, I think would add a lot of value.
