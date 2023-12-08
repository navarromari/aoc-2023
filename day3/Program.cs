string path = @"C:\Users\maria\OneDrive\Documentos\Advent of Code\2023\day3\input.txt";

List<int> partNumbers = new List<int>();

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
        bool isPartNumber = false;

        for (i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                if (int.TryParse(matrix[i, j].ToString(), out _))
                {   
                    number += matrix[i, j];

                    if (i == 0)
                    {
                        if (j == 0)
                        {
                            if (isSymbol(matrix[i + 1, j]) || isSymbol(matrix[i, j + 1]) || isSymbol(matrix[i + 1, j + 1]))
                            {
                                isPartNumber = true;
                            }
                        }
                        else if (j == width - 1)
                        {
                            if (isSymbol(matrix[i + 1, j]) || isSymbol(matrix[i, j - 1]) || isSymbol(matrix[i + 1, j - 1]))
                            {
                                isPartNumber = true;
                            }
                        }
                        else
                        {
                            if (isSymbol(matrix[i, j + 1]) || isSymbol(matrix[i, j - 1]) || isSymbol(matrix[i + 1, j]) || isSymbol(matrix[i + 1, j - 1]) || isSymbol(matrix[i + 1, j + 1]))
                            {
                                isPartNumber = true;
                            }
                        }
                    }
                    else if (i == height - 1)
                    {
                        if (j == 0)
                        {
                            if (isSymbol(matrix[i - 1, j]) || isSymbol(matrix[i, j + 1]) || isSymbol(matrix[i - 1, j + 1]))
                            {
                                isPartNumber = true;
                            }
                        }
                        else if (j == width - 1)
                        {
                            if (isSymbol(matrix[i - 1, j]) || isSymbol(matrix[i, j - 1]) || isSymbol(matrix[i - 1, j - 1]))
                            {
                                isPartNumber = true;
                            }
                        }
                        else
                        {
                            if (isSymbol(matrix[i - 1, j]) || isSymbol(matrix[i, j + 1]) || isSymbol(matrix[i, j - 1]) || isSymbol(matrix[i - 1, j - 1]) || isSymbol(matrix[i - 1, j + 1]))
                            {
                                isPartNumber = true;
                            }
                        }
                    }
                    else if (j == 0)
                    {
                        if (isSymbol(matrix[i, j + 1]) || isSymbol(matrix[i - 1, j]) || isSymbol(matrix[i + 1, j]))
                        {
                            isPartNumber = true;
                        }
                    }
                    else if (j == width - 1)
                    {
                        if (isSymbol(matrix[i - 1, j]) || isSymbol(matrix[i + 1, j]) || isSymbol(matrix[i, j - 1]))
                        {
                            isPartNumber = true;
                        }
                    }
                    else
                    {
                        if (isSymbol(matrix[i, j - 1]) || isSymbol(matrix[i, j + 1]) || isSymbol(matrix[i - 1, j]) || isSymbol(matrix[i + 1, j]) || isSymbol(matrix[i - 1, j + 1]) || isSymbol(matrix[i - 1, j - 1]) || isSymbol(matrix[i + 1, j - 1]) || isSymbol(matrix[i + 1, j + 1]))
                        {
                            isPartNumber = true;
                        }
                    }

                }
                else
                {
                    if (isPartNumber)
                    {
                        partNumbers.Add(int.Parse(number));
                    }

                    number = "";
                    isPartNumber = false;

                }
            }
        }
    }
}
else
{
    Console.WriteLine("File Not Found");
}

Console.WriteLine("total " + partNumbers.Sum());