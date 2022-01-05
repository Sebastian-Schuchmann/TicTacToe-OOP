using OOP;

Console.Clear();

var game = new Game();
var gameState = GameState.InProgress;

while (gameState == GameState.InProgress)
{
   gameState = game.NextTurn();
}

Console.WriteLine(gameState);