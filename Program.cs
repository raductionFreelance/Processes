using System.Diagnostics;

namespace MyApp
{
    class Program
    {
        static async Task Main()
        {
            Process process = null;

            //1
            process = Process.Start("notepad.exe");
            process.WaitForExit();
            Console.WriteLine("Notepad was closed");

            //2
            Console.WriteLine("Would you like to close app when you want(1) or after 5 seconds(2)?");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    process = Process.Start("notepad.exe");
                    process.WaitForExit();
                    Console.WriteLine("Notepad was closed");
                    break;
                case 2:
                    process = Process.Start("mspaint.exe");
                    await Task.Delay(TimeSpan.FromSeconds(5));
                    if(!process.HasExited) process.Kill();
                    break;
            }
            //3
            Console.WriteLine("Enter first number: ");
            string num1 = Console.ReadLine();
            Console.WriteLine("Enter second number: ");
            string num2 = Console.ReadLine();
            Console.WriteLine("Enter option: ");
            string option = Console.ReadLine();
            ProcessStartInfo psi = new ProcessStartInfo
            {
                FileName = "powershell.exe",
                Arguments = $"-NoProfile -ExecutionPolicy Bypass -Command \"Write-Output ({num1} {option} {num2}); Read-Host 'Press Enter to close'\"",
                UseShellExecute = true
            };
            process = Process.Start(psi);
            process.WaitForExit();
            //4
            Console.WriteLine("Enter a way to a folder: ");
            string path = Console.ReadLine();
            
            Console.WriteLine("Enter a word to find: ");
            string word = Console.ReadLine();

            ProcessStartInfo psi1 = new ProcessStartInfo
            {
                FileName = "P2.exe",
                Arguments = $"\"{path}\" \"{word}\"",
                UseShellExecute = true
            };
            process = Process.Start(psi1);
            process.WaitForExit();
        }
    }
}