string path = @"C:\Users\maria\OneDrive\Documentos\Advent of Code\2023\day3\input.txt";

Dictionary<string, List<int>> gearParts = new Dictionary<string, List<int>>();

bool isSymbol(char c)
{
    if(int.TryParse(c.ToString(), out _) || c == '.')
    {
        return false;
    } 

    return true;
}
if (File.Exists(path))
{
    using (StreamReader sr = File.OpenText(path))
    {
        int height = File.ReadLines(path).Count();
        int width = File.ReadLines(path).First().Length;

        string line;
        int i = 0;
        char[,] matrix = new char[width, height];

        while ((line = sr.ReadLine()) != null)
        {
            for (int j = 0; j < line.Length; j++)
            {
                matrix[i, j] = line[j];
            }
            i++;
        }

        string number = "";

        for (i = 0; i < height; i++)
        {
            for (int j = 0; j < width; j++)
            {
                if (int.TryParse(matrix[i, j].ToString(), out _) && j < width - 1)
                {   
                    number += matrix[i, j];
                }
                else
                {
                    if(int.TryParse(matrix[i, j].ToString(), out _))
                    {
                        number += matrix[i, j];
                    }

                    if (number != "")
                    {
                        int startIndex = j - number.Length;

                        if (i == 0)
                        {

                            for(int k = (startIndex > 0 ? startIndex - 1 : startIndex); k < (startIndex + number.Length  > width ? startIndex + number.Length : startIndex + number.Length + 1); k++)
                            {
                                if (matrix[i + 1, k] == '*')
                                {
                                    if (gearParts.ContainsKey("i:" + (i + 1).ToString() + "j:" +  k.ToString()))
                                    {

                                        gearParts["i:" + (i + 1).ToString() + "j:" + k.ToString()].Add(int.Parse(number));
                                    }
                                    else
                                    {
                                        gearParts.Add("i:" + (i + 1).ToString() + "j:" + k.ToString(), new List<int>{int.Parse(number)});
                                    }
                                }

                                if (matrix[i, k] == '*')
                                {
                                    if (gearParts.ContainsKey("i:" + (i + 1).ToString() + "j:" + k.ToString()))
                                    {
                                        gearParts["i:" + i.ToString() + "j:" + k.ToString()].Add(int.Parse(number));
                                    }
                                    else
                                    {
                                        gearParts.Add("i:" + i.ToString() + "j:" + k.ToString(), new List<int> { int.Parse(number) });
                                    }
                                }

                            }
                        }
                        else if (i == height - 1)
                        {
                            for (int k = (startIndex > 0 ? startIndex - 1 : startIndex); k < (startIndex + number.Length > width ? startIndex + number.Length : startIndex + number.Length + 1); k++)
                            {
                                if (matrix[i - 1, k] == '*')
                                {
                                    if (gearParts.ContainsKey("i:" + (i - 1).ToString() + "j:" + k.ToString()))
                                    {
                                        gearParts["i:" + (i - 1).ToString() + "j:" + k.ToString()].Add(int.Parse(number));
                                    }
                                    else
                                    {
                                        gearParts.Add("i:" + (i - 1).ToString() + "j:" + k.ToString(), new List<int> { int.Parse(number) });
                                    }
                                }

                                if (matrix[i, k] == '*')
                                {
                                    if (gearParts.ContainsKey("i:" + i.ToString() + "j:" + k.ToString()))
                                    {
                                        gearParts["i:" + i.ToString() + "j:" + k.ToString()].Add(int.Parse(number));
                                    }
                                    else
                                    {
                                        gearParts.Add("i:" + i.ToString() + "j:" + k.ToString(), new List<int> { int.Parse(number) });
                                    }
                                }

                            }
                        }
                        else
                        {
                            for (int k = (startIndex > 0 ? startIndex - 1 : startIndex); k < (startIndex + number.Length > width ? startIndex + number.Length : startIndex + number.Length + 1); k++)
                            {
                                if (matrix[i + 1, k] == '*')
                                {
                                    if (gearParts.ContainsKey("i:" + (i + 1).ToString() + "j:" + k.ToString()))
                                    {
                                        gearParts["i:" + (i + 1).ToString() + "j:" + k.ToString()].Add(int.Parse(number));
                                    }
                                    else
                                    {
                                        gearParts.Add("i:" + (i + 1).ToString() + "j:" + k.ToString(), new List<int> { int.Parse(number) });
                                    }
                                }

                                if (matrix[i - 1, k] == '*')
                                {
                                    if (gearParts.ContainsKey("i:" + (i - 1).ToString() + "j:" + k.ToString()))
                                    {
                                        gearParts["i:" + (i - 1).ToString() + "j:" + k.ToString()].Add(int.Parse(number));
                                    }
                                    else
                                    {
                                        gearParts.Add("i:" + (i - 1).ToString() + "j:" + k.ToString(), new List<int> { int.Parse(number) });
                                    }
                                }

                                if (matrix[i, k] == '*')
                                {
                                    if (gearParts.ContainsKey("i:" + i.ToString() + "j:" + k.ToString()))
                                    {
                                        gearParts["i:" + i.ToString() + "j:" + k.ToString()].Add(int.Parse(number));
                                    }
                                    else
                                    {
                                        gearParts.Add("i:" + i.ToString() + "j:" + k.ToString(), new List<int> { int.Parse(number) });
                                    }
                                }

                            }
                        }
                    }

                    number = "";               
                }
            }
        }

        List<int> ratios = new List<int>(); 

        foreach (KeyValuePair<string, List<int>> kvp in gearParts)
        {
            int result = 1;

            if (kvp.Value.Count() == 2)
            {
                foreach(int value in kvp.Value)
                {
                    result *= value;
                }

                ratios.Add(result);
            }
        }

        Console.WriteLine(ratios.Sum());
    }
}
else
{
    Console.WriteLine("File Not Found");
}

