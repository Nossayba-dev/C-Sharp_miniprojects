string[] grid = new string[9] {"1", "2", "3", "4", "5", "6", "7", "8", "9" };
bool player1Turn = true;
int numTurns = 0;
void PrintGride()
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            //j = 0 → grid[1 * 3 + 0] → grid[3] → "4"
            //j = 1 → grid[1 * 3 + 1] → grid[4] → "5"
            //j = 2 → grid[1 * 3 + 2] → grid[5] → "6"
            Console.Write(grid[i * 3 + j] + "|"); //row × numberOfColumns + column
        }
        Console.WriteLine();
        Console.WriteLine("------");
    }
}
bool CheckVictory()
{
    bool row1 = grid[0] == grid[1] && grid[1] == grid[2];
    bool row2 = grid[3] == grid[4] && grid[4] == grid[5];
    bool row3 = grid[6] == grid[7] && grid[7] == grid[8];
    bool col1 = grid[0] == grid[3] && grid[3] == grid[6];
    bool col2 = grid[1] == grid[4] && grid[4] == grid[7];
    bool col3 = grid[2] == grid[5] && grid[5] == grid[8];
    bool diagDown = grid[0] == grid[4] && grid[4] == grid[8];
    bool diagUp = grid[6] == grid[4] && grid[4] == grid[2];

    return row1 || row2 || row3 || col1 || col2 || col3 || diagDown || diagUp;
}

while (!CheckVictory() && numTurns < 9)
{
    PrintGride();
    if (player1Turn)
        Console.WriteLine("Player 1 turn ");
    else
        Console.WriteLine("Player 2 turn ");
    string choice = Console.ReadLine();

    if ( grid[int.Parse(choice)-1] == choice)
    {
        grid[int.Parse(choice) - 1] = player1Turn ? "X" : "O";
        player1Turn = !player1Turn;
        numTurns++;
    }
}
if (CheckVictory())
    Console.WriteLine("Player " + (player1Turn ? "2" : "1") + " wins!");
else
    Console.WriteLine("It's a draw!");
