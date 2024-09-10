//Objectives: 
//•  Make a new project that includes the above code. 
//•  Add a Ripened event to the CharberryTree class that is raised when the tree ripens. 
//•  Make a  Notifier  class that knows about the tree (Hint:  perhaps pass it in as a constructor 
//parameter) and subscribes to its Ripened event. Attach a handler that displays something like “A 
//charberry fruit has ripened!” to the console window. 
//•  Make a Harvester class that knows about the tree (Hint: like the notifier, this could be passed as 
//a constructor parameter) and subscribes to its Ripened event. Attach a handler that sets the tree’s 
//Ripe property back to false. 
//•  Update your main method to create a tree, notifier, and harvester, and get them to work together 
//to grow, notify, and harvest forever.


public class CharberryTree
{
    private Random _random = new Random();
    public bool Ripe { get; set; }
    public event EventHandler<string>? Ripened ;
    static decimal countOfAttempt = 0M;
    public bool MaybeGrow()
    {
        // Only a tiny chance of ripening each time, but we try a lot! 
        double nextDouble;
        ++countOfAttempt;

        if ((nextDouble = _random.NextDouble()) < 0.00000001 && !Ripe)
        {
            Ripe = true;
            
            Ripened?.Invoke(this, $" { nextDouble } Ripened! Attempt #:{ countOfAttempt } ");
            countOfAttempt = 0;
            return true;
        }
        return false;
    }
}
public class Notifier {
    public Notifier(CharberryTree tree) {
        tree.Ripened += RipenedHandler;    
    }

    public void RipenedHandler(object sender, string message) 
    {        
        Console.WriteLine($"A { ((CharberryTree)sender).ToString() } has ripened with message: { message }");
    }
}
internal class Program
{
    private static void Main(string[] args)
    {
        CharberryTree tree = new CharberryTree();
        Notifier notifier = new Notifier(tree);
        while (true)
            if (tree.MaybeGrow() == true)
                break;

    }
}