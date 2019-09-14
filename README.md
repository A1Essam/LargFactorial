# Calculate Large Factorial
## calculate large factorial up to factorial 1000 in some second

![Capture](https://user-images.githubusercontent.com/47161400/64912665-bc5c1a00-d732-11e9-986b-f8270daa8c0c.PNG)

The idea based on simple school multiplication which the solution consist of 
### Mult Function 
it take two numbers and multiply each single number of the first number with each single number of the second number.
    
### Add Function
it take the result of Mult Function and add them together
    
    
#### Factorial of (100)
    
    Mult(100,99)
    {
    1 0 0
         *
      9 9
    -------
      9 0 0  >
    9 0 0 0  > these two number are the output of this function which will pass to Add Function.
    }
    
    Add(900 , 9000){
      9 0 0
           +  
    9 0 0 0
    --------
    9 9 0 0  > this is the result of multiply 100 by 99.
    }
    
    Mult(9900 , 98) .....
  
