/*
 * Adding a comment to the main function where 
*/
void Main()
{
	var test = new TestClass();
	test.CreatesStringArraySizeWithParameterDifference();
	test.CreatesStringArraySequence();
	test.ReturnFizzMultiple();
	test.ReturnBuzzMultiple();
	test.ReturnFizzBuzzMultiple();
	test.UseFizzBuzzBazzMultipleWithTruePredicate();
	test.UseFizzBuzzBazzMultipleWithFalsePredicate();
    //Comment added for master but first added as a Hot fix.
}

// Define other methods and classes here
interface FizzleBizzle
	 {
	
	 int Fizz { set; }
	 int Buzz { set; }
	
	 /// <summary>
	 /// FizzBuzz generates an array of strings representing the consecutive sequence of
	 /// integers from start to end. When the integer is a multiple of Fizz, the string
	 /// "Fizz" is added instead. Likewise, for multiples of Buzz, "Buzz" is added. For
	 /// multiples of both Fizz and Buzz, "FizzBuzz" is added. 
	 /// (e.g. With Fizz = 3, Buzz = 5, start = 1, and end = 15; the array looks like:
	 /// ["1", "2", "Fizz", "4", "Buzz", "Fizz", "7", "8", ... , "14", "FizzBuzz"])
	 /// </summary>
	 /// <param name="start"></param>
	 /// <param name="end"></param>
	 /// <returns></returns>
	 string[] FizzBuzz(int start, int end);
	
	 /// <summary>
	 /// FizzBuzzBazz returns the same result as FizzBuzz, except that instances of "FizzBuzz"
	 /// are "FizzBuzzBazz" where the Predicate bazz is true.
	 /// </summary>
	 /// <param name="start"></param>
	 /// <param name="end"></param>
	 /// <param name="bazz"></param>
	 /// <returns></returns>
	 string[] FizzBuzzBazz(int start, int end, Predicate<int> bazz);
	
	 }
	 /// <summary>
	 /// FizzBuzz Class implementation
	 /// </summary>
	 public class cFizzleBizzle : FizzleBizzle
	 {
	 
		public int Fizz 
		{ 
			set 
			{
				_fizz = value;
			} 
		}
		public int Buzz 
		{ 
			set 
			{
				_buzz = value;
			} 
		}
		
		private int _fizz;
		private int _buzz;
		
	 	public string[] FizzBuzz(int start, int end)
		{
			var size = DetermineStringSize(start, end);
			return CreateStringArraySequence(size, start);
		}
		
		public string[] FizzBuzzBazz(int start, int end, Predicate<int> bazz)
		{
			var size = DetermineStringSize(start, end);
			return CreateStringArraySequence(size, start, bazz);
		}
		
		private int DetermineStringSize(int start, int end)
		{
			var size = end + 1  - start;
			if(size <= 0)
			{
				"The start should be lower value than end".Dump("error");
			}
			
			return size;				
		}
		
		private string[] CreateStringArraySequence(int size, int start, Predicate<int> bazz = null)
		{
			var returnStringArray = new string[size];
			var integerVariable = start;
			for(int index = 0; index < size; index ++)
			{
				returnStringArray[index] = AddStringElement(integerVariable, bazz);
				integerVariable++;
			}
			return returnStringArray;
		}
		
		private string AddStringElement(int integerValue, Predicate<int> bazz = null)
		{
			if(isFizz(integerValue) && isBuzz(integerValue))
			{
				if(bazz != null)
				{
					return bazz(integerValue)? "FizzBuzzBazz" : "FizzBuzz";
				}
				else
				{
					return "FizzBuzz";
				}				
			}
			if(isFizz(integerValue))
			{
				return "Fizz";
			}
			if(isBuzz(integerValue))
			{
				return "Buzz";
			}
			return integerValue.ToString();
		}
		
		private bool isFizz(int integerValue)
		{
			if(_fizz != 0)
			{
				return integerValue%_fizz == 0? true : false;
			}
			else
			{
				return integerValue == 0? true : false;
			}
		}
		
		private bool isBuzz(int integerValue)
		{
			if(_buzz != 0)
			{
				return integerValue%_buzz == 0? true : false;
			}
			else
			{
				return integerValue == 0? true : false;
			}
		}
	 }
	 
	 public class TestClass
	 {
	 	public void CreatesStringArraySizeWithParameterDifference()
		{
			"Arrange".Dump();
			int start = 1;
			int end = 1;
			"Act".Dump();
			FizzleBizzle fbinstance = new cFizzleBizzle();
			fbinstance.Fizz = 1;
			fbinstance.Buzz = 1;
			var fizzBuzzStrArray =fbinstance.FizzBuzz(start, end);
			"Assert".Dump();
			var arrayLengthIs1 = fizzBuzzStrArray.Length == 1? true : false;
			arrayLengthIs1.Dump();
		
			"Arrange".Dump();
			start = 1;
			end = 2;
			"Act".Dump();
			fbinstance = new cFizzleBizzle();
			fbinstance.Fizz = 1;
			fbinstance.Buzz = 1;
			fizzBuzzStrArray =fbinstance.FizzBuzz(start, end);
			"Assert".Dump();
			var arrayLengthIs2 = fizzBuzzStrArray.Length == 2? true : false;
			arrayLengthIs2.Dump();
			
			"Arrange".Dump();
			start = 1;
			end = 3;
			"Act".Dump();
			fbinstance = new cFizzleBizzle();
			fbinstance.Fizz = 1;
			fbinstance.Buzz = 1;
			fizzBuzzStrArray =fbinstance.FizzBuzz(start, end);
			"Assert".Dump();
			var arrayLengthIs3 = fizzBuzzStrArray.Length == 3? true : false;
			arrayLengthIs3.Dump();
		}
		
		public void CreatesStringArraySequence()
		{
			"Arrange".Dump();
			int start = 1;
			int end = 3;
			"Act".Dump();
			FizzleBizzle fbinstance = new cFizzleBizzle();
			fbinstance.Fizz = 5;
			fbinstance.Buzz = 5;
			var fizzBuzzStrArray =fbinstance.FizzBuzz(start, end);
			"Assert".Dump();
			fizzBuzzStrArray[0].Dump("Element at 0 is 1");
			fizzBuzzStrArray[1].Dump("Element at 1 is 2");
			fizzBuzzStrArray[2].Dump("Element at 2 is 3");
		}
		
		public void ReturnFizzMultiple()
		{
			"Arrange".Dump();
			int start = 1;
			int end = 1;
			"Act".Dump();
			FizzleBizzle fbinstance = new cFizzleBizzle();
			fbinstance.Fizz = 1;
			fbinstance.Buzz = 5;
			var fizzBuzzStrArray =fbinstance.FizzBuzz(start, end);
			"Assert".Dump();
			fizzBuzzStrArray[0].Dump("Returns Fizz");
		}
		
		public void ReturnBuzzMultiple()
		{
			"Arrange".Dump();
			int start = 2;
			int end = 3;
			"Act".Dump();
			FizzleBizzle fbinstance = new cFizzleBizzle();
			fbinstance.Fizz = 2;
			fbinstance.Buzz = 3;
			var fizzBuzzStrArray =fbinstance.FizzBuzz(start, end);
			"Assert".Dump();
			fizzBuzzStrArray[0].Dump("Returns Fizz");
			fizzBuzzStrArray[1].Dump("Returns Buzz");
		}
		
		public void ReturnFizzBuzzMultiple()
		{
			"Arrange".Dump();
			int start = 1;
			int end = 15;
			"Act".Dump();
			FizzleBizzle fbinstance = new cFizzleBizzle();
			fbinstance.Fizz = 3;
			fbinstance.Buzz = 5;
			var fizzBuzzStrArray =fbinstance.FizzBuzz(start, end);
			"Assert".Dump();
			fizzBuzzStrArray[14].Dump("Returns FizzBuzz");
		}
		
		public void UseFizzBuzzBazzMultipleWithTruePredicate()
		{
			"Arrange".Dump();
			int start = 1;
			int end = 15;
			"Act".Dump();
			FizzleBizzle fbinstance = new cFizzleBizzle();
			fbinstance.Fizz = 3;
			fbinstance.Buzz = 5;
			var fizzBuzzStrArray =fbinstance.FizzBuzzBazz(start, end,  x => x == 15);
			"Assert".Dump();
			fizzBuzzStrArray[14].Dump("Returns FizzBuzzBazz");
		}
		
		public void UseFizzBuzzBazzMultipleWithFalsePredicate()
		{
			"Arrange".Dump();
			int start = 1;
			int end = 15;
			"Act".Dump();
			FizzleBizzle fbinstance = new cFizzleBizzle();
			fbinstance.Fizz = 3;
			fbinstance.Buzz = 5;
			var fizzBuzzStrArray =fbinstance.FizzBuzzBazz(start, end, x => x != 15);
			"Assert".Dump();
			fizzBuzzStrArray[14].Dump("Does not returns FizzBuzzBazz");
		}
	 }
