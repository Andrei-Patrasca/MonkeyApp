using System;
using MyMonkeyApp;

class Program
{
	static readonly string[] AsciiArts = new[]
	{
		"  (o o)\n (  V  )\n/--m-m--/",
		"   w  c( .. )o   ( -.- )o   (\\\")_(\\\")",
		"   .-\"\"\"-.\n  / .===. \\\n  \\/ 6 6 \\\n  ( \\___/ )\n___ooo__ooo___",
		"   (o\\_/o)\n   (='.'=)\n   (\\\")_(\\\")"
	};

	static void Main()
	{
		var rand = new Random();
		while (true)
		{
			Console.Clear();
			// Show random ASCII art
			Console.WriteLine(AsciiArts[rand.Next(AsciiArts.Length)]);
			Console.WriteLine("\nMonkey App Menu:");
			Console.WriteLine("1. List all monkeys");
			Console.WriteLine("2. Get details for a specific monkey by name");
			Console.WriteLine("3. Get a random monkey");
			Console.WriteLine("4. Exit app");
			Console.Write("\nSelect an option (1-4): ");
			var input = Console.ReadLine();
			Console.WriteLine();
			switch (input)
			{
				case "1":
					var monkeys = MonkeyHelper.GetAllMonkeys();
					Console.WriteLine("List of all monkeys:");
					foreach (var m in monkeys)
						Console.WriteLine($"- {m.Name}");
					break;
				case "2":
					Console.Write("Enter monkey name: ");
					var name = Console.ReadLine();
					var found = MonkeyHelper.FindMonkeyByName(name);
					if (found != null)
					{
						Console.WriteLine($"Name: {found.Name}\nLocation: {found.Location}\nPopulation: {found.Population}\nDetails: {found.Details}\nImage: {found.Image}\nCoords: {found.Latitude}, {found.Longitude}");
					}
					else
					{
						Console.WriteLine("Monkey not found.");
					}
					break;
				case "3":
					var randomMonkey = MonkeyHelper.GetRandomMonkey();
					Console.WriteLine($"Random Monkey: {randomMonkey.Name}\nLocation: {randomMonkey.Location}\nPopulation: {randomMonkey.Population}\nDetails: {randomMonkey.Details}\nImage: {randomMonkey.Image}\nCoords: {randomMonkey.Latitude}, {randomMonkey.Longitude}");
					Console.WriteLine($"\nRandom monkey picked {MonkeyHelper.GetRandomAccessCount()} times.");
					break;
				case "4":
					Console.WriteLine("Goodbye!");
					return;
				default:
					Console.WriteLine("Invalid option. Try again.");
					break;
			}
			Console.WriteLine("\nPress Enter to continue...");
			Console.ReadLine();
		}
	}
}
    