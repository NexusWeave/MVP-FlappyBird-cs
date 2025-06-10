using System.Data;

string[] wingUp = {
    "  \\   /  ",
    "   \\0/   ",
    "          "
};
string[] wingDown = {
    "         ",
    "   /0\\  ",
    "  /   \\ "
};
int consoleHeightMax = 21;
int consoleHeightMin = 0;
int Height = 10;
int newHeight = 10;
bool isWingUp = true;

while (true)
{

    DrawFlight();

    Thread.Sleep(100);
    Console.Clear();
}

void DrawBird()
{
    if (!isWingUp && Height <= newHeight)
    {
        isWingUp = true; foreach (var line in wingUp) Console.WriteLine(line);
    }

    else
    {
        isWingUp = false; foreach (var line in wingDown) Console.WriteLine(line);
    }
}

int SetFlightHight()
{
    if (Console.KeyAvailable)
    {
        var key = Console.ReadKey(true).Key;
        if (key == ConsoleKey.Spacebar) { Height--; }
    }
    else
    {
        Height++;
    }
    return Height;
}

void DrawFlight()
{
    int newFlightHight = SetFlightHight();
    for (int i = 0; i < newFlightHight; i++)
    {
        Console.WriteLine(" ");
    }

    DrawBird();
    newHeight = newFlightHight;
}



