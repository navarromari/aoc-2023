import java.io.*;
import java.util.Arrays;

public class Main {
    public static void main(String[] args)
    {
        int totalPoints = 0;
        try
        {
            File file = new File("./res/input");
            FileReader fr = new FileReader(file);
            BufferedReader br= new BufferedReader(fr);
            String line;
            while((line = br.readLine())!= null)
            {
                int cardPoints = 0;
                String scratchcard[] = line.split("\\|", 0);
                String winnerNumbers[] = scratchcard[0].split("\\s+", 0);
                winnerNumbers = Arrays.copyOfRange(winnerNumbers, 2, winnerNumbers.length);
                for (String number : winnerNumbers){
                    System.out.println(number);
                }
                String myNumbers[] = scratchcard[1].split("\\s+", 0);

                for(String number : winnerNumbers)
                {
                    for(String myNumber : myNumbers )
                    {
                        if(number.equals(myNumber))
                        {
//                            System.out.println("COMPARING: " + number + " with " + myNumber);
                            if (cardPoints == 0)
                            {
                                cardPoints = 1;
                            }
                            else
                            {
                                cardPoints *= 2;
                            }
                        }
                    }
                }
                totalPoints += cardPoints;
            }
            fr.close();
        }
        catch(IOException e)
        {
            e.printStackTrace();
        }
        System.out.println(totalPoints);
    }
}