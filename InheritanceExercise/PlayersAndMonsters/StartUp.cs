namespace PlayersAndMonsters
{
    using System;
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new Hero("pesho", 23);
            Console.WriteLine(hero);
            Elf elf = new Elf("Margaritka", 75);
            DarkKnight knight = new DarkKnight("Lord pesho", 45);

            Console.WriteLine(elf);
            Console.WriteLine(knight);

        }
    }
}
