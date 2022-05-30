# DebtPayingAlgorithms
Compares different ways to pay off debt. Calculates time and interest spent on each one. 

Spoiler: the snowball method (paying off smallest loans first) works the best in most cases, but of course it depends on your specific loans, which is why this tool exists.

Add these files to a C# project using Visual Basic or Mono

Be sure to name your project DebtPayOff or you'll have to rename the namespace on the 3 files to match your project name. 

after you build run the program with ctrl F5

## Running with Mono (assuming you have <a href="https://jordancotter.wordpress.com/2022/03/01/getting-started-with-mono-net-on-linux/">mono installed</a>)
`$ git clone git@github.com:cotterjd/DebtPayingAlgorithms.git`<br>
`$ cd DebtPayingAlgorithms`<br>
`$ csc Main.cs Loan.cs PayPlan.cs`<br>
`$ mono Main.exe`<br>
