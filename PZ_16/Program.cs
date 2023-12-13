using static System.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SnakeGame
{
    internal class Program
    {
        public static int width = 25;
        public static int height = 60;
        public static List<Pixel> snake;
        public static Direction snakeDirection;
        public static Pixel food;
        public static Pixel YOJ;
        private static int score = 0;
        private static Timer wallsTimer;
        private static Random random = new Random();
        public static List<Pixel> walls = new List<Pixel>();
        private static List<Pixel> disappearingWalls = new List<Pixel>();
        private static bool isGameRunning = false;

        public static void DrawScene()
        {
            Console.SetCursorPosition(0, 0);

            for (int a = 0; a < width; a++)
            {
                for (int b = 0; b < height; b++)
                {
                    if (a == 0 || a == width - 1 || b == 0 || b == height - 1)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write('█');
                    }
                    else if (snake.Any(p => p.X == a && p.Y == b))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write('0');
                    }
                    else if (food.X == a && food.Y == b)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write('*');
                    }
                    else if (YOJ.X == a && YOJ.Y == b)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkCyan;
                        Console.Write('#');
                    }
                    else if (walls.Any(w => w.X == a && w.Y == b))
                    {
                        Console.Write('█');
                    }
                    else
                    {
                        Write(' ');
                    }
                }
                Console.WriteLine();
            }
            Console.ResetColor();
            Info();
        }

        public static void Info()
        {
            WriteLine("Счет: " + score);
        }

        public static void MoveSnake()
        {
            Pixel head = snake.First();
            Pixel newHead = new Pixel(head.X, head.Y, ConsoleColor.Green);

            switch (snakeDirection)
            {
                case Direction.UP:
                    newHead.X--;
                    break;
                case Direction.RIGHT:
                    newHead.Y++;
                    break;
                case Direction.DOWN:
                    newHead.X++;
                    break;
                case Direction.LEFT:
                    newHead.Y--;
                    break;
            }

            if (newHead.X == 0 || newHead.X == width - 1 || newHead.Y == 0 || newHead.Y == height - 1 ||
                snake.Any(p => p.X == newHead.X && p.Y == newHead.Y) || walls.Any(w => w.X == newHead.X && w.Y == newHead.Y))
            {
                EndGame();
                return;
            }

            snake.Insert(0, newHead);

            if (newHead.X == food.X && newHead.Y == food.Y)
            {
                score++;
                GenerateFood();
            }else if (newHead.X == YOJ.X && newHead.Y == YOJ.Y)
            {
                
                score = score / 2 - 1;
                if(score <= 0)
                {
                    EndGame();
                }
                snake.Insert(0, newHead);
                int newLength = snake.Count / 2 - 1;
                snake.RemoveRange(newLength, snake.Count - newLength);
                GenerateYoj();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1);
            }

            CheckCollisionWithWalls();
        }

        public static void GenerateWalls()
        {
            if (isGameRunning)
            {
                int stripeLength = random.Next(10, 24);

                if (random.Next(2) == 0)
                {
                    GenerateVerticalWalls(stripeLength);
                }
                else
                {
                    GenerateHorizontalWalls(stripeLength);
                }

                Thread.Sleep(3500);
                ClearWalls();
            }
        }

        public static void GenerateVerticalWalls(int stripeLength)
        {
            int stripeStartX, stripeStartY;

            do
            {
                stripeStartX = random.Next(1, width - stripeLength - 1);
                stripeStartY = random.Next(1, height - 1);
            } while (IsWallOverlapWithSnakeOrFood(stripeStartX, stripeStartY, stripeLength, true));

            for (int i = 0; i < stripeLength; i++)
            {
                walls.Add(new Pixel(stripeStartX + i, stripeStartY, ConsoleColor.Gray));
            }

            disappearingWalls.AddRange(walls);
        }

        public static void GenerateHorizontalWalls(int stripeLength)
        {
            int stripeStartX, stripeStartY;

            do
            {
                stripeStartX = random.Next(1, width - 1);
                stripeStartY = random.Next(1, height - stripeLength - 1);
            } while (IsWallOverlapWithSnakeOrFood(stripeStartX, stripeStartY, stripeLength, false));

            for (int i = 0; i < stripeLength; i++)
            {
                walls.Add(new Pixel(stripeStartX, stripeStartY + i, ConsoleColor.Gray));
            }

            disappearingWalls.AddRange(walls);
        }

        public static void ClearWalls()
        {
            walls.Clear();
        }

        public static void CheckCollisionWithWalls()
        {
            List<Pixel> tempWalls = new List<Pixel>(disappearingWalls);

            if (tempWalls.Any(w => snake.Any(s => s.X == w.X && s.Y == w.Y)))
            {
                disappearingWalls.RemoveAll(w => walls.Contains(w));
                ClearWalls();
            }
        }

        public static bool IsWallOverlapWithSnakeOrFood(int startX, int startY, int length, bool isVertical)
        {
            if (isVertical)
            {
                for (int i = 0; i < length; i++)
                {
                    if (snake.Any(s => s.X == startX + i && s.Y == startY) || (food.X == startX + i && food.Y == startY))
                    {
                        return true;
                    }
                }
            }
            else
            {
                for (int i = 0; i < length; i++)
                {
                    if (snake.Any(s => s.X == startX && s.Y == startY + i) || (food.X == startX && food.Y == startY + i))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static void GenerateFood()
        {
            int x, y;

            do
            {
                x = random.Next(1, width - 1);
                y = random.Next(1, height - 1);
            } while (snake.Any(p => p.X == x && p.Y == y) || walls.Any(w => w.X == x && w.Y == y));

            food = new Pixel(x, y, ConsoleColor.Red);
        }

        public static void GenerateYoj()
        {
            int x, y;

            do
            {
                x = random.Next(1, width - 1);
                y = random.Next(1, height - 1);
            } while (snake.Any(p => p.X == x && p.Y == y) || walls.Any(w => w.X == x && w.Y == y));

            YOJ = new Pixel(x, y, ConsoleColor.Red);
        }
        public static void EndGame()
        {
            Console.Clear();
            WriteLine("Game Over!");
            Info();
            WriteLine("Нажмите 'R' для рестарта или 'Esc' для выхода.");

            ConsoleKeyInfo key = ReadKey();
            if (key.Key == ConsoleKey.R)
            {
                StartGame();
            }
            else
            {
                EndGame();
            }
        }
        public struct Pixel
        {
            public Pixel(int x, int y, ConsoleColor color)
            {
                X = x;
                Y = y;
                Color = color;
            }

            public int X { get; set; }
            public int Y { get; set; }
            public ConsoleColor Color { get; }
        }
        public static void SetThread(int speed)
        {
            Thread.Sleep(speed);

            if (score % 5 == 0 && score > 0)
            {
                speed -= 10;
            }
        }
        public static void StartGame()
        {
            Console.CursorVisible = false;
            snake = new List<Pixel>
            {
                new Pixel(10, 10, ConsoleColor.Green),
            };
            snakeDirection = Direction.RIGHT;
            score = 0;
            disappearingWalls.Clear();
            ClearWalls();
            GenerateFood();
            GenerateYoj();

            wallsTimer = new Timer(state => GenerateWalls(), null, 0, 7000);
            isGameRunning = true;

            while (isGameRunning)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);
                    switch (key.Key)
                    {
                        case ConsoleKey.W:
                            snakeDirection = Direction.UP;
                            break;
                        case ConsoleKey.A:
                            snakeDirection = Direction.LEFT;
                            break;
                        case ConsoleKey.S:
                            snakeDirection = Direction.DOWN;
                            break;
                        case ConsoleKey.D:
                            snakeDirection = Direction.RIGHT;
                            break;
                        case ConsoleKey.Escape:
                            EndGame();
                            break;
                    }
                }
                MoveSnake();
                DrawScene();

                SetThread(100);
            }
        }

        public static void ShowMenu()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("   Червяк     ");
            WriteLine();
            Console.WriteLine("=== Меню ===");
            Console.WriteLine("1. Начать игру");
            Console.WriteLine("2. Выход");

            ConsoleKeyInfo key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.D1:
                    StartGame();
                    break;
                case ConsoleKey.D2:
                    Environment.Exit(0);
                    break;
                default:
                    ShowMenu();
                    break;
            }
        }

        static void Main(string[] args)
        {
            ShowMenu();
        }


    }

    public enum Direction
    {
        UP,
        RIGHT,
        DOWN,
        LEFT,
    }
}