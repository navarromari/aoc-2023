string path = @".\input.txt";
List<int> two_digits = new List<int>();
List<string> string_digits = new List<string> { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

try
{
    if (File.Exists(path))
    {
        using (StreamReader sr = File.OpenText(path))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                List<string> digits = new List<string>();

                string letters = "";
                for (int i = 0; i < line.Length; i++)
                {
                    if (int.TryParse(line[i].ToString(), out _))
                    {
                        if (letters != "")
                        {
                            IEnumerable<string> matchingDigits = string_digits
                                .SelectMany(s => Enumerable.Range(0, Math.Max(0, letters.Length - s.Length + 1))
                                    .Where(i => letters.Substring(i, s.Length) == s)
                                    .Select(i => new { Index = i, Digit = s }))
                                .OrderBy(result => result.Index)
                                .Select(result => result.Digit);

                            foreach (string matchingDigit in matchingDigits)
                            {
                                Enum.TryParse<Digit>(matchingDigit, out Digit digitValue);
                                digits.Add(((int)digitValue).ToString());
                            }
                        }
                        letters = "";

                        digits.Add(line[i].ToString());
                    }
                    else
                    {
                        letters += line[i].ToString();
                    }
                }

                if (letters != "")
                {
                    IEnumerable<string> matchingDigits = string_digits
                        .SelectMany(s => Enumerable.Range(0, Math.Max(0, letters.Length - s.Length + 1))
                            .Where(i => letters.Substring(i, s.Length) == s)
                            .Select(i => new { Index = i, Digit = s }))
                        .OrderBy(result => result.Index)
                        .Select(result => result.Digit);

                    foreach (string matchingDigit in matchingDigits)
                    {

                        Enum.TryParse<Digit>(matchingDigit, out Digit digitValue);
                        digits.Add(((int)digitValue).ToString());
                    }
                }

                string two_digit = digits.First() + digits.Last();
                two_digits.Add(Int32.Parse(two_digit));
            }
        }

        Console.WriteLine("Total:" + two_digits.Sum());
    }
    else
    {
        Console.WriteLine("File Not Found");
    }
    Console.ReadLine();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

public enum Digit
{
    one = 1,
    two = 2,
    three = 3,
    four = 4,
    five = 5,
    six = 6,
    seven = 7,
    eight = 8,
    nine = 9,
}