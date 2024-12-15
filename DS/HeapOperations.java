/*10. Implementing Heap with different operations
a) To perform insertion operation
b) To create Heap using Heapify method
c) To perform Heap sort
d) To delete the value in heap*/
import java.util.Scanner;

// Class to implement a Max-Heap
class Heap {
    private int[] heap;
    private int size;
    private int capacity;

    // Constructor to initialize the heap
    public Heap(int capacity) {
        this.capacity = capacity;
        heap = new int[capacity];
        size = 0;
    }

    // Utility function to get the parent index
    private int parent(int index) {
        return (index - 1) / 2;
    }

    // Utility function to get the left child index
    private int leftChild(int index) {
        return 2 * index + 1;
    }

    // Utility function to get the right child index
    private int rightChild(int index) {
        return 2 * index + 2;
    }

    // a) Insert an element into the heap
    public void insert(int value) {
        if (size == capacity) {
            throw new IllegalStateException("Heap is full!");
        }
        heap[size] = value;
        size++;
        heapifyUp(size - 1);
    }

    private void heapifyUp(int index) {
        int temp = heap[index];
        while (index > 0 && temp > heap[parent(index)]) {
            heap[index] = heap[parent(index)];
            index = parent(index);
        }
        heap[index] = temp;
    }

    // b) Create a heap using the Heapify method
    public void buildHeap(int[] array) {
        if (array.length > capacity) {
            throw new IllegalStateException("Array exceeds heap capacity!");
        }
        size = array.length;
        System.arraycopy(array, 0, heap, 0, size);
        for (int i = (size / 2) - 1; i >= 0; i--) {
            heapifyDown(i);
        }
    }

    private void heapifyDown(int index) {
        int largest = index;
        int left = leftChild(index);
        int right = rightChild(index);

        if (left < size && heap[left] > heap[largest]) {
            largest = left;
        }
        if (right < size && heap[right] > heap[largest]) {
            largest = right;
        }
        if (largest != index) {
            swap(index, largest);
            heapifyDown(largest);
        }
    }

    // c) Perform Heap Sort
    public void heapSort() {
        int originalSize = size;
        for (int i = size - 1; i >= 0; i--) {
            swap(0, i);
            size--;
            heapifyDown(0);
        }
        size = originalSize; // Restore original size
    }

    // d) Delete the root value from the heap
    public int delete() {
        if (size == 0) {
            throw new IllegalStateException("Heap is empty!");
        }
        int root = heap[0];
        heap[0] = heap[size - 1];
        size--;
        heapifyDown(0);
        return root;
    }

    // Utility function to swap two elements in the heap
    private void swap(int i, int j) {
        int temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }

    // Display the heap
    public void display() {
        if (size == 0) {
            System.out.println("Heap is empty.");
        } else {
            for (int i = 0; i < size; i++) {
                System.out.print(heap[i] + " ");
            }
            System.out.println();
        }
    }
}

// Main class to test Heap operations
public class HeapOperations {
    public static void main(String[] args) {
        Scanner scanner = new Scanner(System.in);
        System.out.println("Enter the capacity of the heap:");
        int capacity = scanner.nextInt();
        Heap heap = new Heap(capacity);

        while (true) {
            System.out.println("\nHeap Operations:");
            System.out.println("1. Insert");
            System.out.println("2. Build Heap (Heapify)");
            System.out.println("3. Perform Heap Sort");
            System.out.println("4. Delete Root");
            System.out.println("5. Display Heap");
            System.out.println("6. Exit");
            System.out.print("Enter your choice: ");
            int choice = scanner.nextInt();

            switch (choice) {
                case 1 -> {
                    System.out.print("Enter value to insert: ");
                    int value = scanner.nextInt();
                    try {
                        heap.insert(value);
                        System.out.println(value + " inserted.");
                    } catch (IllegalStateException e) {
                        System.out.println(e.getMessage());
                    }
                }
                case 2 -> {
                    System.out.print("Enter the number of elements: ");
                    int n = scanner.nextInt();
                    int[] array = new int[n];
                    System.out.println("Enter the elements:");
                    for (int i = 0; i < n; i++) {
                        array[i] = scanner.nextInt();
                    }
                    try {
                        heap.buildHeap(array);
                        System.out.println("Heap built using heapify.");
                    } catch (IllegalStateException e) {
                        System.out.println(e.getMessage());
                    }
                }
                case 3 -> {
                    System.out.println("Performing Heap Sort...");
                    heap.heapSort();
                    heap.display();
                    System.out.println("Heap Sort completed.");
                }
                case 4 -> {
                    try {
                        int deletedValue = heap.delete();
                        System.out.println("Deleted root value: " + deletedValue);
                    } catch (IllegalStateException e) {
                        System.out.println(e.getMessage());
                    }
                }
                case 5 -> {
                    System.out.println("Current Heap:");
                    heap.display();
                }
                case 6 -> {
                    System.out.println("Exiting...");
                    scanner.close();
                    return;
                }
                default -> System.out.println("Invalid choice. Please try again.");
            }
        }
    }
}
