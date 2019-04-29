using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Fivem_auto_restart
{
    class Program
    {
        public static string time;
        public static string countdown;


        public static void Main(string[] args)
        {
            //Strings and var(s)
            string restarts;
            string directory = AppDomain.CurrentDomain.BaseDirectory;
            string path = "restartsettings.txt";
            string lang;
            var retry = true;
            var retry2 = true;
            //Strings end here

            if (Directory.Exists(directory) && File.Exists(path)) //If directory exist.
            {
                string[] lines = File.ReadAllLines(path, Encoding.UTF8);
                if (lines[0] == "en")
                {
                    while (true)
                    {
                        while (retry2 == true)
                        {
                            time = DateTime.Now.ToString("HH:mm:ss");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.WriteLine("You are all set!");
                            Console.WriteLine("Current time: " + time);
                            Console.WriteLine("Next restart: " + countdown);
                            for (int k = 0; k < 25; k++)
                            {
                                if (time == lines[k])
                                {
                                    retry2 = false;
                                }
                            }

                        }
                        Console.Clear();
                        Console.WriteLine("Restarting...");
                        foreach (Process proc in Process.GetProcessesByName("cmd"))
                        {
                            proc.Kill();
                        }
                        Process.Start("cmd.exe").Close();
                        Thread.Sleep(3000);
                        retry2 = true;
                    }
                }
                else
                {
                    while (true)
                    {
                        while (retry2 == true)
                        {
                            time = DateTime.Now.ToString("HH:mm:ss");
                            Thread.Sleep(1000);
                            Console.Clear();
                            Console.WriteLine("Bra jobbat! Nu kan du luta dig tillbaka och programmet sköter allt!");
                            Console.WriteLine("Aktuell tid: " + time);
                            Console.WriteLine("Nästa restart: " + countdown);
                            for (int k = 0; k < 25; k++)
                            {
                                if (time == lines[k])
                                {
                                    retry2 = false;
                                }
                            }

                        }
                        Console.Clear();
                        Console.WriteLine("Startar om...");
                        foreach (Process proc in Process.GetProcessesByName("cmd"))
                        {
                            proc.Kill();
                        }
                        Process.Start("start.bat").Close();
                        Thread.Sleep(3000);
                        retry2 = true;
                    }
                }
            }


            if (Directory.Exists(directory) && !File.Exists(path))
            {
                File.Create(path).Close();
                while (retry == true)
                {
                    //Welcome etc
                    Console.Clear();
                    Console.WriteLine("====================================");
                    Console.WriteLine("                EN");
                    Console.WriteLine("====================================");
                    Console.WriteLine("Welcome to MHL's (open source) Fivem Auto Restart.");
                    Console.WriteLine("This should be your first time opening this program, you only need to set up things 1 time.");
                    Console.WriteLine("For help, write !help");
                    Console.WriteLine("To report a bug(s) report: https://steamcommunity.com/id/omgmhl/ (my steam profile)");
                    Console.WriteLine("To proceed type in a command (!start or !help).");
                    Console.WriteLine("====================================");
                    Console.WriteLine("                SV");
                    Console.WriteLine("====================================");
                    Console.WriteLine("Välkommen till MHL's (öppen källa) Fivem Auto Restart.");
                    Console.WriteLine("Detta bör vara den första gången du öppnar programmet, du behöver bara ställa in programmet 1 gång.");
                    Console.WriteLine("För hjälp, skriv !hjälp");
                    Console.WriteLine("För att rapportera fel / error(s): https://steamcommunity.com/id/omgmhl/ (min steam profil)");
                    Console.WriteLine("För att fortsätta skriv in ett command (!start eller !hjälp).");
                    Console.WriteLine(" ");
                    lang = Console.ReadLine();

                    //Main menu starts here
                    switch (lang.ToLower())
                    {
                        case "!hjälp":
                            Console.Clear();
                            Console.WriteLine("Nuvarande version: v1.0");
                            Console.WriteLine("Det här är dom tillgängliga kommandsen: !start and !help");
                            Console.WriteLine("Min github sida: https://github.com/MHL1337 där kan du hitta dom senaste uppdateringarna + mer hjälp");
                            Console.WriteLine(" ");
                            Console.WriteLine("Fråga: Jag har redan ställt in programmet 1 gång. Varför hamnar jag i menyn?");
                            Console.WriteLine("Svar: Se till att du öppnar programmet som administrator. Se även till att ditt anti-virus inte blockerar programmet.");
                            Console.WriteLine(" ");
                            Console.WriteLine("Fråga: Programmet funkar inte!!");
                            Console.WriteLine("Svar: Se till att din exe fil ligger i samma map som din run.bat (eller start.bat)");
                            Console.ReadKey();
                            retry = true;
                            break;
                        case "!help":
                            Console.Clear();
                            Console.WriteLine("Current version: v1.0");
                            Console.WriteLine("These are the available commands: !start and !help");
                            Console.WriteLine("My github profile: https://github.com/MHL1337 where you can find the latest uppdates + more help!");
                            Console.WriteLine(" ");
                            Console.WriteLine("Question: I have already done the setup once. Why do i have to do it again?");
                            Console.WriteLine("Answer: Make sure you open the exe with administrator rights. Also, make sure your anti-virus is not blocking the exe.");
                            Console.WriteLine(" ");
                            Console.WriteLine("Question: It WONT WORK!!");
                            Console.WriteLine("Answer: Make sure the exe is in the same folder as the run.bat is! (or the start.bat)");
                            Console.ReadKey();
                            break;
                        case "!start":
                            Console.Clear();
                            retry = false;
                            break;
                        default: //Error message
                            Console.Clear();
                            Console.WriteLine("====================================");
                            Console.WriteLine("               ERROR");
                            Console.WriteLine("====================================");
                            Console.WriteLine("                EN");
                            Console.WriteLine("====================================");
                            Console.WriteLine("You have writen a invalid command.");
                            Console.WriteLine("To proceed to main menu, press any key.");
                            Console.WriteLine("====================================");
                            Console.WriteLine("                SV");
                            Console.WriteLine("====================================");
                            Console.WriteLine("Du har skrivit in ett ogiltigt kommand");
                            Console.WriteLine("För att komma tillbaka till menyn klicka på valfri tangent.");
                            Console.ReadKey();
                            Console.Clear();
                            break;//Error message ends here
                    }
                }
                //Main menu ends here

                retry = true;
                //Choose lang
                while (retry == true)
                {
                    Console.Clear();
                    Console.Write("Choose your language (SV/EN): ");
                    lang = Console.ReadLine();

                    switch (lang.ToLower())
                    {
                        case "en":
                            Console.Clear();
                            Console.WriteLine("How many hours should pass before every restart?");
                            restarts = Console.ReadLine();
                            using (StreamWriter writer = new StreamWriter(path))
                            {
                                writer.WriteLine("en");
                                for (int i = 0; i < 25; i = i + Convert.ToInt32(restarts))
                                {
                                    if (i < 10)
                                    {
                                        writer.WriteLine("0" + i + ":00" + ":00");
                                    }
                                    else
                                    {
                                        writer.WriteLine(i + ":00" + ":00");
                                    }
                                }
                            }
                            
                            Console.Clear();
                            Console.WriteLine("Congrats! You have now configured the restarts! Restart the program to start!");
                            Console.ReadKey();
                            retry = false;
                            break;

                        case "sv":
                            Console.Clear();
                            Console.WriteLine("Hur många timmar ska det gå innan varje restart?");
                            restarts = Console.ReadLine();
                            using (StreamWriter writer = new StreamWriter(path))
                            {
                                writer.WriteLine("sv");
                                for (int i = 0; i < 25; i = i + Convert.ToInt32(restarts))
                                {
                                    if (i < 10)
                                    {
                                        writer.WriteLine("0" + i + ":00" + ":00");
                                    }
                                    else
                                    {
                                        writer.WriteLine(i + ":00" + ":00");
                                    }
                                }
                            }

                            Console.Clear();
                            Console.WriteLine("Du har konfigurerat klart nu! Var god och öppna och stäng appen!");
                            Console.ReadKey();
                            retry = false;
                            break;

                        default: //Error message
                            Console.Clear();
                            Console.WriteLine("====================================");
                            Console.WriteLine("               ERROR");
                            Console.WriteLine("====================================");
                            Console.WriteLine("                EN");
                            Console.WriteLine("====================================");
                            Console.WriteLine("You have writen a invalid command.");
                            Console.WriteLine("To proceed back, press any key.");
                            Console.WriteLine("====================================");
                            Console.WriteLine("                SV");
                            Console.WriteLine("====================================");
                            Console.WriteLine("Du har skrivit in ett ogiltigt kommand");
                            Console.WriteLine("För att fortsätta tillbaka, klicka på valfri tangent.");
                            Console.ReadKey();
                            Console.Clear();
                            break;//Error message ends here
                    }
                }//Choose lang end here
            }
        }
    }
}
