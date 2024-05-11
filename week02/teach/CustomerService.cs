/// <summary>
/// Maintain a Customer Service Queue.  Allows new customers to be 
/// added and allows customers to be serviced.
/// </summary>
public class CustomerService {
    public static void Run() {
        // Example code to see what's in the customer service queue:
        // var cs = new CustomerService(3);
        // Console.WriteLine(cs);

        // Test Cases

        // Test 1
        // Scenario: Add one customer to the queue and then serve the customer
        // Expected Result: The customer should be displayed
        Console.WriteLine("Test 1");
        var service = new CustomerService(2);
        service.AddNewCustomer();       
        service.ServeCustomer();
        // Defect(s) Found: The ServeCustomer method should get the customer before deleting from the list

        Console.WriteLine("=================");

        // Test 2
        // Scenario: Add two customers to the queue and then serve the customers in the right order
        // Expected Result: The customers should be displayed in the same order that they were entered
        Console.WriteLine("Test 2");
        service = new CustomerService(2);
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Before serving customers: {service}");
        service.ServeCustomer();
        service.ServeCustomer();
        Console.WriteLine($"After serving customers: {service}");
        // Defect(s) Found: 

        Console.WriteLine("=================");

        // Scenario: Serve a customer when there is no customer in the queue
        // Expected Result: An error message should be displayed
        Console.WriteLine("Test 3");
        service = new CustomerService(2);
        service.ServeCustomer();
        // Defect(s) Found: The ServeCustomer method should check the length of the queue and display an error message

        Console.WriteLine("=================");

        // Scenario: Enforce the max queue size
        // Expected Result: An error message should be displayed when the 3rd customer is added
        Console.WriteLine("Test 4");
        service = new CustomerService(2);
        service.AddNewCustomer();
        service.AddNewCustomer();
        service.AddNewCustomer();
        Console.WriteLine($"Service Queue: {service}"); 
        // Defect(s) Found: The AddNewCustomer method should use >= instead of > to check the queue size


        // Test 5
        // Queue max is 10 if invalid value is passed
        // Expected Result: The queue size should be 10
        Console.WriteLine("Test 5");
        service = new CustomerService(-1);
        Console.WriteLine($"Service Queue: {service}");
        // Defect(s) Found: 
    }

    private readonly List<Customer> _queue = new();
    private readonly int _maxSize;

    public CustomerService(int maxSize) {
        if (maxSize <= 0)
            _maxSize = 10;
        else
            _maxSize = maxSize;
    }

    /// <summary>
    /// Defines a Customer record for the service queue.
    /// This is an inner class.  Its real name is CustomerService.Customer
    /// </summary>
    private class Customer {
        public Customer(string name, string accountId, string problem) {
            Name = name;
            AccountId = accountId;
            Problem = problem;
        }

        private string Name { get; }
        private string AccountId { get; }
        private string Problem { get; }

        public override string ToString() {
            return $"{Name} ({AccountId})  : {Problem}";
        }
    }

    /// <summary>
    /// Prompt the user for the customer and problem information.  Put the 
    /// new record into the queue.
    /// </summary>
    private void AddNewCustomer() {
        // Verify there is room in the service queue
        if (_queue.Count > _maxSize) {
            Console.WriteLine("Maximum Number of Customers in Queue.");
            return;
        }

        Console.Write("Customer Name: ");
        var name = Console.ReadLine()!.Trim();
        Console.Write("Account Id: ");
        var accountId = Console.ReadLine()!.Trim();
        Console.Write("Problem: ");
        var problem = Console.ReadLine()!.Trim();

        // Create the customer object and add it to the queue
        var customer = new Customer(name, accountId, problem);
        _queue.Add(customer);
    }

    /// <summary>
    /// Dequeue the next customer and display the information.
    /// </summary>
    private void ServeCustomer() {
        if (_queue.Count <= 0) {
            Console.WriteLine("No customers in queue.");
            return;
        }
        else {
            var customer = _queue[0];
            _queue.RemoveAt(0);
            Console.WriteLine(customer);
        }
    }

    /// <summary>
    /// Support the WriteLine function to provide a string representation of the
    /// customer service queue object. This is useful for debugging. If you have a 
    /// CustomerService object called cs, then you run Console.WriteLine(cs) to
    /// see the contents.
    /// </summary>
    /// <returns>A string representation of the queue</returns>
    public override string ToString() {
        return $"[size={_queue.Count} max_size={_maxSize} => " + String.Join(", ", _queue) + "]";
    }
}