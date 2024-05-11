public static class Priority {
    public static void Test() {
        // TODO Problem 2 - Write and run test cases and fix the code to match requirements
        // Example of creating and using the priority queue
        var priorityQueue = new PriorityQueue();
        Console.WriteLine(priorityQueue);

        // Test Cases

        // Test 1
        // Scenario: Test that Enqueue adds a new item to the back of the queue
        // Expected Result: [A (Pri:1), B (Pri:2), C (Pri:3)]
        
        Console.WriteLine("Test 1");
        var queue = new PriorityQueue();
        queue.Enqueue("A", 1);
        queue.Enqueue("B", 2);
        queue.Enqueue("C", 3);
        Console.WriteLine(queue);

        // Defect(s) Found: None

        Console.WriteLine("---------");

        // Test 2
        // Scenario: Remove the item with the highest priority
        // Expected Result: [A (Pri:1), B (Pri:2)]

        Console.WriteLine("Test 2");
        queue.Dequeue();
        Console.WriteLine(queue);

        // Defect(s) Found: The item with the highest priority is not being removed, add 1 to the index in the for loop


        Console.WriteLine("---------");

        // Test 3
        // Scenario: Remove the item with the highest priority
        // Expected Result: [A (Pri:1)]

        Console.WriteLine("Test 3");
        queue.Enqueue("A", 2);
        queue.Dequeue();
        Console.WriteLine(queue);

        // Defect(s) Found: None

        Console.WriteLine("---------");

        // Test 4
        // Scenario: Dequeue an empty queue
        // Expected Result: Error message "The queue is empty."

        Console.WriteLine("Test 4");
        queue = new PriorityQueue();
        queue.Dequeue();

        // Defect(s) Found: None


        Console.WriteLine("---------");
    }
}