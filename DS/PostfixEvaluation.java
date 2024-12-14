import java.util.Scanner;
 import java.util.Stack;
 public class PostfixEvaluation {
 // Method to evaluate a postfix expression
 public static int evaluatePostfix(String expression) {
 Stack<Integer> stack = new Stack<>();
 // Traverse the expression
 for (int i = 0; i < expression.length(); i++) {
 char ch = expression.charAt(i);
 // If the character is a digit, push it to the stack
 if (Character.isDigit(ch)) {
 stack.push(ch- '0'); // Convert character to integer
 }
 // If the character is an operator, pop two elements, apply the operator, and push the result
 else {
 int operand2 = stack.pop(); // Second operand
 int operand1 = stack.pop(); // First operand
 switch (ch) {
 case '+':
 stack.push(operand1 + operand2);
 break;
 case '-':
 stack.push(operand1- operand2);
 break;
 case '*':
 stack.push(operand1 * operand2);
break;
 case '/':
 stack.push(operand1 / operand2);
 break;
 }
 }
 }
 // The result is the only element left in the stack
 return stack.pop();
 }
 public static void main(String[] args) {
 Scanner scanner = new Scanner(System.in);
 System.out.println("Enter a postfix expression (e.g., 2354+): ");
 String expression = scanner.nextLine();
 int result = evaluatePostfix(expression);
 System.out.println("The result of the postfix expression is: " + result);
 scanner.close();
 }
 }