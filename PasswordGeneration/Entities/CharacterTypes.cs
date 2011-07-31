namespace PasswordGeneration.Entities
{
    public enum CharacterTypes : byte
    {
        Alpha_Lower = 1,
        Alpha_Upper = 2,
        Alpha_Upper_and_Lower = 3,
        Digit = 4,
        AlphaLowerNumeric = 5,        //Digit + Alpha_Lower
        AlphaUpperNumeric = 6,        //Digit + Alpha_Upper
        AlphaNumeric = 7,             //Alpha_Upper_and_Lower + Digit
        Special = 8,
        AlphaNumericSpecial = 15,     //AlphaNumeric + Special
    }
}