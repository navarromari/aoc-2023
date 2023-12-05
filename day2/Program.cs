string path = @".\input.txt";

Dictionary<int, int> gamesDict = new Dictionary<int, int>();
Dictionary<string, int> cubesOnBag = new Dictionary<string, int>
{
    {"red", 12 },
    {"green", 13 },
    {"blue", 14 }
};

if (File.Exists(path))
{
    using (StreamReader sr = File.OpenText(path))
    {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
            string [] parts = line.Split(':');

            int gameID = Int32.Parse(parts[0].Split(' ')[1]);

            string[] gameRuns = parts[1].Split(';');

            

            foreach (string gameRun in gameRuns) 
            {
                string[] cubes = gameRun.Split(',');

                int validCubs = 0;

                foreach (string cub in cubes)
                {
                    string trimmedCube = cub.Trim();

                    string color = trimmedCube.Split(' ')[1];
                    int quantity = Int32.Parse(trimmedCube.Split(' ')[0]);

                    if (cubesOnBag.ContainsKey(color) && cubesOnBag[color] >= quantity)
                    {
                        validCubs++;
                    }
                }

                if (validCubs != cubes.Length)
                {
                    gamesDict.Add(gameID, 0);
                    break;
                }

            }

            if (!gamesDict.ContainsKey(gameID))
            {
                gamesDict.Add(gameID, 1);
            }
        }
    }
}
else
{
    Console.WriteLine("File Not Found");
}

List<int> possibleGames = gamesDict
    .Where(pair => pair.Value == 1)
    .Select(pair => pair.Key)
    .ToList();

Console.WriteLine(possibleGames.Sum());