using System.Collections.Generic;
using Console = Colorful.Console;
using System.IO;
using System.Net;
using System.Drawing;
using System.Text.RegularExpressions;

namespace afClapper
{
	class Program
	{
		static void Main()
		{
			Console.Title = "Anonfile Clapper";
			Console.Clear();

			while (true)
			{

				Console.Write("\n");
				Console.WriteLine("                ▄▄▄        ██████      ▄████  ▄▄▄       ███▄    █   ▄████", Color.Red);
				Console.WriteLine("               ▒████▄    ▒██    ▒     ██▒ ▀█▒▒████▄     ██ ▀█   █  ██▒ ▀█▒", Color.Red);
				Console.WriteLine("               ▒██  ▀█▄  ░ ▓██▄      ▒██░▄▄▄░▒██  ▀█▄  ▓██  ▀█ ██▒▒██░▄▄▄░", Color.Red);
				Console.WriteLine("               ░██▄▄▄▄██   ▒   ██▒   ░▓█  ██▓░██▄▄▄▄██ ▓██▒  ▐▌██▒░▓█  ██▓", Color.Red);
				Console.WriteLine("                ▓█   ▓██▒▒██████▒▒   ░▒▓███▀▒ ▓█   ▓██▒▒██░   ▓██░░▒▓███▀▒", Color.Red);
				Console.WriteLine("                ▒▒   ▓▒█░▒ ▒▓▒ ▒ ░    ░▒   ▒  ▒▒   ▓▒█░░ ▒░   ▒ ▒  ░▒   ▒ ", Color.Red);
				Console.WriteLine("                 ▒   ▒▒ ░░ ░▒  ░ ░     ░   ░   ▒   ▒▒ ░░ ░░   ░ ▒░  ░   ░ ", Color.Red);
				Console.WriteLine("                 ░   ▒   ░  ░  ░     ░ ░   ░   ░   ▒      ░   ░ ░ ░ ░   ░ ", Color.Red);
				Console.WriteLine("                     ░  ░      ░           ░       ░  ░         ░       ░ ", Color.Red);
				Console.WriteLine("                            Anonfile Clapper by: yuhsecurity", Color.Red);
				Console.WriteLine("");
				Console.WriteLine("Enter your keyword(s):", Color.Red);
				Console.Write(">", Color.Red);
				string resp = Console.ReadLine();
				int count = 0;
				List<string> Links = new List<string>();
				using (WebClient wc = new WebClient())
				{
					string s = wc.DownloadString("https://google.com/search?q=inurl:anonfile.com+" + resp);
					Regex r = new Regex(@"https:\/\/anonfile.com\/\w+\/\w+");
					foreach (Match m in r.Matches(s))
					{
						count++;
						Links.Add(m.ToString());
					}
				}

				using (TextWriter tw = new StreamWriter(@"links.txt"))
				{
					foreach (string line in Links)
					{
						tw.WriteLine(line.ToString());
					}
				}

				Console.WriteLine();
				Console.WriteLine("Scraped " + count.ToString() + " links!", Color.Red);
				Console.ReadLine();
                Console.Clear();
			}
		}
	}
}
