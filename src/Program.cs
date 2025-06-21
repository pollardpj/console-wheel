using System.Security.Cryptography;

class Program
{
    static string[] GenerateAsciiArt(string text)
    {
        text = text.ToUpper();
        string[] result = new string[7];
        
        for (int i = 0; i < 7; i++)
        {
            result[i] = "";
            foreach (char c in text)
            {
                if (AsciiArt.AsciiFont.ContainsKey(c))
                {
                    result[i] += AsciiArt.AsciiFont[c][i];
                }
                else
                {
                    result[i] += "   "; // Default space for unknown characters
                }
            }
        }
        
        return result;
    }

    static string GetRandomString(string[] strings)
    {
        if (strings == null || strings.Length == 0)
            return "HELLO";
        
        // Use cryptographically secure random number generator
        using (var rng = RandomNumberGenerator.Create())
        {
            byte[] randomBytes = new byte[4];
            rng.GetBytes(randomBytes);
            int randomIndex = Math.Abs(BitConverter.ToInt32(randomBytes, 0)) % strings.Length;
            return strings[randomIndex];
        }
    }

    static void Main(string[] args)
    {
        // Enable ANSI color support for Windows
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        
        // Clear console and set title
        Console.Clear();
        Console.Title = "CX Digital - Console Wheel";
        
        // Get user input
        Console.WriteLine($"{AsciiArt.Colors.Bright}{AsciiArt.Colors.Cyan}╔═══════════════════════════════════════════════════════╗{AsciiArt.Colors.Reset}");
        Console.WriteLine($"{AsciiArt.Colors.Bright}{AsciiArt.Colors.Cyan}║              CX Digital - Console Wheel               ║{AsciiArt.Colors.Reset}");
        Console.WriteLine($"{AsciiArt.Colors.Bright}{AsciiArt.Colors.Cyan}╚═══════════════════════════════════════════════════════╝{AsciiArt.Colors.Reset}");
        Console.WriteLine();
        Console.WriteLine($"{AsciiArt.Colors.Yellow}Enter comma-separated list of strings (e.g., HELLO,WORLD,FUNKY):{AsciiArt.Colors.Reset}");
        Console.Write($"{AsciiArt.Colors.Green}> {AsciiArt.Colors.Reset}");
        
        string inputText = Console.ReadLine() ?? "HELLO,WORLD,FUNKY";
        Console.WriteLine();
        
        // Split the input by commas and clean up whitespace
        string[] stringList = inputText.Split(',')
                                      .Select(s => s.Trim())
                                      .Where(s => !string.IsNullOrEmpty(s))
                                      .ToArray();
        
        // Get a random string from the list
        string selectedText = GetRandomString(stringList);
        
        Console.WriteLine($"{AsciiArt.Colors.Magenta}Randomly selected: {AsciiArt.Colors.Bright}{selectedText}{AsciiArt.Colors.Reset}");
        Console.WriteLine();
        
        // Generate ASCII art from selected text
        string[] asciiArt = GenerateAsciiArt(selectedText);
        
        string[] colors = { AsciiArt.Colors.Red, AsciiArt.Colors.Yellow, AsciiArt.Colors.Green, AsciiArt.Colors.Cyan, AsciiArt.Colors.Blue, AsciiArt.Colors.Magenta };
        
        // Animation loop
        int colorIndex = 0;
        int animationFrames = 20;
        
        for (int frame = 0; frame < animationFrames; frame++)
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            
            // Add some funky spacing and effects
            Console.WriteLine($"{AsciiArt.Colors.Bright}{AsciiArt.Colors.Cyan}╔═══════════════════════════════════════════════════════╗{AsciiArt.Colors.Reset}");
            Console.WriteLine($"{AsciiArt.Colors.Bright}{AsciiArt.Colors.Cyan}║              CX Digital - Console Wheel               ║{AsciiArt.Colors.Reset}");
            Console.WriteLine($"{AsciiArt.Colors.Bright}{AsciiArt.Colors.Cyan}╚═══════════════════════════════════════════════════════╝{AsciiArt.Colors.Reset}");
            Console.WriteLine();
            
            // Display the ASCII art with rainbow colors
            for (int i = 0; i < asciiArt.Length; i++)
            {
                string currentColor = colors[(colorIndex + i) % colors.Length];
                Console.WriteLine($"{AsciiArt.Colors.Bright}{currentColor}{asciiArt[i]}{AsciiArt.Colors.Reset}");
            }
            
            colorIndex = (colorIndex + 1) % colors.Length;
            Thread.Sleep(200);
        }
        
        // Final static display
        Console.Clear();
        Console.WriteLine($"{AsciiArt.Colors.Bright}{AsciiArt.Colors.Cyan}╔═══════════════════════════════════════════════════════╗{AsciiArt.Colors.Reset}");
        Console.WriteLine($"{AsciiArt.Colors.Bright}{AsciiArt.Colors.Cyan}║              CX Digital - Console Wheel               ║{AsciiArt.Colors.Reset}");
        Console.WriteLine($"{AsciiArt.Colors.Bright}{AsciiArt.Colors.Cyan}╚═══════════════════════════════════════════════════════╝{AsciiArt.Colors.Reset}");
        Console.WriteLine();
        
        for (int i = 0; i < asciiArt.Length; i++)
        {
            string currentColor = colors[i % colors.Length];
            Console.WriteLine($"{AsciiArt.Colors.Bright}{currentColor}{asciiArt[i]}{AsciiArt.Colors.Reset}");
        }
        
        Console.WriteLine();
        Console.WriteLine($"{AsciiArt.Colors.Cyan}Press any key to exit...{AsciiArt.Colors.Reset}");
        Console.ReadKey();
    }
}
