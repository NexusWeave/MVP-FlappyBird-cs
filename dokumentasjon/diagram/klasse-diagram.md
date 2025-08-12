# Klasse diagram for OOP

##  Program
```mermaid
    classDiagram
        direction TD
        
        class Program {
            +GameScreen().DrawGameStartScreen()
            +Game().Run()
            +GameScreen().DrawGameOverScreen()
        }

```

##  Game klassen og interface
```mermaid
    classDiagram
        direction TD
    
        Interface <|.. Game
        Game "1" -- "1" Interface
        
        class Interface {
            +int GetPosition(int x, int y)
        }

        class Game {
            +bool CollisionCheck(int obstacleX, int obstacleY, int spriteX, int spriteY)
            +int score ObstacleAvoided(int obstacleX, int obstacleY, int spriteX, int spriteY)
        }

```

##  Background klassen
```mermaid
    classDiagram
        direction TD


        class Background {
            +void PrintBackground()
        }
```

##  Sprite klassen
```mermaid
    classDiagram
        direction TD

        class Sprite {
            bool isUp;
            int velocity;
            +char[] AnimateSprite()
            +void printSprite(char[]buffer)
        }
```

##  Score klassen
```mermaid
    classDiagram
        direction TD

        class Score {
            +void PrintScore()
        }

```

##  Obstacles klassen
```mermaid
    classDiagram
        direction TD

        class Obstacles {
            +char[] createObstacle()
            +void PrintObstacle(char[] buffer)
        }
```

##  UserInput klassen
```mermaid
    classDiagram
        direction TD

        class UserInput {
            + void WatchSpace()
        }
```

##  Utils klassen
```mermaid
    classDiagram
        direction TD

        class Utils {
            +void setPos(int movement = -1)
        }
```
##  Game Screen
```mermaid
    classDiagram
        direction TD

        class GameScreen {
            + void DrawStartScreen()
            + void DrawGameOverScreen()

            %% Suggestions
            + void DrawGameScore()?
            + void DrawGameSprite()? 
            + void DrawGameObstacle()?
            + void DrawGameBackground()? 
            
        }
```