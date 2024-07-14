using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RockyouSearcher;

internal class RockyouSearcher
{
    static void Main(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine("No arguments defined...");
            return;
        }
        int countCriteria = args.Length - 1;
        ulong counter = 1;
        string file = args[0];
        string? line;
        string[] searchCriteria = new string[countCriteria];
        string? resultString;
        char firstchar = 'a';
        bool checkFirstLetter = false;

        List<char> criteriaChars = new List<char>();
        List<string> resultList = new List<string>();
        List<string> relevantCriteria = new List<string>();

        Timer timer = new Timer();

        for (int i = 1; i <= countCriteria; i++)
        {
            searchCriteria[i - 1] = args[i];
        }

        foreach (var c in searchCriteria)
        {
            if (!criteriaChars.Contains(c[0]))
            {
                criteriaChars.Add(c[0]);
            }
        }

        if (File.Exists(file))
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            timer.Start();
            using (StreamReader sr = new StreamReader(file))
            {
                while ((line = sr.ReadLine()) != null){
                    if (counter % 1_000_000 == 0)
                        Console.WriteLine(counter);
                    if (line != "" && line[0] != firstchar)
                    {
                        firstchar = line[0];
                        relevantCriteria = searchCriteria.Where(c => c.StartsWith(firstchar)).ToList();
                        Console.WriteLine(firstchar.ToString());
                        checkFirstLetter = criteriaChars.Contains(firstchar);
                    }
                    if (checkFirstLetter)
                    {
                        foreach (string c in relevantCriteria)
                        {
                            if (line.StartsWith(c))
                            {
                                resultList.Add(counter.ToString() + ';' + line);
                                Console.WriteLine(counter.ToString() + ';' + line);
                            }
                        }
                    }
                    counter++;
                }
            }

            resultString = String.Join(Environment.NewLine, resultList);
            Console.WriteLine("Results:\n");
            Console.WriteLine($@"Found {resultList.Count} matches");
            string resultPath = Directory.GetCurrentDirectory() + @"\results.txt";
            File.WriteAllText(resultPath, resultString);
            Console.WriteLine($@"Results written to {resultPath}");
            timer.Stop();
        }
        else
        {
            Console.WriteLine("File not Found");
        }
    }
}


internal class Timer
{
    private TimeSpan timeTaken;
    private Stopwatch timer = new Stopwatch();

    public void Start()
    {
        timer.Start();
    }

    public void Stop()
    {
        timer.Stop();
        timeTaken = timer.Elapsed;
        Console.WriteLine($"Time taken: {timeTaken.ToString(@"m\:ss\.fff")} Minutes");
    }
}