namespace CarNameSpace
{
    public class Car
    {
        public string Model {  get; set; }
        public int Speed { get; set; }
        public int Offroad { get; set; }
        public int Durability { get; set; }

        public Car(string model, int speed, int offroad, int durability)
        {
            Model = model;
            Speed = speed;
            Offroad = offroad;
            Durability = durability;

        }

        

        public int MoveForward() //Прочность < 50, скорость снижается на 50%
        {
            int effectiveSpeed = (Durability < 50 ? Speed / 2 : Speed);
            return effectiveSpeed;
        }
        
        public void takeDamage(int damageAmount)  //Метод для получения повреждений
        {
            Durability -= damageAmount;
            if (Durability < 0)
            {
                Durability = 0;
            }
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"Модель: {Model}, Скорость: {Speed}, Проходимость: {Offroad}, Прочность: {Durability}");
        }

    }
}