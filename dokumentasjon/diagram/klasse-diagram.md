# Klasse diagram for OOP

##  Program klassen
```mermaid
    classDiagram
        direction TD

        class Program {
            + Bird bird
            + int Width -> Frame Length
            + int Height - > Frame Height

            bird.step()
            + GameConsole.Fillrow()
            + GameConsole.Writelines()
    }
```
##  'Position' klassen
```mermaid
    classDiagram
        direction TD

        class Position {
            + public int Col;
            + public int Row
            + public Position(int col, int row) 
        }
```

##  'Game' Konsoll klassen
```mermaid
    classDiagram
        direction TD

    class GameConsole {
        + public static void FillRow(int row, int width, ConsoleColor background)
        + public static void WriteLines(int col, int row, string[] lines, ConsoleColor foreground, ConsoleColor Background)
    }
```

##  'GameObject' klassen
```mermaid
    classDiagram
        direction TD

        class GameObject {
            + private int _current
            + private readonly string[][] _frames
            + private readonly ConsoleColor _foreGround
            + private readonly ConsoleColor _backGround

            + Position speed
            + Position Position

            + public int Width -> Frame Length
            + public int Height -> Frame Height

            + public Draw()
            + public void step()
            + public void SetFrame()
            + public void NextFrame()
            + public  GameObject(ConsoleColor foreground, ConsoleColor background, int col, int row, params string[][] frames)
        }
```

##  'Game' klassen
```mermaid
    classDiagram
        direction TD

    class Game {
        + Pipe Position
        + Bird Position
        + Ground Position
        + boolean GameState
    
        + public Run()
        + public GameState( GameState GameState )
        + boolean CollisionCheck(Bird Position, Pipe Position, Ground Position)
    }
```

##  'Bird' klassen
```mermaid
    classDiagram
        direction TD

    class Bird {
        + private int _flapTicks
        + private readonly GameObject _go

        + string[] wingsUp
        + string[] wingsDown

        + public void Draw()
        + public Bird(int col, int row)

        + Public Position Position

        + void Flap()
        + void Step(int floorRow)
    }
```


##  'Background' klassen
```mermaid
    classDiagram
        direction TD

        class Background {
            + void SetBackground(ConsoleColor color)
        }
```

##  'Ground' klassen
```mermaid
    classDiagram
        direction TD
        class Ground {
            + public Position Position;
            + private readonly GameObject _go;

            + string [] _ground
    
            + public void Draw()
            + public string[] CreateGround(int Width)
        }
```

##  Pipe klassen
```mermaid
    classDiagram
        direction TD

        class Pipe {
            + public Position Position;
            + private readonly GameObject _go;

            + public void Draw()
            + string[] CreateObstacle(string[] frame)
        }
```
