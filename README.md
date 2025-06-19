# new_practical_work_ii_oop

# Table of contents
- [Introduction](#introduction)
- [Description](#description)
- [Problems](#problems)
- [Conclusions](#conclusions)


# Introduction
This Design Detailed Document has been made to describe this practical work, some problems faced during its development and conclusions of it. The document is composed by firstly by the Title, then it contains a Table of contents with each section of it, to make navegation easier along the whole document. 

Description section is designed to describe how the program works and how the solution is reached. 

To continue, Problems section is used to describe all the problems that I had to face during the development of the whole projects like problems with de design of the .xaml files, problems creating the .csv files with the info about the user, etc.

Finally, Conclusion section is mainly proposed to include what I have learned developing this project, how good is the solution of the program when running it and some other new info reached during the development, that could be valuable and important for the development of future projects.

# Description
For this section I will talk about some design and developed decisions. 

For the design, I followed the same design I used for developing the PW2 in the ordinary call. The things I had to add for this new project has been the Bits Entry input for some Conversion types for the Calculator Page, as well as changing some titles for this new project.

For the development decisions, as well, I used mainly the base I had for the previous PW2 in the ordinary call, as it uses mostly the same code. To add, I had to see how the user info could be displayed so I implemented a button that shows up an alert with all the info about the user that is in that moment using the Conversor.

+--------------------+
|      Application   | 
|--------------------|
| +MainPage: Page    |
+--------------------+

+--------------------+
|       Shell        | 
+--------------------+

+------------------------------------+
|    CalculatorPage                  |
+------------------------------------+
| - currentUser: User                |
| - converter: Converter             |
+------------------------------------+
| +OnDecimalToBinaryClicked()        |
| +OnDecimalToOctalClicked()         |
| +OnDecimalToHexadecimalClicked()   |
| +OnDecimalToTwoComplementClicked() |
| +OnBinaryToDecimalClicked()        |
| +OnOctalToDecimalClicked()         |
| +OnHexadecimalToDecimalClicked()   |
| +OnTwoComplementToDecimalClicked() |
| +OnShowUserInfoClicked()           |
+------------------------------------+

+--------------------------+
|     ForgotPasswordPage   |
+--------------------------+
| +OnSendRecoveryClicked() |
| +OnBackToLoginClicked()  |
+--------------------------+

+---------------------------+
|     MainPage              |
+---------------------------+
| +OnSignInClicked()        |
| +OnForgotPasswordTapped() |
| +OnGoToRegisterClicked()  |
| +OnGoToCalculator()       |
+---------------------------+

+-------------------------+
|    RegisterPage         |
+-------------------------+
| +OnRegisterClicked()    |
| +IsValidPassword():bool |
| +OnGoToLoginTapped()    |
+-------------------------+

+--------------------------+
|     User                 |
+--------------------------+
| - name: string           |
| - username: string       |
| - password: string       |
| - operationCount: int    |
+--------------------------+
| +setName(string)         |
| +setUsername(string)     |
| +setPassword(string)     |
| +getName(): string       |
| +getUsername(): string   |
| +getPassword(): string   |
| +DisplayUserInfo()       |
| +IncrementOperation()    |
| +getOperationCount():int |
+--------------------------+

+-------------------------+
|   Interface: Operations |
+-------------------------+
| +setName()              |
| +setUsername()          |
| +setPassword()          |
| +getName()              |
| +getUsername()          |
| +getPassword()          |
| +DisplayUserInfo()      |
| +IncrementOperation()   |
+-------------------------+

+----------------------------------------------------+
|     Converter                                      |
+----------------------------------------------------+
| +PerformConversion(type:int, input:string): string |
+----------------------------------------------------+


# Problems
During the development of this program I had to face some problems.
Firstly, I had some problems implementing the bitsEntry for the program as it did not work well, as it did not let me introduce any input to it at first, but then I managed to solve it changing the code.

Moreover, I had again some problems implementing the .cs files from the activity_7 that includes all the code for the conversions as well as changing the namespace of all of them to truly implement them in the program.

To add, I had some problems in the conversions as the PerformConversion mehod was naming other index different to the actual conversion it wanted to do.


# Conclusions
Some conclusions I have reached during the development of this PW2 are the following ones. Firstly, we have to ta care about the inputs we pass to the programs as we do not only need that the program runs correctly, but also prevent some not propper inputs from the users.

To add, the files from the activity 7 were not supposed to work for this project at first, but doing this project I have realized that we can make a full program and then, implement it for real visual solutions in MAUI.

