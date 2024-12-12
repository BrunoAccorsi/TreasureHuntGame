namespace TreasureHunt
{
    public class GameControl
    {

        private string player1;
        private string player2;

        private int turn;
        private Dictionary<int, string> playerTurn = new Dictionary<int, string>();

        private Dictionary<int, int> score = new Dictionary<int, int>()
        {
            {1, 0 },
            {2, 0 }
        };

        private enum GameState { Hiding, Searching }
        private Dictionary<int, string> currentStateAsString = new Dictionary<int, string>()
        {
            {0, "Hiding" },
            {1, "Searching" }
        };

        private int currentState;
        private int winner;

        public GameControl(string playerOneName, string playerTwoName)
        {
            this.player1 = playerOneName;
            this.player2 = playerTwoName;

            this.playerTurn.Add(1, playerOneName);
            this.playerTurn.Add(2, playerTwoName);

            this.turn = 1;
            this.currentState = (int)GameState.Hiding;
        }

        public int CurrentState
        {
            get { return currentState; }
        }

        public string currentGameState()
        {
            return $"({this.currentStateAsString[this.currentState]}) phase";
        }

        public string currentPlayer()
        {
            return $"{this.playerTurn[turn]}";
        }

        public string iddlePlayer()
        {
            if (turn == 1)
            {
                return $"{this.playerTurn[2]}";
            }

            return $"{this.playerTurn[1]}";
        }

        public string getPlayerName(int playerNumber)
        {
            string playerName;

            this.playerTurn.TryGetValue(playerNumber, out playerName);

            if (playerName == null)
            {
                return "ERROR";
            }

            return playerName;
        }


        public void endTurn()
        {
            if (this.turn == 2)
            {
                this.turn = 0;
            }

            this.turn++;

            changeGameState();
        }

        private void changeGameState()
        {
            if (this.currentState == (int)GameState.Hiding)
            {
                this.currentState = (int)GameState.Searching;
            }
            else
            {
                this.currentState = (int)GameState.Hiding;
            }
        }

        public void hasWinner(string playerName, bool isGameReset = false)
        {
            var player = playerTurn.Where(pair => pair.Value == playerName).Select(pair => pair.Key);

            if (player == null)
            {
                throw new Exception($"{playerName} not found!");
            }

            this.winner = player.First();

            if (!isGameReset)
            {
                changeGameScore();
            }

            this.turn = player.First() - 1;
            endTurn();
        }

        private void changeGameScore()
        {
            int totalWins;
            score.TryGetValue(this.winner, out totalWins);
            score[winner] = totalWins + 1;
        }

        public Dictionary<int, int> getUpdatedScore()
        {
            return this.score;
        }

        public void resetGame()
        {
            this.score[1] = 0;
            this.score[2] = 0;
            this.turn = 1;
            this.currentState = (int)GameState.Hiding;
            this.winner = 0;
        }
    }
}

