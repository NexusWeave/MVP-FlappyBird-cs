```mermaid
sequenceDiagram
sequenceDiagram
    actor u as Belle
    
    participant prog as Program
    participant gc as GameConsole
    participant g as Game
    participant go as GameObject

    participant bg as Background
    participant b as Bird
    participant p as Pipe
    participant gd as Ground

    participant pos as Position

    autonumber
    u ->> prog: User opens the program
    prog ->> gc: Creates the window
    prog ->> g: Starts the Game
    
    loop while-loop
        g ->> go: Initializing & updates frames

        go ->> bg: Genereate Background color
        bg ->> bg: Initializing the background
        
        go ->> gd: Genereate the ground
        gd ->> gd : Initializing the ground & draws it
        gd ->> gd: Animates the Ground

        go ->> b: Genereate pipes
        p ->> pos: Create & update position
        p ->> p : Initializing the bird & draws it
        p ->> p: Animates the Pipe

        go ->> b: Generate birds
        b ->> pos: Create & update position
        b ->> b : Initializing the bird & draws it
        b ->> b: Animates the bird

        go ->> go: Updates the frame & Check for collision
        alt if collision
            go ->> gc: Writes end screen
        end
    end
```