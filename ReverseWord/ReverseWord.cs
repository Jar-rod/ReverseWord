namespace ReverseWord.Console
{
  public class ReverseWord
  {
    static void Main()
    {
      System.Console.Write("Enter number of Cases: ");

      int numberOfCases;

      //Number must be valid
      while (!int.TryParse(System.Console.ReadLine(), out numberOfCases))
      {
        System.Console.Clear();
        System.Console.WriteLine("You have entered an invalid number!");
        System.Console.Write("Enter number of Cases: ");
      }

      string[] sentences = new string[numberOfCases];

      for (int i = 0; i < numberOfCases; i++)
      {
        System.Console.Write($"{i+1}) ");
        sentences[i] = System.Console.ReadLine();

        //1 < letters < 25
        while (!ValidateLetterLength(sentences[i]))
        {
          System.Console.WriteLine($"Sentence must be greater than {Letters.min} or less than {Letters.max} letters!");
          System.Console.Write($"{i+1}) ");
          sentences[i] = System.Console.ReadLine();
        }
      }

      for (int i = 0; i < numberOfCases; i++)
      {
        System.Console.WriteLine($"Case {i + 1}: {ReverseWords(sentences[i])}");
      }
    }

    public static string ReverseWords(string sentence)
    {
      string[] words = sentence.Split(" ");
      string[] reversedSentence = new string[words.Length];

      for (int i = 0; i < words.Length; i++)
      {
        int index = words.Length - (i + 1);
        reversedSentence[i] = words[index];
      }

      string output = "";
      foreach (string word in reversedSentence)
      {
        output += $" {word}";
      }

      return output;
    }

    public static bool ValidateLetterLength(string sentence)
    {
      if (sentence.Replace(" ", "").Length >= (int)Letters.max || sentence.Replace(" ", "").Length <= (int)Letters.min)
      {
        return false;
      }
      return true;
    }

    private enum Letters
    {
      min = 1,
      max = 25
    }
  }
}