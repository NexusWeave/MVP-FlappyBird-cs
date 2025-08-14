# Klasse diagram for OOP

##  Program
```mermaid
    classDiagram
        direction TD

        class Program {
            +StateScreen().DrawGameStartScreen()
            +Game().Run()
            +StateScreen().DrawGameOverScreen()
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

##  Sprite klassen
```mermaid
    classDiagram
        direction TD

        class Sprite {
            bool isUp;
            int velocity;
            +char[] AnimateSprite()
        }
```

##  Score klassen
```mermaid
    classDiagram
        direction TD

        class Score {
            +void ScoreIncrementer(int increment)
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
            + void WatchSpace(Console input)
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
            + void DrawGameScore(int score)
            + void DrawGameSprite(char[] buffer)
            + void DrawGameObstacle(char[] buffer)
            + void DrawGameBackground(char[] buffer) 
        }
```

##  StateScreen
```mermaid
    classDiagram
        direction TD

        class StateScreen {
            + void DrawStartScreen(char[] buffer)
            + void DrawGameOverScreen(char[] buffer) 
        }
```
