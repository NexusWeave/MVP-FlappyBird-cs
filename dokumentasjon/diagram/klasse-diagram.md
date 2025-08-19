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
            + int _current
            + readonly string[][] _frames
            + readonly ConsoleColor _foreGround
            + readonly ConsoleColor _backGround

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
        + int _flapTicks
        + readonly GameObject _go
        + public Position Position

        + string[] wingsUp
        + string[] wingsDown

        + public void Draw()
        + public Bird(int col, int row)

        

        + void Flap()
        + void Step(int floorRow)
    }
```

##  'Background' klassen
```mermaid
    classDiagram
        direction TD

        class Background {
            + public void SetBackground(ConsoleColor color)
        }
```

##  'Ground' klassen
```mermaid
    classDiagram
        direction TD
        class Ground {
            + string [] _ground
            + public Position Position;
            + readonly GameObject _go;

            

            + public void Draw()
            + public string[] CreateGround(int Width)
        }
```

##  Pipe klassen
```mermaid
    classDiagram
        direction TD

        class Pipe {
            + readonly GameObject _go;
            + public Position Position;
            
            + bool Update()
            + public void Draw()
            + string[] CreateObstacle(string[] frame)
        }
```
