using Xunit;
using ReverseWord.Console;

namespace ReverseWord.UnitTest
{
  public class ReverseWordUnitTest
  {
 
    [Theory]
    [InlineData("this is a test", "test a is this")]
    [InlineData("foobar", "foobar")]
    [InlineData("all your base", "base your all")]
    public void ReverseWord_GivenMoreThanOneWord_ThenReverseTheSentence(string actual, string expected)
    {
      var actualValue = ReverseWord.Console.ReverseWord.ReverseWords(actual).Trim();
      
      Assert.Equal(
          expected,
          actualValue
      );
    }

    [Theory]
    [InlineData("this is a test that should failed but we'll try our best to can it right", true)]
    [InlineData("this should be validated", false)]
    [InlineData("a", false)] //exactly 1
    [InlineData("qwertyuiopasdfghjklzxcvbn", false)] //exactly 25
    public void ReverseWord_GivenMoreThanOneWordOf25letter_ThenReturnAnError(string actual, bool expected)
    {
      var actualValue = !ReverseWord.Console.ReverseWord.ValidateLetterLength(actual);

      Assert.Equal(
          expected,
          actualValue
      );
    }
  }
}