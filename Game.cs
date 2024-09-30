
namespace OffroadGame
{
    public class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car("4x4 Jeep", 100, 80, 90); //Модель, скорость, проходимость, прочность
            Car car2 = new Car("Buggy", 120, 70, 60);
            Car car3 = new Car("Rally Car", 130, 50, 70);
            Car car4 = new Car("Monster Truck", 70, 120, 80);


            Track track1 = new Track("Пустыня", 5); //Название карты, сложность
            Track track2 = new Track("Горы", 7);
            Track track3 = new Track("Лес", 9);
            Track track4 = new Track("Зимняя трасса", 12);



            Console.WriteLine("Выберите машину для гонки!"); //Выбор машины
            Console.WriteLine("1 -");
            car1.DisplayInfo();

            Console.WriteLine("2 -");
            car2.DisplayInfo();

            Console.WriteLine("3 -");
            car3.DisplayInfo();

            Console.WriteLine("4 -");
            car4.DisplayInfo();
            string changeCar;
            changeCar = Console.ReadLine();

            Car playerCar;

            switch (changeCar) //Выбор машины
            {
                case "1":

                    playerCar = car1;
                    break;
                case "2":

                    playerCar = car2;
                    break;
                case "3":

                    playerCar = car3;
                    break;
                case "4":

                    playerCar = car4;
                    break;
                default:
                    Console.WriteLine("Неверный выбор.");
                    return;


            }
            Car[] randcar = { car1, car2, car3, car4 };
            Random random = new Random();
            Car opponentCar = randcar[random.Next(randcar.Length)];//Выбор рандомной машины сопернику

            Console.WriteLine($"Вы выбрали: {playerCar.Model}");
            Console.WriteLine($"Противник выбрал: {opponentCar.Model}");

            Console.WriteLine("Выберите карту...");
            Console.WriteLine("1 - Пустыня (сложность: легкая)");
            Console.WriteLine("2 - Горы (сложность: нормальная)");
            Console.WriteLine("3 - Лес (сложнсть: безумная)");
            Console.WriteLine("4 - Зимняя трасса (сложность: самая высокая)");
            string trackChoice;
            trackChoice = Console.ReadLine();

            Track selectedTrack;

            switch (trackChoice) //Выбор трека
            {
                case "1":
                    selectedTrack = track1;
                    break;
                case "2":
                    selectedTrack = track2;
                    break;
                case "3":
                    selectedTrack = track3;
                    break;
                    case "4":
                        selectedTrack = track4;
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    return;

            }


            Console.WriteLine($"Начинаем гонку на трассе: {selectedTrack.Name}, сложнсть трассы: {selectedTrack.Difficulty}");

            int playerProgress = 0; //Прогресс пользователя
            int opponentProgress = 0; //Прогресс оппонента
            int raceDistance = 2500; //Дистанция трассы

            Console.WriteLine($"Начинаем гонку на трассе: {track1.Name}");

            while (playerProgress < raceDistance && opponentProgress < raceDistance) //
            {
                playerProgress += playerCar.MoveForward();
                opponentProgress += opponentCar.MoveForward();

                if (random.Next(0, 100) < 5) //Симуляция повреждений //Если прочность < 50, скорость снижается на 50%
                {
                    Console.WriteLine("Вы столкнулись с препятствием!");
                    int damageAmount = random.Next(2,10);
                    Console.WriteLine($"Урон: {damageAmount}, осталось прочности: {playerCar.Durability}");
                    playerCar.takeDamage(damageAmount);
                    
                }
                if (random.Next(0,100) < 5)
                {
                    Console.WriteLine("Противник столкнулся с препятствием!");
                    int damageAmount = random.Next(2, 10);
                    Console.WriteLine($"Урон: {damageAmount}, осталось прочности: {opponentCar.Durability}");
                    opponentCar.takeDamage(damageAmount);
                }
                if (random.Next(0,100) < 5) //Шанс найти усиление = 5%
                {
                    Console.WriteLine("Вы нашли ускоритель, ваша скорость увеличина на 10%");
                    playerCar.Speed += 10;
                }
                if (random.Next(0, 100) < 5) //Шанс найти усиление = 5%
                {
                    Console.WriteLine("Противник нашел ускроритель, его скорость увеличины на 10%");
                    opponentCar.Speed += 10;
                }
                if (random.Next(0,100) < 3)
                {
                    Console.WriteLine("Вы наехали на камень, ваша скорость снижена на 5%");
                    playerCar.Speed -= 5;
                }
                if (random.Next(0, 100) < 3)
                {
                    Console.WriteLine("Противник наехал на камень, его скорость снижена на 5%");
                    opponentCar.Speed -= 5;
                }


                    Console.WriteLine($"Вы проехали: {playerProgress} / {raceDistance}м");
                Console.WriteLine($"Противник проехал: {opponentProgress} / {raceDistance}м");

                System.Threading.Thread.Sleep(1000); //Таймер, каждую секунду обновляется данный цикл
            }
            if (playerProgress >= raceDistance && opponentProgress >= raceDistance)//Система подсчета победы или поражения
            {
                Console.WriteLine("Ничья!");
            }
            else if (playerProgress >= raceDistance)
            {
                Console.WriteLine("Вы выиграли!");
            }
            else
            {
                Console.WriteLine("Вы проиграли!");
            }
        }

    }
}