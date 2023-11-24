﻿using System;

Tamagocha tamagocha = new Tamagocha { Name = "Адольф" };
tamagocha.HungryChanged += Tamagocha_HungryChanged;
tamagocha.ThirstyChanged += Tamagocha_ThirstyChanged;
tamagocha.DirtyChanged += Tamagocha_DirtyChanged;
tamagocha.HealthChanged += Tamagocha_HealthChanged;

void Tamagocha_HungryChanged(object? sender, EventArgs e)
{
    Console.SetCursorPosition(0, 0);
    Console.WriteLine($"{tamagocha.Name} голодает! Показатель голода изменен: {tamagocha.Hungry}");
}

void Tamagocha_ThirstyChanged(object? sender, EventArgs e)
{
    Console.SetCursorPosition(0, 1);
    Console.WriteLine($"{tamagocha.Name} хочет водички (ну или водочки)))! Показатель жажды изменен: {tamagocha.Thirsty}");
}

void Tamagocha_DirtyChanged(object? sender, EventArgs e)
{
    Console.SetCursorPosition(0, 2);
    Console.WriteLine($"{tamagocha.Name} хочет пАмЫцА! Показатель грязюки изменен: {tamagocha.Dirty}");
}
void Tamagocha_HealthChanged(object? sender, EventArgs e)
{
    Console.SetCursorPosition(0, 3);
    Console.WriteLine($"{tamagocha.Name} близок к смерти! Показатель здоровья изменен: {tamagocha.Health}");
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
        while (!IsDead)
        {
            Thread.Sleep(500);
            int rnd = random.Next(0, 6);
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
            if (Console.ReadKey())
        }
    }

    private void FallSleep()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает спать как угорелый. Это продолжается целую минуту. Показатели голода, жажды и грязюки изменены!");
        Thirsty += random.Next(5, 10);
        Hungry += random.Next(5, 10);
        Dirty += random.Next(5, 10);
        Thread.Sleep(1500);
    }
    private void GodsGame()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает играть в русскую рулетку.");
        int gg = random.Next(1, 7);
        if (gg == 0 ) { IsDead = true; }
        Thread.Sleep(500);
    }
    private void Swimming()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает плавать в кристально чистой и даже прозрачной... луже с водой из ЧС. Показатели голода, жажды и грязюки изменены!");
        Thirsty += random.Next(5, 10);
        Hungry += random.Next(5, 10);
        Dirty -= 30;
        Health -= random.Next(15, 20);
        Thread.Sleep(4000);
    }
    private void Burpy()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает фигачить 50 берпи за 10 секунд  как угорелый. Показатели голода, жажды и грязюки изменены!");
        Thirsty += random.Next(5, 16);
        Hungry += random.Next(5, 16);
        Dirty += random.Next(5, 30);
        Thread.Sleep(1000);
    }

    private void JumpMinute()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает прыгать как угорелый. Это продолжается целую вечность. Показатели голода, жажды и грязюки изменены!");
        Thirsty += random.Next(5, 15);
        Hungry += random.Next(5, 15);
        Dirty += random.Next(5, 15);
        Thread.Sleep(6000);
    }

    private void Spotknulsa()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает спотыкаться как угорелый. Это продолжается целую минуту. Показатели голода, жажды и грязюки изменены!");
        Thirsty += random.Next(5, 10);
        Hungry += random.Next(5, 10);
        Dirty += random.Next(5, 10);
        Health -= random.Next(15, 20);
        Thread.Sleep(1500);
    }
    private void Running()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает бегать.");
        Thirsty += random.Next(5, 10);
        Hungry += random.Next(5, 10);
        Dirty += random.Next(5, 10);
        Thread.Sleep(500);
    }
    private void Paika()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает паять на парах Вишни. Показатели голода, жажды и грязюки изменены!");
        Thirsty += random.Next(5, 10);
        Hungry += random.Next(5, 10);
        Dirty -= 30;
        Health -= random.Next(15, 20);
        Thread.Sleep(4000);
    }
    private void Reading()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает пытается прочитать 50 книг за 10 секунд как угорелый. Показатели голода, жажды и грязюки изменены!");
        Thirsty += random.Next(5, 16);
        Hungry += random.Next(5, 16);
        Dirty += random.Next(5, 30);
        Thread.Sleep(1000);
    }

    private void Gaming()
    {
        Console.SetCursorPosition(0, 10);
        Console.Write($"{Name} внезапно начинает скупать всю продукцию Ardor Gaming как угорелый. Это продолжается целую вечность. Показатели голода, жажды, грязюки и психического здоровья изменены!");
        Thirsty += random.Next(5, 15);
        Hungry += random.Next(5, 15);
        Dirty += random.Next(5, 15);
        Health -= random.Next(30, 40);
        Thread.Sleep(6000);
    }

    public void PrintInfo()
    {
        Console.WriteLine($"{Name}: Health:{Health} Hungry:{Hungry} Dirty:{Dirty} Thirsty:{Thirsty} IsDead:{IsDead}");
    }


}