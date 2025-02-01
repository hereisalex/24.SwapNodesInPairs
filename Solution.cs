public class Solution
{
    public class ListNode
    {
        public int val;
        public ListNode? next;
        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

    public static void Main(string[] args)
    {
        ListNode testNode = new(1, new(2, new(3, new(4))));

        var result = SwapPairs(testNode);
    }

    public static ListNode SwapPairs(ListNode head) // This solution uses a train analogy 
    {
        // If the train is empty or has only one carriage, nothing to swap
        if (head == null || head.next == null)
        {
            return head;
        }

        // Create a 'station' - a temporary holding area before the actual train
        ListNode station = new ListNode(0);
        station.next = head;

        // The 'conductor' starts at the station, managing the swapping process
        ListNode conductor = station;

        // Continue swapping as long as there are at least two carriages to swap
        while (conductor.next != null && conductor.next.next != null)
        {
            // Identify the carriages to be swapped
            ListNode firstCarriage = conductor.next;
            ListNode secondCarriage = conductor.next.next;
            ListNode remainingTrain = secondCarriage.next;

            // Initial state:
            //
            //   conductor
            //     |
            //   station -> [1] -> [2] -> [3] -> [4] -> ...
            //             first  second remaining
            //             carriage carriage train

            // Perform the swap:

            // 1. Conductor now points to the second carriage (which will become the first)
            conductor.next = secondCarriage;

            //   Initial state:
            //
            //             conductor
            //               \
            //                |
            //   station    [1] -> [2] -> [3] -> [4] -> ...
            //             first  second remaining
            //             carriage carriage train

            // 2. Second carriage now points to the first carriage
            secondCarriage.next = firstCarriage;

            //   After conductor.next = secondCarriage:
            //
            //            conductor
            //               \
            //                |
            //   station    [1] <- [2]    [3] -> [4] -> ...
            //             first     second remaining
            //             carriage  carriage train

            // 3. First carriage now points to the rest of the train
            firstCarriage.next = remainingTrain;

            //   After secondCarriage.next = firstCarriage:
            //
            //            conductor
            //               \
            //                |
            //   station    [1] <- [2]    [3] -> [4] -> ...
            //             ^      |      remaining
            //             |      v      train
            //             first carriage
            //              second
            //              carriage

            // After swapping:
            //
            //             conductor
            //                |
            //   station -> [2] -> [1] -> [3] -> [4] -> ...
            //             second  first  remaining
            //             carriage carriage train

            // Move the conductor to the end of the swapped pair (ready for the next swap)
            conductor = firstCarriage;

            // Conductor moves forward:
            //
            //                       conductor
            //                          |
            //   station -> [2] -> [1] -> [3] -> [4] -> ...
            //                     first  (next
            //                     carriage  pair
            //                               to swap)
        }

        // The train now departs from the station, skipping the temporary station node
        return station.next;
    }
}
