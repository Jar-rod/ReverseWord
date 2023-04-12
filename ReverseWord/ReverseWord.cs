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

        while (!ValidateLetterLength(sentences[i]))
        {
          System.Console.WriteLine($"Sentence must be >= {(int)Letters.min} or <= {(int)Letters.max} letters!");
          System.Console.Write($"{i+1}) ");
          sentences[i] = System.Console.ReadLine();
        }
      }

      for (int i = 0; i < numberOfCases; i++)
      {
        System.Console.WriteLine($"Case {i + 1}: {ReverseWords(sentences[i].Trim())}");
      }
    }

    public static string ReverseWords(string sentence)
    {
      string[] words = sentence.Split(" ");
      string[] reversedSentenceArray = new string[words.Length];
      string reversedSentence = "";

      for (int i = 0; i < words.Length; i++)
      {
        int index = words.Length - (i + 1);
        reversedSentenceArray[i] = words[index];
      }

      foreach (string word in reversedSentenceArray)
      {
        reversedSentence += $" {word}";
      }

      return reversedSentence;
    }

    /// <summary>
    /// Validates if the total number of letters within a sentence is 1 <= x <= 25.
    /// Space characters are to be removed first
    /// </summary>
    /// <param name="sentence"></param>
    /// <returns></returns>
    public static bool ValidateLetterLength(string sentence)
    {
      if (sentence.Replace(" ", "").Length <= (int)Letters.max && sentence.Replace(" ", "").Length >= (int)Letters.min)
      {
        return true;
      }
      return false;
    }

    private enum Letters
    {
      min = 1,
      max = 25
    }
  }
}