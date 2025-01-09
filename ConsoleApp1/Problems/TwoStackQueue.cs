namespace ConsoleApp1.Problems;

public class TwoStackQueue
{
    private Stack<int> Input;
    private Stack<int> Output;
    
    public TwoStackQueue()
    {
        Input = new Stack<int>();
        Output = new Stack<int>();
    }
    
    public void Push(int x) {
        Input.Push(x);
    }
    
    public int Pop()
    {
        if (Output.Count == 0)
        {
            while (Input.Count > 0)
            {
                Output.Push(Input.Pop());
            }
        }
        return Output.Pop();
    }
    
    public int Peek()
    {
        if (Output.Count == 0)
        {
            while (Input.Count > 0)
            {
                Output.Push(Input.Pop());
            }
        }
        return Output.Peek();
    }
    
    public bool Empty()
    {
        return Output.Count == 0 && Input.Count == 0;
    }
    
    public int EvalRPN(string[] tokens) {
            
            var nums = new Stack<int>();
            foreach(var symbol in tokens)
            {
                if(int.TryParse(symbol, out var num)){
                    nums.Push(num);
                }
                else
                {
                    var second = nums.Pop();
                    var first = nums.Pop();
                    switch (symbol)
                    {
                        case "+":
                            nums.Push(first + second);
                            break; 
                        case "-":
                            nums.Push(first - second);
                            break;
                        case "*":
                            nums.Push(first * second);
                            break;
                        case "/":
                            nums.Push(first / second);
                            break;
                    }
                }
            }

            return nums.Pop();

    }
    
    public int[][] DivideArray(int[] nums, int k) {
        Array.Sort(nums);

        var result = new int[nums.Length / 3][];
        for (var i = 0; i < nums.Length; i+=3)
        {
            if (nums[i + 2] - nums[i] > k)
            {
                return Array.Empty<int[]>();
            }
            result[i] = new[] { nums[i], nums[i + 1], nums[i + 2] };
        }

        return result.Select(x=> x.ToArray()).ToArray();
    }
    
    public IList<int> SequentialDigits(int low, int high)
    {
        var allSeq = new List<int>(36);
        
        allSeq.Add(12);
        allSeq.Add(23);
        allSeq.Add(34);
        allSeq.Add(45);
        allSeq.Add(56);
        allSeq.Add(67);
        allSeq.Add(78);
        allSeq.Add(89);
        allSeq.Add(123);
        allSeq.Add(234);
        allSeq.Add(345);
        allSeq.Add(456);
        allSeq.Add(567);
        allSeq.Add(678);
        allSeq.Add(789);
        allSeq.Add(1234);
        allSeq.Add(2345);
        allSeq.Add(3456);
        allSeq.Add(4567);
        allSeq.Add(5678);
        allSeq.Add(6789);
        allSeq.Add(12345);
        allSeq.Add(23456);
        allSeq.Add(34567);
        allSeq.Add(45678);
        allSeq.Add(56789);
        allSeq.Add(123456);
        allSeq.Add(234567);
        allSeq.Add(345678);
        allSeq.Add(456789);
        allSeq.Add(1234567);
        allSeq.Add(2345678);
        allSeq.Add(3456789);
        allSeq.Add(12345678);
        allSeq.Add(23456789);
        allSeq.Add(123456789);

        return allSeq.Where(x => x >= low && x <= high).ToArray();

    }
    
   
}