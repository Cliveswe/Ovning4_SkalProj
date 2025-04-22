namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main() {

            while(true) {
                Console.WriteLine("Please navigate through the menu by inputting the number \n(1, 2, 3 ,4, 5, 0) of your choice"
                    + "\n1. Examine a List"
                    + "\n2. Examine a Queue"
                    + "\n3. Examine a Stack"
                    + "\n4. CheckParenthesis"
                    + "\n5. Recursive Even"
                    + "\n0. Exit the application");
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                } catch(IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                  {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch(input) {
                    case '1':
                    ExamineList();
                    break;
                    case '2':
                    ExamineQueue();
                    break;
                    case '3':
                    ExamineStack();
                    break;
                    case '4':
                    CheckParanthesis();
                    break;
                    case '5':
                    Recursive();
                    break;
                    case '0':
                    Environment.Exit(0);
                    break;
                    default:
                    Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4)");
                    break;
                }
            }
        }
        #region Examine List
        /// <summary>
        /// Examines the data-structure List
        /// </summary>
        static void ExamineList() {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */

            List<string> theList = new List<string>();
            do {

                Console.WriteLine("Enter text prefixed with either a \'+\', \'-\' or 0 to exit.");
                Console.Write("Enter text: ");
                string input = Console.ReadLine()!;
                char nav = input[0];
                string value = input.Substring(1);

                switch(nav) {
                    case '+':
                    theList.Add(input.Remove(0, 1));
                    break;
                    case '-':
                    theList.Remove(input.Remove(0, 1));
                    break;
                    case '0':
                    return;
                    default:
                    Console.WriteLine($"It is a requirement to start all text with a \"+\" or \"-\"{Environment.NewLine}");
                    break;
                }

                Console.WriteLine($"Count: {theList.Count}, Capacity: {theList.Capacity}");
                foreach(string str in theList) {
                    Console.WriteLine(str);
                }
                Console.WriteLine();
            } while(true);

            /*
             * Count is the number of elements that are currently in the list.
             * Capacity is the number of elements that can be stored in the list before
             * resizing is required.
             * 2) When count exceeds the current capacity then .NET framework resizes the list.
             * 3) The increase in the lists capacity is double the previous capacity.
             * 4) Resizing a list has trade offs. Memory is a resource and needs managing. Resizing 
             * the list after an element has been added to the list could increase the overhead of the
             * application. The overhead could be increased hardware resources and or more code to 
             * write and maintain. (This question is a little vague. Are we meant to answer why the 
             * underlying .NET framework doesn't increase the capacity or why we should adjust the 
             * capacity of the list!)
             * 5) No.
             * 6) Arrays are faster when accessing elements of the array because of the predicted size
             * of the array at compile time. Direct access to a specific element in the array using its
             * index. Thus, if you know ahead of time what you want to store in memory then an array
             * has a performance advantage over a list.
             * 
             * 
             * 
             *  Our ExamineList application is a trivial application and the overhead of
             * resizing the list is negligible. However, adding additional code to this application
             * to resize the list increases the 
             * by doubling its previous capacity.
             * Thus count can be 0 and capacity can be 4 meaning that the list is currently
             * empty but can hold 4 items of string.
             * 
             * However, when removing an item the list capacity persists at the previous size. 
             * To reduce the capacity of a list one could use the TrimExcess method alternately
             * set the Capacity property manually.
             * 
             * 
             * **/

        }
        #endregion

        #region Examine Queue
        /// <summary>
        /// Examines the data-structure Queue
        /// </summary>
        static void ExamineQueue() {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after enqueue and dequeue to see how it behaves
            */

            Queue<string> FIFOQueue = new();


            Console.WriteLine("ICA queue is open!");
            do {

                if(FIFOQueue.Count > 0) {

                    Console.WriteLine($"There {(FIFOQueue.Count > 1 ? "are" : "is only")} " +
                        $"{FIFOQueue.Count} people in the queue.");
                }
                else {

                    Console.WriteLine("The queue is empty.");
                }

                Console.WriteLine("\nEnter \'+\'name to add to the end of the queue,");
                Console.WriteLine("\'-\' to remove from the head of the queue or 0 to exit.");
                Console.Write("Enter command: ");

                char nav = Console.ReadKey().KeyChar;
                Console.WriteLine();
                switch(nav) {
                    case '+':
                    Console.Write("Name of person: ");
                    string name = Console.ReadLine()!;
                    FIFOQueue.Enqueue(name);
                    break;
                    case '-':
                    try {

                        FIFOQueue.Dequeue();
                    } catch(InvalidOperationException ex) {

                        Console.WriteLine("Queue is empty");
                    }
                    break;
                    case '0':
                    return;
                    default:
                    Console.WriteLine($"It is a requirement to start all text with a \"+\" or \"-\"{Environment.NewLine}");
                    break;
                }

                DisplayFIFOQueue(FIFOQueue);
            } while(true);
        }
        private static void DisplayFIFOQueue(Queue<string> FIFOQueue) {

            foreach(string queue in FIFOQueue) {
                Console.WriteLine(queue);
            }
            Console.WriteLine();
        }
        #endregion

        #region Examine Stack
        /// <summary>
        /// Examines the data-structure Stack
        /// </summary>
        static void ExamineStack() {
            /*
             * Loop this method until the user inputs something to exit to main menu.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and popping to see how it behaves
            */
            Stack<char> stack = new();

            Console.WriteLine("Write a sentence and I will reverse it.");
            Console.Write("Enter text: ");
            string? sentence = Console.ReadLine();

            if(sentence!.Length > 0) {

                //Push onto the stack.
                foreach(char letter in sentence) {
                    stack.Push(letter);
                }

                Console.WriteLine("Your sentence in reverse.");

                //Pop the stack.
                while(stack.Count > 0) {

                    Console.Write(stack.Pop());
                }
                Console.WriteLine();
            }
            else {

                Console.WriteLine("There is nothing to process.");
            }
        }
        #endregion

        #region Check Parenthesis
        static void CheckParanthesis() {
            /*
             * Use this method to check if the parenthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */
            Console.WriteLine("Write a sentences and I will check to see if all open parentheses are closed.");
            Console.Write("Enter text: ");
            string? sentence = Console.ReadLine();
            Stack<char> stack = new();

            foreach(char letter in sentence!) {
                switch(letter) {

                    case '(':
                    stack.Push(')');
                    break;
                    case '{':
                    stack.Push('}');
                    break;
                    case '[':
                    stack.Push(']');
                    break;
                    case ')':
                    case '}':
                    case ']':

                    if(stack.TryPeek(out char testCharacter))
                        if(testCharacter == letter)
                            stack.Pop();

                    break;
                    default:
                    continue;
                }
            }

            if(stack.Count == 0)
                Console.WriteLine("Your sentence has no open parenthesis!");
            else {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your sentence contains open parentheses");
                Console.Write("This is what remains in the stack: ");
                for(int index = 0; index < stack.Count; index++) {
                    Console.Write($"{stack.Pop()} ");
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        #endregion

        #region Recursive Even and Fibonacci Sequence
        //Recursive 
        private static void Recursive() {
            do {

                Console.Write("Enter an even number: ");
                if(int.TryParse(Console.ReadLine(), out int startN)) {

                    Console.WriteLine($"RecursiveEven({startN}) result = {RecursiveEven(startN)}");
                    Console.Write($"Fibonacci sequence: ");
                    FibonacciSequence(startN);
                    Console.WriteLine();
                    return;
                }
                else {

                    Console.WriteLine("nope!");
                }
            } while(true);

        }

        private static int RecursiveEven(int n) {
            if(n == 2)
                return 2;
            return (2 + RecursiveEven(n - 1));
        }

        private static void FibonacciSequence(int n) {
            Queue<int> FIFIQueue = new();

            Console.Write($"F({n}) = ");
            if(n > 0) {

                FIFIQueue.Enqueue(0);
                FIFIQueue.Enqueue(1);
                Fibonacci(0, 1, n, ref FIFIQueue);
                while(FIFIQueue.Count > 0) {

                    Console.Write($"{FIFIQueue.Dequeue()} ");
                }
                Console.WriteLine();
            }

        }

        private static void Fibonacci(int firsNumber, int secondNumber, int n, ref Queue<int> stack) {
            int thirdNumber = 0;

            thirdNumber = firsNumber + secondNumber;
            firsNumber = secondNumber;
            secondNumber = thirdNumber;
            stack.Enqueue(thirdNumber);

            if(n > 2)
                Fibonacci(firsNumber, secondNumber, n - 1, ref stack);
        }

        #endregion

    }
}

