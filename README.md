# SportsTeamManager

The idea behind this project was to implement some CRUD web APIs for team manager to manage and view its team.


On the project startup, a window with Swagger documentation should load allowing you (team manager?) to do these actions:


1. Get certain team's upcoming games. Uses teamId for that.
2. Get certain team's previous games. Uses teamId for that.
3. Get certain team's players. Uses teamId for that.
4. Add new player to a certain team. Uses teamId for that and need to have player info.
5. Remove a specific player from a specific team. Uses teamId and playerId for that.


Initial data is generated with InMemoryContext Initialize method. The idea behind that was to replicate a "proper" DB context but without any relational databases
and without using EF Core InMemoryProvider as it's quite complicated and time consuming to setup all the relations there and seed the data.


There is some initial data, like 4 players (IDs from 1-4, belonging to either team), 2 teams (IDs from 1-2), 2 games (where both team played or will play against each other).


Only relations between entities are done by linking IDs only and on some action (i.e. adding a new player), only the relevant repository was updated.
For example, when adding a new player, only Players repo are updated with a new player that has a TeamID propery that would help link it to a specific team. Even though Team entity
has a collection of players, a decision not to update Team repo with a new player was taken as setting up those relations between entities would be time consuming in this in-memory environment.

Repository pattern and services was used in order to have some distinctions between "data access" and validations or additional actions before serving a request.
