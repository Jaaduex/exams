 import java.util.Scanner;
 // Node class to represent each element in the linked list
 class Node {
 int data;
 Node next;
 // Constructor
 Node(int data) {
 this.data = data;
this.next = null;
 }
 }
 // Stack class that implements stack operations using a linked list
 class Stack {
 private Node top;
 private int size;
 // Constructor
 public Stack() {
 this.top = null;
 this.size = 0;
 }
 // Push operation
 public void push(int data) {
 Node newNode = new Node(data);
 newNode.next = top; // Point new node to current top
 top = newNode;
 size++;
 // Make new node the top
 System.out.println(data + " pushed to stack");
 }
 // Pop operation
 public void pop() {
 if (isEmpty()) {
 System.out.println("Stack is empty. Nothing to pop.");
 return;
 }
 int popped = top.data;
top = top.next;
 // Remove top node
 size--;
 System.out.println(popped + " popped from stack");
 }
 // Peek operation
 public void peek() {
 if (isEmpty()) {
 System.out.println("Stack is empty. Nothing to peek.");
 return;
 }
 System.out.println("Top element is: " + top.data);
 }
 // Check if stack is empty
 public boolean isEmpty() {
 return top == null;
 }
 // Get size of stack
 public void getSize() {
 System.out.println("Size of stack: " + size);
 }
 // Display all elements of the stack
 public void display() {
 if (isEmpty()) {
 System.out.println("Stack is empty.");
 return;
 }
 Node temp = top;
System.out.print("Stack elements: ");
 while (temp != null) {
 System.out.print(temp.data + " ");
 temp = temp.next;
 }
 System.out.println();
 }
 }
 public class StackUsingLinkedList {
 public static void main(String[] args) {
 Scanner scanner = new Scanner(System.in);
 Stack stack = new Stack();
 int choice;
 // Menu-driven program
 do {
 System.out.println("\nStack Operations:");
 System.out.println("1. Push");
 System.out.println("2. Pop");
 System.out.println("3. Peek");
 System.out.println("4. Check if Stack is Empty");
 System.out.println("5. Get Stack Size");
 System.out.println("6. Display Stack");
 System.out.println("7. Exit");
 System.out.print("Enter your choice: ");
 choice = scanner.nextInt();
 switch (choice) {
 case 1:
// Push operation
 System.out.print("Enter element to push: ");
 int data = scanner.nextInt();
 stack.push(data);
 break;
 case 2:
 // Pop operation
 stack.pop();
 break;
 case 3:
 // Peek operation
 stack.peek();
 break;
 case 4:
 // Check if stack is empty
 if (stack.isEmpty()) {
 System.out.println("Stack is empty.");
 } else {
 System.out.println("Stack is not empty.");
 }
 break;
 case 5:
 // Get size of stack
 stack.getSize();
 break;
 case 6:
 // Display stack
stack.display();
 break;
 case 7:
 System.out.println("Exiting...");
 break;
 default:
 System.out.println("Invalid choice. Please try again.");
 }
 } while (choice != 7);
 scanner.close();
 }
 }