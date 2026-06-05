namespace RockPaperScissorsGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool isPlaying = true;
            Random random = new Random();

            int winCount = 0;
            int loseCount = 0;
            int drawCount = 0;

            while (isPlaying)
            {
                Console.WriteLine("=== 猜拳遊戲 ===");
                Console.WriteLine($"目前戰績：勝 {winCount} / 敗 {loseCount} / 平手 {drawCount}");
                Console.WriteLine("請選擇你的出拳：");
                Console.WriteLine("1. 剪刀");
                Console.WriteLine("2. 石頭");
                Console.WriteLine("3. 布");
                Console.WriteLine("0. 離開遊戲");

                Console.Write("請輸入 0-3：");
                string playerInput = Console.ReadLine()!;

                bool isNumber = int.TryParse(playerInput, out int playerChoice);

                if (!isNumber || playerChoice < 0 || playerChoice > 3)
                {
                    Console.WriteLine("輸入錯誤，請輸入 0、1、2 或 3。");
                    Console.WriteLine();
                    continue;
                }

                if (playerChoice == 0)
                {
                    Console.WriteLine("遊戲結束，謝謝遊玩！");
                    Console.WriteLine($"最終戰績：勝 {winCount} / 敗 {loseCount} / 平手 {drawCount}");
                    isPlaying = false;
                    continue;
                }

                Console.WriteLine($"你出的是：{GetChoiceName(playerChoice)}");
                Console.WriteLine("電腦思考中...");

                Thread.Sleep(1000);
                int computerChoice = random.Next(1, 4);

            
                Console.WriteLine($"電腦出的是：{GetChoiceName(computerChoice)}");

                string result = GetResult(playerChoice, computerChoice);

                if (result == "win")
                {
                    winCount++;
                    Console.WriteLine("你贏了！");
                }
                else if (result == "lose")
                {
                    loseCount++;
                    Console.WriteLine("你輸了！");
                }
                else
                {
                    drawCount++;
                    Console.WriteLine("平手！");
                }

                Console.WriteLine();
            }
        }

        static string GetChoiceName(int choice)
        {
            if (choice == 1)
            {
                return "剪刀";
            }
            else if (choice == 2)
            {
                return "石頭";
            }
            else if (choice == 3)
            {
                return "布";
            }
            else
            {
                return "未知";
            }
        }

        static string GetResult(int playerChoice, int computerChoice)
        {
            if (playerChoice == computerChoice)
            {
                return "draw";
            }

            if (
                playerChoice == 1 && computerChoice == 3 ||
                playerChoice == 2 && computerChoice == 1 ||
                playerChoice == 3 && computerChoice == 2
            )
            {
                return "win";
            }

            return "lose";
        }
    }
}
