password-generator-library
==========================

C# Static library for creating passwords within your project.   

For example generating a temporary password for a user who forgot their password or email to a newly registered user to confirm their email at the same time.


Static class with static methods

Namespace : RandomPasswordGenerator

Class Name : Password Generator

Methods : 

    public static string GeneratePassword(int numberOfAlphabetical, int numberOfNumerical, int numberOfSpecialCharacters)

    public static string GenerateStandardEightCharacterPassword()

    public static string GenerateStandardTwelveCharacterPassword()

    public static ICollection<string> GenerateXNumberOfPasswords(int numberOfPasswords, int numberOfAlphabetical, int numberOfNumerical, int numberOfSpecialCharacters)
