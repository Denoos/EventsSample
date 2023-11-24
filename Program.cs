using System;
using System.Data;

Tamagocha tamagocha = new Tamagocha { Name = "Адольф" };
tamagocha.HungryChanged += Tamagocha_HungryChanged;
tamagocha.ThirstyChanged += Tamagocha_ThirstyChanged;
tamagocha.DirtyChanged += Tamagocha_DirtyChanged;
tamagocha.HealthChanged += Tamagocha_HealthChanged;

void Tamagocha_HungryChanged(object? sender, EventArgs e)
{
    Console.SetCursorPosition(0, 0);
    Console.Write($"{tamagocha.Name} голодает! Показатель голода изменен: {tamagocha.Hungry}".PadRight(250));
}
void Tamagocha_ThirstyChanged(object? sender, EventArgs e)
{
    Console.SetCursorPosition(0, 1);
    Console.Write($"{tamagocha.Name} хочет водички (ну или водочки)))! Показатель жажды изменен: {tamagocha.Thirsty}".PadRight(250));
}
void Tamagocha_DirtyChanged(object? sender, EventArgs e)
{
    Console.SetCursorPosition(0, 2);
    Console.Write($"{tamagocha.Name} хочет пАмЫцА! Показатель грязюки изменен: {tamagocha.Dirty}".PadRight(250));
}
void Tamagocha_HealthChanged(object? sender, EventArgs e)
{
    Console.SetCursorPosition(0, 3);
    Console.Write($"{tamagocha.Name} близок к смерти! Показатель здоровья изменен: {tamagocha.Health}".PadRight(250));
}

class Tamagocha
{ 
    public string Name { get; set; }
    public int Health
    {
        get => health;
        set
        {
            health = value;
            HealthChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public int Hungry
    {
        get => hungry;
        set { 
            hungry = value;
            HungryChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public int Dirty
    {
        get => dirty;
        set
        {
            dirty = value;
            DirtyChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public int Thirsty
    {
        get => thirsty;
        set
        {
            thirsty = value;
            ThirstyChanged?.Invoke(this, EventArgs.Empty);
        }
    }
    public bool IsDead { get; set; } = false;

    public event EventHandler HungryChanged;
    public event EventHandler ThirstyChanged;
    public event EventHandler DirtyChanged;
    public event EventHandler HealthChanged;

    public Tamagocha()
    {
        Thread thread = new Thread(LifeCircle);
        thread.Start();
    }

    Random random = new Random();
    private int hungry = 0;
    private int thirsty = 0;
    private int dirty = 0;
    private int health = 100;

    private void LifeCircle(object? obj)
    {
        var polandMap = new PolandMap();
        var walterPP = new WalterPP();
        var panzerKampfwaken = new PanzerKampfwaken();

        while (!IsDead)
        {
            Thread.Sleep(100);
            int rnd = random.Next(0, 10);
            switch(rnd)
            {
                case 0: JumpMinute(); break;
                case 1: FallSleep(); break;
                case 2: Burpy(); break;
                case 3: Swimming();  break;
                case 4: GodsGame();  break;
                case 5: Spotknulsa();  break;
                case 6: Running();  break;
                case 7: Paika();  break;
                case 8: Reading();  break;
                case 9: Gaming(); break;
                default: break;
            }
            ConsoleKeyInfo key;
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.P)
                PrintInfo();
                if (key.Key == ConsoleKey.F)
                Feed();
                if (key.Key == ConsoleKey.G)
                Piot();
                if (key.Key == ConsoleKey.C);
                PopyMit();
            if (Hungry >= 100 || Thirsty >= 100 || Dirty >= 100)
            {
                Health -= 70;
                Hungry = 100;
                Thirsty = 100;
                Dirty = 100;
            }
            if (Hungry <= 0 || Thirsty <= 0 || Dirty <= 0)
            {
                Health += 40;
                Hungry = 0;
                Thirsty = 0;
                Dirty = 0;
            }

            if (Health <= 0)
                IsDead = true;
            if (key.Key == ConsoleKey.A)
            switch (random.Next(0, 9))
            {
                case 0: polandMap.Open(); break;
                case 1: polandMap.Gnaw(); break;
                case 2: polandMap.Smash(); break;
                case 3: walterPP.Open(); break;
                case 4: walterPP.Gnaw(); break;
                case 5: walterPP.Smash(); break;
                case 6: panzerKampfwaken.Open(); break;
                case 7: panzerKampfwaken.Gnaw(); break;
                case 8: panzerKampfwaken.Smash(); break;
                default: break;
            }
        }
    }

    public void Feed()
    {
        Console.SetCursorPosition(0, 4);
        Console.Write($"{Name} начинает ХаВаТь как угорелый, поскольку вы его покормили. Это продолжается целую минуту. Показатели голода, жажды и грязюки изменены!".PadRight(250));
        Hungry -= random.Next(20, 30);
    }
    public void Piot()
    {
        Console.SetCursorPosition(0, 5);
        Console.Write($"{Name} начинает пить пиво как угорелый, поскольку вы его споили. Это продолжается целую минуту. Показатели голода, жажды и грязюки изменены!".PadRight(250));
        Thirsty -= random.Next(20, 30);
    }
    public void PopyMit()
    {
        Console.SetCursorPosition(0, 6);
        Console.Write($"{Name} начинает мыться как угорелый, поскольку вы его моите. Это продолжается целую минуту. Показатели голода, жажды и грязюки изменены!".PadRight(250));
        Dirty -= random.Next(20, 30);
    }
    private void FallSleep()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает спать как угорелый. Это продолжается целую минуту. Показатели голода, жажды и грязюки изменены!".PadRight(250));
        Thirsty += random.Next(5, 10);
        Hungry += random.Next(5, 10);
        Dirty += random.Next(5, 10);
        Thread.Sleep(1500);
    }
    private void GodsGame()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает играть в русскую рулетку.".PadRight(250));
        int gg = random.Next(1, 7);
        if (gg == 0 ) { IsDead = true; }
        Thread.Sleep(500);
    }
    private void Swimming()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает плавать в кристально чистой и даже прозрачной... луже с водой из ЧС. Показатели голода, жажды и грязюки изменены!".PadRight(250));
        Thirsty += random.Next(5, 10);
        Hungry += random.Next(5, 10);
        Dirty -= 30;
        Health -= random.Next(15, 20);
        Thread.Sleep(4000);
    }
    private void Burpy()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает фигачить 50 берпи за 10 секунд  как угорелый. Показатели голода, жажды и грязюки изменены!".PadRight(250));
        Thirsty += random.Next(5, 16);
        Hungry += random.Next(5, 16);
        Dirty += random.Next(5, 30);
        Thread.Sleep(1000);
    }
    private void JumpMinute()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает прыгать как угорелый. Это продолжается целую вечность. Показатели голода, жажды и грязюки изменены!".PadRight(250));
        Thirsty += random.Next(5, 15);
        Hungry += random.Next(5, 15);
        Dirty += random.Next(5, 15);
        Thread.Sleep(6000);
    }
    private void Spotknulsa()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает спотыкаться как угорелый. Это продолжается целую минуту. Показатели голода, жажды и грязюки изменены!".PadRight(250));
        Thirsty += random.Next(5, 10);
        Hungry += random.Next(5, 10);
        Dirty += random.Next(5, 10);
        Health -= random.Next(15, 20);
        Thread.Sleep(1500);
    }
    private void Running()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает бегать.".PadRight(250));
        Thirsty += random.Next(5, 10);
        Hungry += random.Next(5, 10);
        Dirty += random.Next(5, 10);
        Thread.Sleep(500);
    }
    private void Paika()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает паять на парах Вишни. Показатели голода, жажды и грязюки изменены!".PadRight(250));
        Thirsty += random.Next(5, 10);
        Hungry += random.Next(5, 10);
        Dirty -= 30;
        Health -= random.Next(15, 20);
        Thread.Sleep(4000);
    }
    private void Reading()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает пытается прочитать 50 книг за 10 секунд как угорелый. Показатели голода, жажды и грязюки изменены!".PadRight(250));
        Thirsty += random.Next(5, 16);
        Hungry += random.Next(5, 16);
        Dirty += random.Next(5, 30);
        Thread.Sleep(1000);
    }
    private void Gaming()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает скупать всю продукцию Ardor Gaming как угорелый. Это продолжается целую вечность. Показатели голода, жажды, грязюки и психического здоровья изменены!".PadRight(250));
        Thirsty += random.Next(5, 15);
        Hungry += random.Next(5, 15);
        Dirty += random.Next(5, 15);
        Health -= random.Next(30, 40);
        Thread.Sleep(6000);
    }
    public void PrintInfo()
    {
        Console.Write($"{Name}: Health:{Health} Hungry:{Hungry} Dirty:{Dirty} Thirsty:{Thirsty} IsDead:{IsDead}".PadRight(250));
    }
    public interface IPresent
    {
        void Open();
        void Gnaw();
        void Smash();
    }
    public class PolandMap : IPresent
    {
        public void Gnaw()
        {
            var tamagocha = new Tamagocha();
            Console.Write($"{tamagocha.Name} внезапно начинает грызть Польшу по кусочкам как угорелый. Это продолжается целую вечность. ".PadRight(250));
        }

        public void Open()
        {
            var tamagocha = new Tamagocha();
            Console.Write($"{tamagocha.Name} внезапно начинает изучать карту Польши для подготовки нападения. Это продолжается целую вечность. ".PadRight(250));
        }

        public void Smash()
        {
            var tamagocha = new Tamagocha();
            Console.Write($"{tamagocha.Name} внезапно начинает делить Польшу как угорелый.".PadRight(250));
        }
    }
    public class  WalterPP : IPresent
    {
        public void Gnaw()
        {
            var tamagocha = new Tamagocha();
            Console.Write($"{tamagocha.Name} внезапно начинает грызть вальтер, чтобы проверить качество металла. Это продолжается целую вечность. ".PadRight(250));
        }

        public void Open()
        {
            var tamagocha = new Tamagocha();
            Console.Write($"{tamagocha.Name} внезапно начинает стрелять из вальтера по евреям. Это продолжается целую вечность. ".PadRight(250));
        }

        public void Smash()
        {
            var tamagocha = new Tamagocha();
            Console.Write($"{tamagocha.Name} внезапно сломал вальтер и достал PanzerFaust как угорелый.".PadRight(250));
        }
    }
    public class PanzerKampfwaken : IPresent
    {
        public void Gnaw()
        {
            var tamagocha = new Tamagocha();
            Console.Write($"{tamagocha.Name} внезапно начинает грызть Мауса как угорелый. Это продолжается целую вечность. ".PadRight(250));
        }

        public void Open()
        {
            var tamagocha = new Tamagocha();
            Console.Write($"{tamagocha.Name} внезапно начинает изучать Мауса. Это продолжается целую вечность. ".PadRight(250));
        }

        public void Smash()
        {
            var tamagocha = new Tamagocha();
            Console.Write($"{tamagocha.Name} внезапно начинает ломать Мауса как угорелый.".PadRight(250));
        }
    }
}